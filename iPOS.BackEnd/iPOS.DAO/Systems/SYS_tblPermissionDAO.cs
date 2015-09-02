using System;
using System.Collections.Generic;
using System.Data;
using iPOS.Core.Helper;
using iPOS.DTO.Systems;

namespace iPOS.DAO.Systems
{
    public interface ISYS_tblPermissionDAO
    {
        List<SYS_tblPermissionDTO> GetAllPermisionList(string username, string language_id, string id, string parent_id, bool is_user);

        string UpdatePermission(string username, string language_id, List<SYS_tblPermissionDTO> permissionList, bool is_user);
    }

    public class SYS_tblPermissionDAO : BaseDAO, ISYS_tblPermissionDAO
    {
        public List<SYS_tblPermissionDTO> GetAllPermisionList(string username, string language_id, string id, string parent_id, bool is_user)
        {
            string strParameter = "", strActivity = "";
            strParameter = is_user ? "UsernameOther" : "GroupID";
            strActivity = is_user ? "GetDataByUser" : "GetDataByGroupUser";
            List<SYS_tblPermissionDTO> result = new List<SYS_tblPermissionDTO>();
            try
            {
                DataTable data = db.GetDataTable("SYS_spfrmPermission", new string[] { "Activity", "Username", "LanguageID", strParameter, "FunctionID" }, new object[] { strActivity, username, language_id, id, parent_id });
                if (data != null && data.Rows.Count > 0)
                    result = ConvertEngine.ConvertDataTableToObjectList<SYS_tblPermissionDTO>(data);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }

        public string UpdatePermission(string username, string language_id, List<SYS_tblPermissionDTO> permissionList, bool is_user)
        {
            string strParameter = "", strActivity = "", strError = "";
            try
            {
                strParameter = is_user ? "UsernameOther" : "GroupID";
                strActivity = is_user ? "UpdateUserPermission" : "UpdateGroupUserPermission";
                foreach (SYS_tblPermissionDTO item in permissionList)
                {
                    if (string.IsNullOrEmpty(strError))
                        strError = db.sExecuteSQL("SYS_spfrmPermission", new string[] { "Activity", "Username", "LanguageID", strParameter, "FunctionID", "AllowInsert", "AllowUpdate", "AllowDelete", "AllowAccess", "AllowPrint", "AllowImport", "AllowExport", "UserLevelID", "Note" }, new object[] { strActivity, username, language_id, item.ID, item.FunctionID, item.AllowInsert, item.AllowUpdate, item.AllowDelete, item.AllowAccess, item.AllowPrint, item.AllowImport, item.AllowExport, item.UserLevelID, item.Note });
                    else break;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return ex.Message;
            }

            return strError;
        }
    }
}

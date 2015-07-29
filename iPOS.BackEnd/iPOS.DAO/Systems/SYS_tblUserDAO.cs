using System;
using System.Collections.Generic;
using System.Data;
using iPOS.Core.Helper;
using iPOS.DTO.Systems;

namespace iPOS.DAO.Systems
{
    public interface ISYS_tblUserDAO
    {
        SYS_tblUserDTO CheckLogin(string username, string password, string language);

        List<SYS_tblUserDTO> LoadAllData(string username, string language_id);
    }

    public class SYS_tblUserDAO : BaseDAO, ISYS_tblUserDAO
    {
        public SYS_tblUserDTO CheckLogin(string username, string password, string language)
        {
            DataRow dr = db.GetDataRow("SYS_spfrmUser", new string[] { "Activity", "Username", "LanguageID", "Password" }, new object[] { "CheckLogin", username, language, password });
            if (dr != null)
                return new SYS_tblUserDTO
                {
                    Username = dr["Username"] + "",
                    Password = dr["Password"] + "",
                    GroupID = Convert.ToInt32(dr["GroupID"]),
                    EffectiveDate = Convert.ToDateTime(dr["EffectiveDate"]),
                    ToDate = dr["ToDate"] == DBNull.Value ? (DateTime?)null : (DateTime)dr["ToDate"],
                    DateChangePass = dr["DateChangePass"] == DBNull.Value ? (DateTime?)null : (DateTime)dr["DateChangePass"],
                    Locked = Convert.ToBoolean(dr["Locked"]),
                    LockDate = dr["LockDate"] == DBNull.Value ? (DateTime?)null : (DateTime)dr["LockDate"],
                    UnlockDate = dr["UnlockDate"] == DBNull.Value ? (DateTime?)null : (DateTime)dr["UnlockDate"],
                    PassNeverExpired = Convert.ToBoolean(dr["PassNeverExpired"]),
                    ChangePassNextTime = Convert.ToBoolean(dr["ChangePassNextTime"]),
                    Creater = dr["Creater"] + "",
                    CreateTime = Convert.ToDateTime(dr["CreateTime"]),
                    Editer = dr["Editer"] + "",
                    EditTime = dr["EditTime"] == DBNull.Value ? (DateTime?)null : (DateTime)dr["EditTime"],
                    EmpID = dr["EmpID"] + "",
                    Visible = Convert.ToBoolean(dr["Visible"]),
                    FullName = dr["FullName"] + "",
                    IsSystemAdmin = Convert.ToBoolean(dr["IsSystemAdmin"]),
                    CanNotChangePassword = Convert.ToBoolean(dr["CanNotChangePassword"]),
                    Email = dr["Email"] + "",
                    Note = dr["Note"] + "",
                    GroupName = dr["GroupName"] + "",
                    Activity = "CheckLogin",
                    UserName = username,
                    LanguageID = language
                };

            return null;
        }

        public List<SYS_tblUserDTO> LoadAllData(string username, string language_id)
        {
            List<SYS_tblUserDTO> result = new List<SYS_tblUserDTO>();
            try
            {
                string strErr = InsertActionLog(new SYS_tblActionLogDTO
                {
                    Activity = BaseConstant.COMMAND_INSERT_EN,
                    Username = username,
                    LanguageID = language_id,
                    ActionEN = BaseConstant.COMMAND_LOAD_ALL_DATA_EN,
                    ActionVN = BaseConstant.COMMAND_LOAD_ALL_DATA_VI,
                    FunctionID = "9",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa tải thành công dữ liệu người dùng.", username),
                    DescriptionEN = string.Format("Account '{0}' downloaded successfully data of users.", username)
                });

                if (string.IsNullOrEmpty(strErr))
                {
                    DataTable data = db.GetDataTable("SYS_spfrmUser", new string[] { "Activity", "Username", "LanguageID" }, new object[] { BaseConstant.COMMAND_LOAD_ALL_DATA_EN, username, language_id });
                    if (data != null && data.Rows.Count > 0)
                    {
                        result = ConvertEngine.ConvertDataTableToObjectList<SYS_tblUserDTO>(data);
                    }
                }
                else
                {
                    logger.Error(strErr);
                    return result;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }
    }
}

using iPOS.Core.Helper;
using iPOS.DTO.Systems;
using System;
using System.Collections.Generic;
using System.Data;

namespace iPOS.DAO.Systems
{
    public interface ISYS_tblUserLevelDAO
    {
        List<SYS_tblUserLevelDTO> LoadAllData(string username, string language_id);
    }

    public class SYS_tblUserLevelDAO : BaseDAO, ISYS_tblUserLevelDAO
    {
        public List<SYS_tblUserLevelDTO> LoadAllData(string username, string language_id)
        {
            List<SYS_tblUserLevelDTO> result = new List<SYS_tblUserLevelDTO>();
            try
            {
                DataTable data = db.GetDataTable("SYS_spfrmUserLevel", new string[] { "Activity", "Username", "LanguageID" }, new object[] { BaseConstant.COMMAND_GET_COMBO_BOX, username, language_id });
                if (data != null && data.Rows.Count > 0)
                {
                    result = ConvertEngine.ConvertDataTableToObjectList<SYS_tblUserLevelDTO>(data);
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

using System;
using System.Collections.Generic;
using iPOS.Core.Helper;
using iPOS.DTO.Systems;

namespace iPOS.DAO.Systems
{
    public interface ISYS_tblActionLogDAO
    {
        string InsertUpdateLog(SYS_tblActionLogDTO actionLog);

        List<SYS_tblActionLogDTO> LoadAllData(string username, string language_id);
    }

    public class SYS_tblActionLogDAO : BaseDAO, ISYS_tblActionLogDAO
    {
        public string InsertUpdateLog(SYS_tblActionLogDTO actionLog)
        {
            string result = "";
            result = db.sExecuteSQL("SYS_spfrmActionLog", new string[] { "Activity", "Username", "LanguageID", "FullName", "ComputerName", "AccountWindows", "ActionVN", "ActionEN", "FunctionID", "FunctionNameVN", "FunctionNameEN", "IPLAN", "IPWAN", "MacAddress", "DescriptionVN", "DescriptionEN" }, new object[] { actionLog.Activity, actionLog.UserID, actionLog.LanguageID, actionLog.FullName, actionLog.ComputerName, actionLog.AccountWindows, actionLog.ActionVN, actionLog.ActionEN, actionLog.FunctionID, actionLog.FunctionNameVN, actionLog.FunctionNameEN, actionLog.IPLAN, actionLog.IPWAN, actionLog.MacAddress, actionLog.DescriptionVN, actionLog.DescriptionEN });

            if (!string.IsNullOrEmpty(result))
                logger.Error(result);
            return result;
        }

        public List<SYS_tblActionLogDTO> LoadAllData(string username, string language_id)
        {
            throw new NotImplementedException();
        }
    }
}

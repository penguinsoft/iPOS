using System;
using iPOS.Core.Logger;
using iPOS.Core.SQLServer;
using iPOS.DTO.Systems;

namespace iPOS.DAO
{
    public class BaseDAO
    {
        protected SQLEngine db;
        protected ILogEngine logger;

        public BaseDAO()
        {
            db = new SQLEngine();
            logger = new LogEngine();
        }

        public string InsertActionLog(SYS_tblActionLogDTO log)
        {
            string result = "";
            try
            {
                result = db.sExecuteSQL("SYS_spfrmActionLog", new string[] { "Activity", "Username", "LanguageID", "FullName", "ComputerName", "AccountWindows", "ActionVN", "ActionEN", "ActionTime", "FunctionID", "FunctionNameVN", "FunctionNameEN", "IPLAN", "IPWAN", "MacAddress", "DescriptionVN", "DescriptionEN" }, new object[] { log.Activity, log.UserID, log.LanguageID, log.FullName, log.ComputerName, log.AccountWindows, log.ActionVN, log.ActionEN, DateTime.Now, log.FunctionID, log.FunctionNameVN, log.FunctionNameEN, log.IPLAN, log.IPWAN, log.MacAddress, log.DescriptionVN, log.DescriptionEN });

                if (!string.IsNullOrEmpty(result))
                    logger.Error(result);

                return result;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                logger.Error(ex);
            }

            return result;
        }
    }
}

using System;
using System.Threading.Tasks;
using iPOS.DAO;
using iPOS.DRO.System;
using iPOS.DTO.System;
using Newtonsoft.Json;
using ConfigEngine = iPOS.Core.Helper.ConfigEngine;

namespace iPOS.BUS
{
    public class BaseBUS
    {
        public static string GetBaseUrl()
        {
            string result="";
            if (!string.IsNullOrEmpty(ConfigEngine.PortNumber))
                result = ConfigEngine.Domain + ":" + ConfigEngine.PortNumber;
            else result = ConfigEngine.Domain;

            return result + "/" + ConfigEngine.ServiceName + ".svc";
        }

        public static async Task<string> ManageActionLog(SYS_tblActionLogDTO actionLog)
        {
            if (actionLog.LanguageID.Equals("vi")) actionLog.LanguageID = "VN";
            else if (actionLog.LanguageID.Equals("en")) actionLog.LanguageID = "EN";

            string url = string.Format(@"{0}/ManageActionLog", GetBaseUrl());
            var postData = new SYS_tblActionLogDCO
            {
                ID = actionLog.ID,
                FullName = actionLog.FullName,
                ComputerName = actionLog.ComputerName,
                AccountWindows = actionLog.AccountWindows,
                ActionVN = actionLog.ActionVN,
                ActionEN = actionLog.ActionEN,
                ActionTime = JsonConvert.SerializeObject(actionLog.ActionTime, new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat }),
                FunctionID = actionLog.FunctionID,
                FunctionNameVN = actionLog.FunctionNameVN,
                FunctionNameEN = actionLog.FunctionNameEN,
                IPLAN = actionLog.IPLAN,
                IPWAN = actionLog.IPWAN,
                MacAddress = actionLog.MacAddress,
                DescriptionVN = actionLog.DescriptionVN,
                DescriptionEN = actionLog.DescriptionEN,
                Activity = actionLog.Activity,
                Username = actionLog.Username,
                LanguageID = actionLog.LanguageID,
                Visible = actionLog.Visible,
                Creater = actionLog.Creater,
                CreateTime = JsonConvert.SerializeObject(actionLog.CreateTime, new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat }),
                Editer = actionLog.Editer,
                EditTime = actionLog.EditTime
            };
            var json_data = "{\"actionLog\":" + JsonConvert.SerializeObject(postData) + "}";

            return await BaseDAO.ManageActionLog(url, json_data);
        }
    }
}

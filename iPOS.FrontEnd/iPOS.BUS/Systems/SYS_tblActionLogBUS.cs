using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iPOS.DAO.Systems;
using iPOS.DRO.Systems;
using iPOS.DTO.Systems;
using Newtonsoft.Json;
using iPOS.DRO;

namespace iPOS.BUS.Systems
{
    public class SYS_tblActionLogBUS : BaseBUS
    {
        public async static Task<ResponseItem> InsertUpdateLog(SYS_tblActionLogDTO item)
        {
            ResponseItem result = new ResponseItem();
            try
            {
                string url = string.Format(@"{0}/InsertUpdateLog", GetBaseUrl());
                var postData = new SYS_tblActionLogDCO
                {
                    ID = item.ID,
                    ActionVN = item.ActionVN,
                    ActionEN = item.ActionEN,
                    ActionTime = item.ActionTime,
                    FunctionID = item.FunctionID,
                    FunctionNameVN = item.FunctionNameVN,
                    FunctionNameEN = item.FunctionNameEN,
                    DescriptionEN = item.DescriptionEN,
                    DescriptionVN = item.DescriptionVN,
                    FullName = item.FullName,
                    ComputerName = item.ComputerName,
                    AccountWindows = item.AccountWindows,
                    IPLAN = item.IPLAN,
                    IPWAN = item.IPWAN,
                    MacAddress = item.MacAddress,
                    Activity = item.Activity,
                    UserID = item.UserID,
                    LanguageID = item.LanguageID
                };
                var json_data = "{\"actionLog\":" + JsonConvert.SerializeObject(postData, new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                }) + "}";

                result = await SYS_tblActionLogDAO.InsertUpdateLog(url, json_data);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                result.Message = ex.Message;
            }

            return result;
        }
    }
}
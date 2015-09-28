using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iPOS.DRO.Systems;
using Newtonsoft.Json;
using iPOS.DRO;

namespace iPOS.DAO.Systems
{
    public class SYS_tblActionLogDAO : BaseDAO
    {
        public static async Task<ResponseItem> InsertUpdateLog(string url, string json_data) 
        {
            ResponseItem result = new ResponseItem();
            try
            {
                var response_data = await HttpPost(url, json_data) + "";
                if (response_data.ToLower().StartsWith("error"))
                {
                    result.IsError = true;
                    string[] tmp = response_data.Split('|');
                    result.ErrorCode = tmp[1];
                    result.ErrorMessage = tmp[2];
                }
                else
                {
                    var response_collection = JsonConvert.DeserializeObject<SYS_tblActionLogDRO>(response_data + "");

                    if (response_collection != null)
                        result = response_collection.ResponseItem;
                }

                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }
    }
}

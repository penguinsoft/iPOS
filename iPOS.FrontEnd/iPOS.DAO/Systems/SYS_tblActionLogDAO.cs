using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iPOS.DRO.Systems;
using Newtonsoft.Json;

namespace iPOS.DAO.Systems
{
    public class SYS_tblActionLogDAO : BaseDAO
    {
        public static async Task<string> InsertUpdateLog(string url, string json_data) 
        {
            string result = "";
            try
            {
                var response_data = await HttpPost(url, json_data) + "";
                var response_collection = JsonConvert.DeserializeObject<SYS_tblActionLogDRO>(response_data + "");

                if (response_collection != null)
                    result = "";
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

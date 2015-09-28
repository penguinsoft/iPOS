using System;
using System.Threading.Tasks;
using iPOS.DRO;
using Newtonsoft.Json;

namespace iPOS.DAO.Tools
{
    public class OBJ_FileDAO : BaseDAO
    {
        public async static Task<string> UploadImageFile(string url, string json_data)
        {
            try
            {
                var response_data = await HttpPost(url, json_data);
                var response_collection = JsonConvert.DeserializeObject<BaseDRO>(response_data + "");

                if (response_collection != null)
                    return response_collection.ResponseItem.Message;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return ex.Message;
            }

            return "";
        }
    }
}

using iPOS.DRO.Systems;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace iPOS.DAO.Systems
{
    public class SYS_tblUserLevelDAO : BaseDAO
    {
        public async static Task<SYS_tblUserLevelDRO> GetAllUserLevel(string url)
        {
            SYS_tblUserLevelDRO result = new SYS_tblUserLevelDRO();
            try
            {
                var response_data = await HttpGet(url);
                if (response_data.ToLower().StartsWith("error"))
                {
                    result.ResponseItem.IsError = true;
                    string[] tmp = response_data.Split('|');
                    result.ResponseItem.ErrorCode = tmp[1];
                    result.ResponseItem.ErrorMessage = tmp[2];
                }
                else
                {
                    var response_collection = JsonConvert.DeserializeObject<SYS_tblUserLevelDRO>(response_data + "");

                    if (response_collection != null)
                    {
                        result.UserLevelList = response_collection.UserLevelList;
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return null;
        }
    }
}

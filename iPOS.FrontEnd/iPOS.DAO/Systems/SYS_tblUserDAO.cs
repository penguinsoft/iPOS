using System;
using System.Threading.Tasks;
using iPOS.DRO.Systems;
using iPOS.DTO.Systems;
using Newtonsoft.Json;

namespace iPOS.DAO.Systems
{
    public class SYS_tblUserDAO : BaseDAO
    {
        public async static Task<SYS_tblUserDTO> CheckLogin(string url)
        {
            SYS_tblUserDTO result = new SYS_tblUserDTO();
            try
            {
                var response_data = await HttpGet(url);
                var response_collection = JsonConvert.DeserializeObject<SYS_tblUserDRO>(response_data + "");

                if (response_collection != null)
                {
                    result = response_collection.UserItem;
                    result.Username += "$" + response_collection.Message;
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

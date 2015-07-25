using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iPOS.DRO.Systems;
using iPOS.DTO.Systems;
using Newtonsoft.Json;

namespace iPOS.DAO.Systems
{
    public class SYS_tblGroupUserDAO : BaseDAO
    {
        public async static Task<List<SYS_tblGroupUserDTO>> GetAllGroupUsers(string url)
        {
            List<SYS_tblGroupUserDTO> result = new List<SYS_tblGroupUserDTO>();
            try
            {
                var response_data = await HttpGet(url);
                var response_collection = JsonConvert.DeserializeObject<SYS_tblGroupUserDRO>(response_data + "");

                if (response_collection != null)
                    result = response_collection.GroupUserList;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }

        public async static Task<string> InsertUpdateGroupUser(string url, string json_data)
        {
            string result = "";
            try
            {
                var response_data = await HttpPost(url, json_data);
                var response_collection = JsonConvert.DeserializeObject<SYS_tblGroupUserDRO>(response_data + "");

                if (response_collection != null)
                    result = response_collection.Message;
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

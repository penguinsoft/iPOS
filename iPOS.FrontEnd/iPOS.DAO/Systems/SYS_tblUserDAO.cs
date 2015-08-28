using System;
using System.Collections.Generic;
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

        public async static Task<List<SYS_tblUserDTO>> GetAllUsers(string url)
        {
            try
            {
                var response_data = await HttpGet(url);
                var response_collection = JsonConvert.DeserializeObject<SYS_tblUserDRO>(response_data + "");

                if (response_collection != null)
                    return response_collection.UserList;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return null;
        }

        public async static Task<SYS_tblUserDTO> GetUserItem(string url)
        {
            try
            {
                var response_data = await HttpGet(url);
                var response_collection = JsonConvert.DeserializeObject<SYS_tblUserDRO>(response_data + "");

                if (response_collection != null)
                    return response_collection.UserItem;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return null;
        }

        public async static Task<string> InsertUpdateUser(string url, string json_data)
        {
            try
            {
                var response_data = await HttpPost(url, json_data);
                var response_collection = JsonConvert.DeserializeObject<SYS_tblUserDRO>(response_data + "");

                if (response_collection != null)
                    return response_collection.Message;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return ex.Message;
            }

            return "";
        }

        public async static Task<string> DeleteUser(string url)
        {
            try
            {
                var response_data = await HttpGet(url);
                var response_collection = JsonConvert.DeserializeObject<SYS_tblUserDRO>(response_data + "");

                if (response_collection != null)
                    return response_collection.Message;
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

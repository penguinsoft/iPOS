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
        public async static Task<SYS_tblUserDRO> CheckLogin(string url)
        {
            SYS_tblUserDRO result = new SYS_tblUserDRO();
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
                    var response_collection = JsonConvert.DeserializeObject<SYS_tblUserDRO>(response_data + "");

                    if (response_collection != null)
                    {
                        result.UserItem = response_collection.UserItem;
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

        public async static Task<SYS_tblUserDRO> GetAllUsers(string url)
        {
            SYS_tblUserDRO result = new SYS_tblUserDRO();
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
                    var response_collection = JsonConvert.DeserializeObject<SYS_tblUserDRO>(response_data + "");

                    if (response_collection != null)
                    {
                        result.UserList = response_collection.UserList;
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

        public async static Task<SYS_tblUserDRO> GetUserItem(string url)
        {
            SYS_tblUserDRO result = new SYS_tblUserDRO();
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
                    var response_collection = JsonConvert.DeserializeObject<SYS_tblUserDRO>(response_data + "");

                    if (response_collection != null)
                    {
                        result.UserItem = response_collection.UserItem;
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

        public async static Task<SYS_tblUserDRO> InsertUpdateUser(string url, string json_data)
        {
            SYS_tblUserDRO result = new SYS_tblUserDRO();
            try
            {
                var response_data = await HttpPost(url, json_data);
                if (response_data.ToLower().StartsWith("error"))
                {
                    result.ResponseItem.IsError = true;
                    string[] tmp = response_data.Split('|');
                    result.ResponseItem.ErrorCode = tmp[1];
                    result.ResponseItem.ErrorMessage = tmp[2];
                }
                else
                {
                    var response_collection = JsonConvert.DeserializeObject<SYS_tblUserDRO>(response_data + "");

                    if (response_collection != null)
                    {
                        result.ResponseItem.Message = response_collection.ResponseItem.Message;
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

        public async static Task<SYS_tblUserDRO> DeleteUser(string url)
        {
            SYS_tblUserDRO result = new SYS_tblUserDRO();
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
                    var response_collection = JsonConvert.DeserializeObject<SYS_tblUserDRO>(response_data + "");

                    if (response_collection != null)
                    {
                        result.ResponseItem.Message = response_collection.ResponseItem.Message;
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

        public async static Task<SYS_tblUserDRO> ChangeUserPassword(string url)
        {
            SYS_tblUserDRO result = new SYS_tblUserDRO();
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
                    var response_collection = JsonConvert.DeserializeObject<SYS_tblUserDRO>(response_data + "");

                    if (response_collection != null)
                    {
                        result.ResponseItem.Message = response_collection.ResponseItem.Message;
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

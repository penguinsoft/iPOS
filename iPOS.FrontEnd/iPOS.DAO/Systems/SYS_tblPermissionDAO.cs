using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iPOS.DRO.Systems;
using iPOS.DTO.Systems;
using Newtonsoft.Json;

namespace iPOS.DAO.Systems
{
    public class SYS_tblPermissionDAO : BaseDAO
    {
        public async static Task<SYS_tblPermissionDRO> GetPermissionList(string url)
        {
            SYS_tblPermissionDRO result = new SYS_tblPermissionDRO();
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
                    var response_collection = JsonConvert.DeserializeObject<SYS_tblPermissionDRO>(response_data + "");

                    if (response_collection != null)
                    {
                        result.PermissionList = response_collection.PermissionList;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                result.ResponseItem.Message = ex.Message;
            }

            return result;
        }

        public async static Task<SYS_tblPermissionDRO> GetPermissionItem(string url)
        {
            SYS_tblPermissionDRO result = new SYS_tblPermissionDRO();
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
                    var response_collection = JsonConvert.DeserializeObject<SYS_tblPermissionDRO>(response_data + "");

                    if (response_collection != null)
                    {
                        result.PermissionItem = response_collection.PermissionItem;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                result.ResponseItem.Message = ex.Message;
            }

            return result;
        }

        public async static Task<SYS_tblPermissionDRO> UpdatePermission(string url, string json_data)
        {
            SYS_tblPermissionDRO result = new SYS_tblPermissionDRO();
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
                    var response_collection = JsonConvert.DeserializeObject<SYS_tblPermissionDRO>(response_data + "");

                    if (response_collection != null)
                    {
                        result.ResponseItem.Message = response_collection.ResponseItem.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                result.ResponseItem.Message = ex.Message;
            }

            return result;
        }
    }
}

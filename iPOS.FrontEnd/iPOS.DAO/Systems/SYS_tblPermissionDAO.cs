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
        public async static Task<List<SYS_tblPermissionDTO>> GetPermissionList(string url)
        {
            try
            {
                var response_data = await HttpGet(url);
                var response_collection = JsonConvert.DeserializeObject<SYS_tblPermissionDRO>(response_data + "");

                if (response_collection != null)
                    return response_collection.PermissionList;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return null;
        }

        public async static Task<string> UpdatePermission(string url, string json_data)
        {
            try
            {
                var response_data = await HttpPost(url, json_data);
                var response_collection = JsonConvert.DeserializeObject<SYS_tblPermissionDRO>(response_data + "");

                if (response_collection != null)
                    return response_collection.Message;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iPOS.DAO.Systems;
using iPOS.DTO.Systems;
using Newtonsoft.Json;

namespace iPOS.BUS.Systems
{
    public class SYS_tblPermissionBUS : BaseBUS
    {
        public async static Task<List<SYS_tblPermissionDTO>> GetPermissionList(string username, string language_id, string id, string parent_id, bool is_user)
        {
            string url = string.Format("{0}/GetPermissionList?Username={1}&LanguageID={2}&ID={3}&ParentID={4}&IsUser={5}", GetBaseUrl(), username, language_id, id, parent_id, is_user);

            return await SYS_tblPermissionDAO.GetPermissionList(url);
        }

        public async static Task<string> UpdatePermission(string username, string language_id, List<SYS_tblPermissionDTO> permissions, bool is_user, SYS_tblActionLogDTO actionLog)
        {
            try
            {
                string url = string.Format("{0}/UpdatePermission", GetBaseUrl());
                var json_data = "{\"Username\":\"" + username + "\",\"LanguageID\":\"" + language_id + "\",\"IsUser\":" + (is_user ? "true" : "false") + ",\"permissionList\":" + JsonConvert.SerializeObject(permissions, new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                }) + "}";

                string result = await SYS_tblPermissionDAO.UpdatePermission(url, json_data);
                if (string.IsNullOrEmpty(result)) result = await SYS_tblActionLogBUS.InsertUpdateLog(actionLog);
                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return ex.Message;
            }
        }
    }
}

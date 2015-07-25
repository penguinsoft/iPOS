using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iPOS.DAO.System;
using iPOS.DRO.System;
using iPOS.DTO.System;
using Newtonsoft.Json;

namespace iPOS.BUS.System
{
    public class SYS_tblGroupUserBUS : BaseBUS
    {
        public async static Task<List<SYS_tblGroupUserDTO>> GetAllGroupUsers(string username, string language)
        {
            string url = string.Format("{0}/GetAllGroupUsers?Username={1}&LanguageID={2}", GetBaseUrl(), username, language);
            return await SYS_tblGroupUserDAO.GetAllGroupUsers(url);
        }

        public async static Task<string> InsertUpdateGroupUser(SYS_tblGroupUserDTO item)
        {
            try
            {
                string url = string.Format(@"{0}/InsertUpdateGroupUser", GetBaseUrl());
                var postData = new SYS_tblGroupUserDCO
                {
                    GroupID = item.GroupID,
                    GroupCode = item.GroupCode,
                    VNName = item.VNName,
                    ENName = item.ENName,
                    Note = item.Note,
                    IsDefault = item.IsDefault,
                    Active = item.Active,
                    Activity = item.Activity,
                    Username = item.Username,
                    Language = item.LanguageID
                };
                var json_data = "{\"groupUser\":" + JsonConvert.SerializeObject(postData) + "}";

                return await SYS_tblGroupUserDAO.InsertUpdateGroupUser(url, json_data);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return ex.Message;
            }
        }
    }
}

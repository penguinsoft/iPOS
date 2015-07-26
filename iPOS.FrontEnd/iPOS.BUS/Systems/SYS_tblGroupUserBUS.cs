using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iPOS.DAO.Systems;
using iPOS.DRO.Systems;
using iPOS.DTO.Systems;
using Newtonsoft.Json;

namespace iPOS.BUS.Systems
{
    public class SYS_tblGroupUserBUS : BaseBUS
    {
        public async static Task<List<SYS_tblGroupUserDTO>> GetAllGroupUsers(string username, string language)
        {
            string url = string.Format("{0}/GetAllGroupUsers?Username={1}&LanguageID={2}", GetBaseUrl(), username, language);
            return await SYS_tblGroupUserDAO.GetAllGroupUsers(url);
        }

        public async static Task<SYS_tblGroupUserDTO> GetGroupUserItem(string username, string language, string group_user_id)
        {
            string url = string.Format(@"{0}/GetGroupUserByID?Username={1}&LanguageID={2}&GroupID={3}", GetBaseUrl(), username, language, group_user_id);

            return await SYS_tblGroupUserDAO.GetGroupUserItem(url);
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

        public async static Task<string> DeleteGroupUser(string group_id_list, string group_code_list, string username, string language)
        {
            try
            {
                string url = string.Format(@"{0}/DeleteGroupUser?Username={1}&LanguageID={2}&GroupUserIDList={3}&GroupUserCodeList={4}", GetBaseUrl(), username, language, group_id_list, group_code_list);

                return await SYS_tblGroupUserDAO.DeleteGroupUser(url);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return ex.Message;
            }
        }
    }
}

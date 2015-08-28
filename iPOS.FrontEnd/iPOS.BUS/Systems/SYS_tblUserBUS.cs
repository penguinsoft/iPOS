using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iPOS.DAO.Systems;
using iPOS.DRO.Systems;
using iPOS.DTO.Systems;
using Newtonsoft.Json;

namespace iPOS.BUS.Systems
{
    public class SYS_tblUserBUS : BaseBUS
    {
        public async static Task<SYS_tblUserDTO> CheckLogin(string username, string password, string language_id)
        {
            string url = string.Format("{0}/CheckLogin?Username={1}&Password={2}&LanguageID={3}", GetBaseUrl(), username, password, language_id);

            return await SYS_tblUserDAO.CheckLogin(url);
        }

        public async static Task<List<SYS_tblUserDTO>> GetAllUsers(string username, string language_id)
        {
            string url = string.Format("{0}/GetAllUsers?Username={1}&LanguageID={2}", GetBaseUrl(), username, language_id);

            return await SYS_tblUserDAO.GetAllUsers(url);
        }

        public async static Task<string> InsertUpdateUser(SYS_tblUserDTO item)
        {
            try
            {
                string url = string.Format(@"{0}/InsertUpdateUser", GetBaseUrl());
                var postData = new SYS_tblUserDCO
                {
                    UserName = item.UserName,
                    Password = item.Password,
                    GroupID = item.GroupID,
                    GroupName = item.GroupName,
                    EffectiveDate = item.EffectiveDate,
                    ToDate = item.ToDate,
                    DateChangePass = item.DateChangePass,
                    Locked = item.Locked,
                    LockDate = item.LockDate,
                    UnlockDate = item.UnlockDate,
                    PassNeverExpired = item.PassNeverExpired,
                    ChangePassNextTime = item.ChangePassNextTime,
                    EmpID = item.EmpID,
                    FullName = item.FullName, 
                    Email = item.EmpID,
                    Note = item.Note,
                    CanNotChangePassword = item.CanNotChangePassword,
                    Activity = item.Activity,
                    Username = item.Username,
                    LanguageID = item.LanguageID
                };
                var json_data = "{\"user\":" + JsonConvert.SerializeObject(postData) + "}";

                return await SYS_tblUserDAO.InsertUpdateUser(url, json_data);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return ex.Message;
            }
        }

        public async static Task<string> DeleteUser(string user_code_list, string username, string language_id)
        {
            try
            {
                string url = string.Format(@"{0}/DeleteUser?Username={1}&LanguageID={2}&UserCodeList={3}", GetBaseUrl(), username, username, language_id, user_code_list);

                return await SYS_tblUserDAO.DeleteUser(url);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return ex.Message;
            }
        }
    }
}

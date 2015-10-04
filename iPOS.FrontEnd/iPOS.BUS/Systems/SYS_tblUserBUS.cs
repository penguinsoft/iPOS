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
        public async static Task<SYS_tblUserDRO> CheckLogin(string username, string password, string language_id)
        {
            SYS_tblUserDRO result = new SYS_tblUserDRO();
            try
            {
                string url = string.Format("{0}/CheckLogin?Username={1}&Password={2}&LanguageID={3}", GetBaseUrl(), username, password, language_id);

                result = await SYS_tblUserDAO.CheckLogin(url);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                result.ResponseItem.Message = ex.Message;
            }

            return result;
        }

        public async static Task<SYS_tblUserDRO> GetAllUsers(string username, string language_id, SYS_tblActionLogDTO actionLog)
        {
            SYS_tblUserDRO result = new SYS_tblUserDRO();
            try
            {
                string url = string.Format("{0}/GetAllUsers?Username={1}&LanguageID={2}", GetBaseUrl(), username, language_id);

                result = await SYS_tblUserDAO.GetAllUsers(url);
                if (string.IsNullOrEmpty(result.ResponseItem.Message))
                    if (actionLog != null)
                        result.ResponseItem = await SYS_tblActionLogBUS.InsertUpdateLog(actionLog);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                result.ResponseItem.Message = ex.Message;
            }

            return result;
        }

        public async static Task<SYS_tblUserDRO> GetUserItem(string username, string language_id, string userid)
        {
            SYS_tblUserDRO result = new SYS_tblUserDRO();
            try
            {
                string url = string.Format("{0}/GetUserByID?Username={1}&LanguageID={2}&UsernameOther={3}", GetBaseUrl(), username, language_id, userid);

                result = await SYS_tblUserDAO.GetUserItem(url);
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                result.ResponseItem.Message = ex.Message;
            }

            return result;
        }

        public async static Task<SYS_tblUserDRO> InsertUpdateUser(SYS_tblUserDTO item, SYS_tblActionLogDTO actionLog)
        {
            SYS_tblUserDRO result = new SYS_tblUserDRO();
            try
            {
                string url = string.Format(@"{0}/InsertUpdateUser", GetBaseUrl());
                var postData = new SYS_tblUserDCO
                {
                    Username = item.Username,
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
                    UserID = item.UserID,
                    LanguageID = item.LanguageID
                };
                var json_data = "{\"user\":" + JsonConvert.SerializeObject(postData, new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                }) + "}";

                result = await SYS_tblUserDAO.InsertUpdateUser(url, json_data);
                if (string.IsNullOrEmpty(result.ResponseItem.Message)) result.ResponseItem = await SYS_tblActionLogBUS.InsertUpdateLog(actionLog);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                result.ResponseItem.Message = ex.Message;
            }

            return result;
        }

        public async static Task<SYS_tblUserDRO> DeleteUser(string user_code_list, string username, string language_id, SYS_tblActionLogDTO actionLog)
        {
            SYS_tblUserDRO result = new SYS_tblUserDRO();
            try
            {
                string url = string.Format(@"{0}/DeleteUser?Username={1}&LanguageID={2}&UserCodeList={3}", GetBaseUrl(), username, language_id, user_code_list);

                result = await SYS_tblUserDAO.DeleteUser(url);
                if (string.IsNullOrEmpty(result.ResponseItem.Message)) result.ResponseItem = await SYS_tblActionLogBUS.InsertUpdateLog(actionLog);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                result.ResponseItem.Message = ex.Message;
            }

            return result;
        }

        public async static Task<SYS_tblUserDRO> ChangeUserPassword(string username, string language_id, string password, SYS_tblActionLogDTO actionLog)
        {
            SYS_tblUserDRO result = new SYS_tblUserDRO();
            try
            {
                string url = string.Format(@"{0}/ChangeUserPassword?Username={1}&LanguageID={2}&Password={3}", GetBaseUrl(), username, language_id, password);

                result = await SYS_tblUserDAO.ChangeUserPassword(url);
                if (string.IsNullOrEmpty(result.ResponseItem.Message)) result.ResponseItem = await SYS_tblActionLogBUS.InsertUpdateLog(actionLog);
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

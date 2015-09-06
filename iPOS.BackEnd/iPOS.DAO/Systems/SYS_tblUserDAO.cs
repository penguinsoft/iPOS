using System;
using System.Collections.Generic;
using System.Data;
using iPOS.Core.Helper;
using iPOS.DTO.Systems;

namespace iPOS.DAO.Systems
{
    public interface ISYS_tblUserDAO
    {
        SYS_tblUserDTO CheckLogin(string username, string password, string language);

        List<SYS_tblUserDTO> LoadAllData(string username, string language_id);

        SYS_tblUserDTO GetDataByID(string username_other, string username, string language_id);

        string InsertUser(SYS_tblUserDTO item);

        string UpdateUser(SYS_tblUserDTO item);

        string DeleteUser(string username_other, string username, string language_id);

        string DeleteUserList(string username_other, string username, string language_id);

        string ChangeUserPassword(string username, string language_id, string password);
    }

    public class SYS_tblUserDAO : BaseDAO, ISYS_tblUserDAO
    {
        public SYS_tblUserDTO CheckLogin(string username, string password, string language)
        {
            DataRow dr = db.GetDataRow("SYS_spfrmUser", new string[] { "Activity", "Username", "LanguageID", "Password" }, new object[] { "CheckLogin", username, language, password });
            if (dr != null)
                return new SYS_tblUserDTO
                {
                    Username = dr["Username"] + "",
                    Password = dr["Password"] + "",
                    GroupID = Convert.ToInt32(dr["GroupID"]),
                    EffectiveDate = Convert.ToDateTime(dr["EffectiveDate"]),
                    ToDate = dr["ToDate"] == DBNull.Value ? (DateTime?)null : (DateTime)dr["ToDate"],
                    DateChangePass = dr["DateChangePass"] == DBNull.Value ? (DateTime?)null : (DateTime)dr["DateChangePass"],
                    Locked = Convert.ToBoolean(dr["Locked"]),
                    LockDate = dr["LockDate"] == DBNull.Value ? (DateTime?)null : (DateTime)dr["LockDate"],
                    UnlockDate = dr["UnlockDate"] == DBNull.Value ? (DateTime?)null : (DateTime)dr["UnlockDate"],
                    PassNeverExpired = Convert.ToBoolean(dr["PassNeverExpired"]),
                    ChangePassNextTime = Convert.ToBoolean(dr["ChangePassNextTime"]),
                    Creater = dr["Creater"] + "",
                    CreateTime = Convert.ToDateTime(dr["CreateTime"]),
                    Editer = dr["Editer"] + "",
                    EditTime = dr["EditTime"] == DBNull.Value ? (DateTime?)null : (DateTime)dr["EditTime"],
                    EmpID = dr["EmpID"] + "",
                    Visible = Convert.ToBoolean(dr["Visible"]),
                    FullName = dr["FullName"] + "",
                    IsSystemAdmin = Convert.ToBoolean(dr["IsSystemAdmin"]),
                    CanNotChangePassword = Convert.ToBoolean(dr["CanNotChangePassword"]),
                    Email = dr["Email"] + "",
                    Note = dr["Note"] + "",
                    GroupName = dr["GroupName"] + "",
                    Activity = "CheckLogin",
                    UserID = username,
                    LanguageID = language
                };

            return null;
        }

        public List<SYS_tblUserDTO> LoadAllData(string username, string language_id)
        {
            List<SYS_tblUserDTO> result = new List<SYS_tblUserDTO>();
            try
            {
                DataTable data = db.GetDataTable("SYS_spfrmUser", new string[] { "Activity", "Username", "LanguageID" }, new object[] { BaseConstant.COMMAND_LOAD_ALL_DATA_EN, username, language_id });
                if (data != null && data.Rows.Count > 0)
                {
                    result = ConvertEngine.ConvertDataTableToObjectList<SYS_tblUserDTO>(data);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }

        public SYS_tblUserDTO GetDataByID(string username_other, string username, string language_id)
        {
            SYS_tblUserDTO result = new SYS_tblUserDTO();
            try
            {
                DataTable data = db.GetDataTable("SYS_spfrmUser", new string[] { "Activity", "Username", "LanguageID", "UsernameOther" }, new object[] { BaseConstant.COMMAND_GET_DATA_BY_ID_EN, username, language_id, username_other });
                if (data != null && data.Rows.Count > 0)
                {
                    result = ConvertEngine.ConvertDataTableToObjectList<SYS_tblUserDTO>(data)[0];
                    return result;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }

        public string InsertUser(SYS_tblUserDTO item)
        {
            string strError = "";
            try
            {
                strError = db.sExecuteSQL("SYS_spfrmUser", new string[] { "Activity", "Username", "LanguageID", "UsernameOther", "Password", "GroupID", "EffectiveDate", "ToDate", "DateChangePass", "Locked", "LockDate", "UnlockDate", "PassNeverExpired", "ChangePassNextTime", "EmpID", "FullName", "CanNotChangePassword", "Email", "Note" }, new object[] { item.Activity, item.UserID, item.LanguageID, item.Username, item.Password, item.GroupID, item.EffectiveDate, item.ToDate, item.DateChangePass, item.Locked, item.LockDate, item.UnlockDate, item.PassNeverExpired, item.ChangePassNextTime, item.EmpID, item.FullName, item.CanNotChangePassword, item.Email, item.Note });

                if (!string.IsNullOrEmpty(strError))
                    logger.Error(strError);

                return strError;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                strError = ex.Message;
            }

            return strError;
        }

        public string UpdateUser(SYS_tblUserDTO item)
        {
            string strError = "";
            try
            {
                strError = db.sExecuteSQL("SYS_spfrmUser", new string[] { "Activity", "Username", "LanguageID", "UsernameOther", "Password", "GroupID", "EffectiveDate", "ToDate", "DateChangePass", "Locked", "LockDate", "UnlockDate", "PassNeverExpired", "ChangePassNextTime", "EmpID", "FullName", "CanNotChangePassword", "Email", "Note" }, new object[] { item.Activity, item.UserID, item.LanguageID, item.Username, item.Password, item.GroupID, item.EffectiveDate, item.ToDate, item.DateChangePass, item.Locked, item.LockDate, item.UnlockDate, item.PassNeverExpired, item.ChangePassNextTime, item.EmpID, item.FullName, item.CanNotChangePassword, item.Email, item.Note });

                if (!string.IsNullOrEmpty(strError))
                    logger.Error(strError);

                return strError;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                strError = ex.Message;
            }

            return strError;
        }

        public string DeleteUser(string username_other, string username, string language_id)
        {
            string strError = "";
            try
            {
                strError = db.sExecuteSQL("SYS_spfrmUser", new string[] { "Activity", "Username", "LanguageID", "UsernameOther" }, new object[] { "Delete", username, language_id, username_other });

                if (!string.IsNullOrEmpty(strError))
                    logger.Error(strError);

                return strError;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                strError = ex.Message;
            }

            return strError;
        }

        public string DeleteUserList(string username_other, string username, string language_id)
        {
            string strError = "";
            try
            {
                strError = db.sExecuteSQL("SYS_spfrmUser", new string[] { "Activity", "Username", "LanguageID", "UsernameList" }, new object[] { "DeleteList", username, language_id, username_other });

                if (!string.IsNullOrEmpty(strError))
                    logger.Error(strError);

                return strError;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                strError = ex.Message;
            }

            return strError;
        }

        public string ChangeUserPassword(string username, string language_id, string password)
        {
            string strError = "";
            try
            {
                strError = db.sExecuteSQL("SYS_spfrmUser", new string[] { "Activity", "Username", "LanguageID", "Password" }, new object[] { "ChangePassword", username, language_id, password });
                
                if (!string.IsNullOrEmpty(strError))
                    logger.Error(strError);

                return strError;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                strError = ex.Message;
            }

            return strError;
        }
    }
}

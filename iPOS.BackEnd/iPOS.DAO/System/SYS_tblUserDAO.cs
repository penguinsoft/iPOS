using System;
using System.Data;
using iPOS.DTO.System;

namespace iPOS.DAO.System
{
    public interface ISYS_tblUserDAO
    {
        SYS_tblUserDTO CheckLogin(string username, string password, string language);
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
                    GroupID = dr["GroupID"] + "",
                    EffectiveDate = Convert.ToDateTime(dr["EffectiveDate"]),
                    ToDate = (!string.IsNullOrEmpty(dr["ToDate"] + "")) ? Convert.ToDateTime(dr["ToDate"]) + "" : null,
                    DateChangePass = (!string.IsNullOrEmpty(dr["DateChangePass"] + "")) ? Convert.ToDateTime(dr["DateChangePass"]) + "" : null,
                    Locked = Convert.ToBoolean(dr["Locked"]),
                    LockDate = (!string.IsNullOrEmpty(dr["LockDate"] + "")) ? Convert.ToDateTime(dr["LockDate"]) + "" : null,
                    UnlockDate = (!string.IsNullOrEmpty(dr["UnlockDate"] + "")) ? Convert.ToDateTime(dr["UnlockDate"]) + "" : null,
                    PassNeverExpired = Convert.ToBoolean(dr["PassNeverExpired"]),
                    ChangePassNextTime = Convert.ToBoolean(dr["ChangePassNextTime"]),
                    Creater = dr["Creater"] + "",
                    CreateTime = Convert.ToDateTime(dr["CreateTime"]),
                    Editer = dr["Editer"] + "",
                    EditTime = (!string.IsNullOrEmpty(dr["EditTime"] + "")) ? Convert.ToDateTime(dr["EditTime"]) + "" : null,
                    EmpID = dr["EmpID"] + "",
                    Visible = Convert.ToBoolean(dr["Visible"]),
                    FullName = dr["FullName"] + "",
                    IsSystemAdmin = Convert.ToBoolean(dr["IsSystemAdmin"]),
                    CanNotChangePassword = Convert.ToBoolean(dr["CanNotChangePassword"]),
                    Email = dr["Email"] + "",
                    Note = dr["Note"] + "",
                    GroupName = dr["GroupName"] + "",
                    Activity = "CheckLogin",
                    UserName = username,
                    LanguageID = language
                };

            return null;
        }
    }
}

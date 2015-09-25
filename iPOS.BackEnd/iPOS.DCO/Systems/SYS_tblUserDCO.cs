using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace iPOS.DCO.Systems
{
    [DataContract]
    public class SYS_tblUserDCO
    {
        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public Int32 GroupID { get; set; }

        [DataMember]
        public System.Nullable<DateTime> EffectiveDate { get; set; }

        [DataMember]
        public System.Nullable<DateTime> ToDate { get; set; }

        [DataMember]
        public System.Nullable<DateTime> DateChangePass { get; set; }

        [DataMember]
        public bool Locked { get; set; }

        [DataMember]
        public System.Nullable<DateTime> LockDate { get; set; }

        [DataMember]
        public System.Nullable<DateTime> UnlockDate { get; set; }

        [DataMember]
        public bool PassNeverExpired { get; set; }

        [DataMember]
        public bool ChangePassNextTime { get; set; }

        [DataMember]
        public string EmpID { get; set; }

        [DataMember]
        public string FullName { get; set; }

        [DataMember]
        public bool IsSystemAdmin { get; set; }

        [DataMember]
        public bool CanNotChangePassword { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Note { get; set; }

        [DataMember]
        public string Activity { get; set; }

        [DataMember]
        public string UserID { get; set; }

        [DataMember]
        public string LanguageID { get; set; }

        [DataMember]
        public bool Visible { get; set; }

        [DataMember]
        public string Creater { get; set; }

        [DataMember]
        public System.Nullable<DateTime> CreateTime { get; set; }

        [DataMember]
        public string Editer { get; set; }

        [DataMember]
        public System.Nullable<DateTime> EditTime { get; set; }

        [DataMember]
        public string GroupName { get; set; }
    }

    [DataContract]
    public class SYS_tblUserDRO : BaseDRO
    {
        [DataMember]
        public List<SYS_tblUserDCO> UserList { get; set; }

        [DataMember]
        public SYS_tblUserDCO UserItem { get; set; }
    }
}

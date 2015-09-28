using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using iPOS.DTO.Systems;

namespace iPOS.DRO.Systems
{
    public class SYS_tblUserDRO : BaseDRO
    {
        public List<SYS_tblUserDTO> UserList { get; set; }

        public SYS_tblUserDTO UserItem { get; set; }

        public SYS_tblUserDRO()
        {
            ResponseItem = new ResponseItem();
        }
    }

    [DataContract]
    public class SYS_tblUserDCO
    {
        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string GroupID { get; set; }

        [DataMember]
        public DateTime EffectiveDate { get; set; }

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
        public string GroupName { get; set; }

        [DataMember]
        public string Activity { get; set; }

        [DataMember]
        public string UserID { get; set; }

        [DataMember]
        public string LanguageID { get; set; }
    }
}

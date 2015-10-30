using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace iPOS.DCO.Systems
{
    [DataContract]
    public class SYS_tblUserDCO
    {
        [DataMember(Order = 1)]
        public string Username { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public string Password { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public Int32 GroupID { get; set; }

        [DataMember(Order = 4, EmitDefaultValue = false)]
        public System.Nullable<DateTime> EffectiveDate { get; set; }

        [DataMember(Order = 5, EmitDefaultValue = false)]
        public System.Nullable<DateTime> ToDate { get; set; }

        [DataMember(Order = 6, EmitDefaultValue = false)]
        public System.Nullable<DateTime> DateChangePass { get; set; }

        [DataMember(Order = 7, EmitDefaultValue = false)]
        public bool Locked { get; set; }

        [DataMember(Order = 8, EmitDefaultValue = false)]
        public System.Nullable<DateTime> LockDate { get; set; }

        [DataMember(Order = 9, EmitDefaultValue = false)]
        public System.Nullable<DateTime> UnlockDate { get; set; }

        [DataMember(Order = 10, EmitDefaultValue = false)]
        public bool PassNeverExpired { get; set; }

        [DataMember(Order = 11, EmitDefaultValue = false)]
        public bool ChangePassNextTime { get; set; }

        [DataMember(Order = 12, EmitDefaultValue = false)]
        public string EmpID { get; set; }

        [DataMember(Order = 13, EmitDefaultValue = false)]
        public string FullName { get; set; }

        [DataMember(Order = 14, EmitDefaultValue = false)]
        public bool IsSystemAdmin { get; set; }

        [DataMember(Order = 15, EmitDefaultValue = false)]
        public bool CanNotChangePassword { get; set; }

        [DataMember(Order = 16, EmitDefaultValue = false)]
        public string Email { get; set; }

        [DataMember(Order = 17, EmitDefaultValue = false)]
        public string Note { get; set; }

        [DataMember(Order = 18, EmitDefaultValue = false)]
        public string Activity { get; set; }

        [DataMember(Order = 19, EmitDefaultValue = false)]
        public string UserID { get; set; }

        [DataMember(Order = 20, EmitDefaultValue = false)]
        public string LanguageID { get; set; }

        [DataMember(Order = 21, EmitDefaultValue = false)]
        public bool Visible { get; set; }

        [DataMember(Order = 22, EmitDefaultValue = false)]
        public string Creater { get; set; }

        [DataMember(Order = 23, EmitDefaultValue = false)]
        public System.Nullable<DateTime> CreateTime { get; set; }

        [DataMember(Order = 24, EmitDefaultValue = false)]
        public string Editer { get; set; }

        [DataMember(Order = 25, EmitDefaultValue = false)]
        public System.Nullable<DateTime> EditTime { get; set; }

        [DataMember(Order = 26, EmitDefaultValue = false)]
        public string GroupName { get; set; }
    }

    [DataContract]
    public class SYS_tblUserDRO : BaseDRO
    {
        [DataMember(EmitDefaultValue = false)]
        public List<SYS_tblUserDCO> UserList { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public SYS_tblUserDCO UserItem { get; set; }
    }
}

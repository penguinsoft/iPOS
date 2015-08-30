using System;

namespace iPOS.DTO.Systems
{
    public class SYS_tblUserDTO : BaseDTO
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string GroupID { get; set; }

        public DateTime EffectiveDate { get; set; }

        public System.Nullable<DateTime> ToDate { get; set; }

        public System.Nullable<DateTime> DateChangePass { get; set; }

        public bool Locked { get; set; }

        public System.Nullable<DateTime> LockDate { get; set; }

        public System.Nullable<DateTime> UnlockDate { get; set; }

        public bool PassNeverExpired { get; set; }

        public bool ChangePassNextTime { get; set; }

        public string EmpID { get; set; }

        public string FullName { get; set; }

        public bool IsSystemAdmin { get; set; }

        public bool CanNotChangePassword { get; set; }

        public string Email { get; set; }

        public string Note { get; set; }

        public string GroupName { get; set; }
    }
}

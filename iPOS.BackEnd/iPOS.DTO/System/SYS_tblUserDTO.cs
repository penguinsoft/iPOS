﻿using System;

namespace iPOS.DTO.System
{
    public class SYS_tblUserDTO
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string GroupID { get; set; }

        public DateTime EffectiveDate { get; set; }

        public object ToDate { get; set; }

        public object DateChangePass { get; set; }

        public bool Locked { get; set; }

        public object LockDate { get; set; }

        public object UnlockDate { get; set; }

        public bool PassNeverExpired { get; set; }

        public bool ChangePassNextTime { get; set; }

        public string EmpID { get; set; }

        public string FullName { get; set; }

        public bool IsSystemAdmin { get; set; }

        public bool CanNotChangePassword { get; set; }

        public string Email { get; set; }

        public string Note { get; set; }

        public string Activity { get; set; }

        public string Username { get; set; }

        public string LanguageID { get; set; }

        public bool Visible { get; set; }

        public string Creater { get; set; }

        public DateTime CreateTime { get; set; }

        public string Editer { get; set; }

        public object EditTime { get; set; }

        public string GroupName { get; set; }
    }
}

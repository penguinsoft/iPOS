﻿using System;

namespace iPOS.DTO.Systems
{
    public class SYS_tblGroupUserDTO
    {
        public Int32 GroupID { get; set; }

        public string GroupCode { get; set; }

        public string GroupName { get; set; }

        public string VNName { get; set; }

        public string ENName { get; set; }

        public string Note { get; set; }

        public bool Active { get; set; }

        public bool IsDefault { get; set; }

        public bool IsRoot { get; set; }

        public string Activity { get; set; }

        public string UserID { get; set; }

        public string LanguageID { get; set; }

        public bool Visible { get; set; }

        public string Creater { get; set; }

        public DateTime CreateTime { get; set; }

        public string Editer { get; set; }

        public System.Nullable<DateTime> EditTime { get; set; }
    }
}

﻿using System;

namespace iPOS.DTO
{
    public class BaseDTO
    {
        //public SYS_tblActionLogDTO Log { get; set; }

        public string Activity { get; set; }

        public string Username { get; set; }

        public string LanguageID { get; set; }

        public bool Visible { get; set; }

        public string Creater { get; set; }

        public DateTime CreateTime { get; set; }

        public string Editer { get; set; }

        public DateTime EditTime { get; set; }
    }
}

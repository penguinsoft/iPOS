using System;

namespace iPOS.DTO
{
    public class BaseDTO
    {
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

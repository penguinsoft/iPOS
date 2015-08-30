using System;

namespace iPOS.DTO.Systems
{
    public class SYS_tblActionLogDTO
    {
        public string ID { get; set; }

        public string FullName { get; set; }

        public string ComputerName { get; set; }

        public string AccountWindows { get; set; }

        public string ActionVN { get; set; }

        public string ActionEN { get; set; }

        public DateTime ActionTime { get; set; }

        public string FunctionID { get; set; }

        public string FunctionNameVN { get; set; }

        public string FunctionNameEN { get; set; }

        public string IPLAN { get; set; }

        public string IPWAN { get; set; }

        public string MacAddress { get; set; }

        public string DescriptionVN { get; set; }

        public string DescriptionEN { get; set; }

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

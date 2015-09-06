using System;

namespace iPOS.DTO.Products
{
    public class PRO_tblProvinceDTO
    {
        public Int32 ProvinceID { get; set; }

        public string ProvinceCode { get; set; }

        public string VNName { get; set; }

        public string ENName { get; set; }

        public System.Nullable<Int32> Rank { get; set; }

        public bool Used { get; set; }

        public string Note { get; set; }

        public string Activity { get; set; }

        public string UserID { get; set; }

        public string LanguageID { get; set; }

        public bool Visible { get; set; }

        public string Creater { get; set; }

        public System.Nullable<DateTime> CreateTime { get; set; }

        public string Editer { get; set; }

        public System.Nullable<DateTime> EditTime { get; set; }

        public string ProvinceName { get; set; }
    }
}

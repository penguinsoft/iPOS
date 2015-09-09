using System;

namespace iPOS.DTO.Products
{
    public class PRO_tblDistrictDTO
    {
        public string DistrictID { get; set; }

        public string DistrictCode { get; set; }

        public string ProvinceID { get; set; }

        public string VNName { get; set; }

        public string ENName { get; set; }

        public System.Nullable<Int32> Rank { get; set; }

        public bool Used { get; set; }

        public string Note { get; set; }

        public bool Visible { get; set; }

        public string Creater { get; set; }

        public System.Nullable<DateTime> CreateTime { get; set; }

        public string Editer { get; set; }

        public System.Nullable<DateTime> EditTime { get; set; }

        public string Activity { get; set; }

        public string UserID { get; set; }

        public string LanguageID { get; set; }

        public string ActiveString
        {
            get
            {
                if (Used)
                    return "X";
                else return "";
            }
        }
    }
}

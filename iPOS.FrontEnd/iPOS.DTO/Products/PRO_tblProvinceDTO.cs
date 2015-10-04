using System;

namespace iPOS.DTO.Products
{
    public class PRO_tblProvinceDTO : BaseDTO
    {
        public string ProvinceID { get; set; }

        public string ProvinceCode { get; set; }

        public string VNName { get; set; }

        public string ENName { get; set; }

        public System.Nullable<Int32> Rank { get; set; }

        public bool Used { get; set; }

        public string Note { get; set; }

        public string ProvinceName { get; set; }

        public string FullProvinceName { get; set; }

        public string ActiveString
        {
            get
            {
                if (Used) return "X"; else return "";
            }
        }
    }
}

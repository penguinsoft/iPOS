using System;

namespace iPOS.DTO.Products
{
    public class PRO_tblStoreDTO
    {
        public string StoreID { get; set; }

        public string StoreCode { get; set; }

        public string ShortCode { get; set; }

        public string VNName { get; set; }

        public string ENName { get; set; }

        public string StoreName { get; set; }

        public string FullStoreName { get; set; }

        public System.Nullable<DateTime> BuildDate { get; set; }

        public System.Nullable<DateTime> EndDate { get; set; }

        public string AddressVN { get; set; }

        public string AddressEN { get; set; }

        public string StoreAddress { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public string TaxCode { get; set; }

        public System.Nullable<Int32> Rank { get; set; }

        public bool Used { get; set; }

        public bool IsRoot { get; set; }

        public string Representatives { get; set; }

        public string Note { get; set; }

        public string Photo { get; set; }

        public string PhotoUri
        {
            get
            {
                return iPOS.Core.Helper.ConfigEngine.ServerUri(false) + Photo.Replace("\\", "//");
            }
        }

        public string ProvinceID { get; set; }

        public string DistrictID { get; set; }

        public bool Visible { get; set; }

        public string Creater { get; set; }

        public System.Nullable<DateTime> CreateTime { get; set; }

        public string Editer { get; set; }

        public System.Nullable<DateTime> EditTime { get; set; }

        public string Activity { get; set; }

        public string UserID { get; set; }

        public string LanguageID { get; set; }

        public string ProvinceName { get; set; }

        public string DistrictName { get; set; }

        public string IsRootString
        {
            get
            {
                if (IsRoot) return "X"; else return "";
            }
        }

        public string UsedString
        {
            get
            {
                if (Used) return "X"; else return "";
            }
        }
    }
}

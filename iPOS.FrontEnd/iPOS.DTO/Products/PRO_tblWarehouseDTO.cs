using System;

namespace iPOS.DTO.Products
{
    public class PRO_tblWarehouseDTO
    {
        public string WarehouseID { get; set; }

        public string WarehouseCode { get; set; }

        public string VNName { get; set; }

        public string ENName { get; set; }

        public string WarehouseName { get; set; }

        public string FullWarehouseName { get; set; }

        public string AddressVN { get; set; }

        public string AddressEN { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public System.Nullable<Int32> Rank { get; set; }

        public bool Used { get; set; }

        public string Note { get; set; }

        public bool Visible { get; set; }

        public string StoreID { get; set; }

        public string ProvinceID { get; set; }

        public string DistrictID { get; set; }

        public string Creater { get; set; }

        public System.Nullable<DateTime> CreateTime { get; set; }

        public string Editer { get; set; }

        public System.Nullable<DateTime> EditTime { get; set; }

        public string Activity { get; set; }

        public string UserID { get; set; }

        public string LanguageID { get; set; }

        public string UsedString
        {
            get
            {
                return Used ? "X" : "";
            }
        }

        public string StoreName { get; set; }

        public string ProvinceName { get; set; }

        public string DistrictName { get; set; }
    }
}

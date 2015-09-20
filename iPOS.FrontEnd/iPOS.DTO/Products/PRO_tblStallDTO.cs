using System;

namespace iPOS.DTO.Products
{
    public class PRO_tblStallDTO
    {
        public string StallID { get; set; }

        public string StallCode { get; set; }

        public string VNName { get; set; }

        public string ENName { get; set; }

        public string StallName { get; set; }

        public string FullStallName { get; set; }

        public System.Nullable<Int32> Rank { get; set; }

        public bool Used { get; set; }

        public string Note { get; set; }

        public string StoreID { get; set; }

        public string WarehouseID { get; set; }

        public bool Visible { get; set; }

        public string Creater { get; set; }

        public System.Nullable<DateTime> CreateTime { get; set; }

        public string Editer { get; set; }

        public System.Nullable<DateTime> EditTime { get; set; }

        public string Activity { get; set; }

        public string UserID { get; set; }

        public string LanguageID { get; set; }

        public string StoreName { get; set; }

        public string WarehouseName { get; set; }
    }
}

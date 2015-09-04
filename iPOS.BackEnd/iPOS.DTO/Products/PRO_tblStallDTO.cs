using System;

namespace iPOS.DTO.Products
{
    public class PRO_tblStallDTO
    {
        public Int32 StallID { get; set; }

        public string StallCode { get; set; }

        public string VNName { get; set; }

        public string ENName { get; set; }

        public System.Nullable<Int32> Rank { get; set; }

        public bool Used { get; set; }

        public string Note { get; set; }

        public Int32 StoreID { get; set; }

        public Int32 WarehouseID { get; set; }

        public bool Visible { get; set; }

        public string Creater { get; set; }

        public DateTime CreateTime { get; set; }

        public string Editer { get; set; }

        public System.Nullable<DateTime> EditTime { get; set; }

        public string Activity { get; set; }

        public string UserID { get; set; }

        public string LanguageID { get; set; }
    }
}

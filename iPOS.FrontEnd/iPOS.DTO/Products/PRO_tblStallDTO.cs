using System;

namespace iPOS.DTO.Products
{
    public class PRO_tblStallDTO : BaseDTO
    {
        public string StallID { get; set; }

        public string StallCode { get; set; }

        public string VNName { get; set; }

        public string ENName { get; set; }

        public string StallName { get; set; }

        public string FullStallName { get; set; }

        public string Rank { get; set; }

        public bool Used { get; set; }

        public string Note { get; set; }

        public string StoreID { get; set; }

        public string WarehouseID { get; set; }

        public string StoreName { get; set; }

        public string WarehouseName { get; set; }
    }
}

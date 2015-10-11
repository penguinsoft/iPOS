using System;

namespace iPOS.DTO.Products
{
    public class PRO_tblUnitDTO : BaseDTO
    {
        public Int32 UnitID { get; set; }

        public string UnitCode { get; set; }

        public string VNName { get; set; }

        public string ENName { get; set; }

        public System.Nullable<Int32> Rank { get; set; }

        public bool Used { get; set; }

        public string Note { get; set; }

        public System.Nullable<Int32> UnitTypeID { get; set; }

        public string UnitName { get; set; }

        public string FullUnitName { get; set; }

        public string UnitTypeName { get; set; }
    }
}

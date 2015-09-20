using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using iPOS.DTO.Products;

namespace iPOS.DRO.Products
{
    public class PRO_tblWarehouseDRO : BaseDRO
    {
        public List<PRO_tblWarehouseDTO> WarehouseList { get; set; }

        public PRO_tblWarehouseDTO WarehouseItem { get; set; }
    }

    [DataContract]
    public class PRO_tblWarehouseDCO
    {
        [DataMember]
        public string WarehouseID { get; set; }

        [DataMember]
        public string WarehouseCode { get; set; }

        [DataMember]
        public string VNName { get; set; }

        [DataMember]
        public string ENName { get; set; }

        [DataMember]
        public string WarehouseName { get; set; }

        [DataMember]
        public string FullWarehouseName { get; set; }

        [DataMember]
        public string AddressVN { get; set; }

        [DataMember]
        public string AddressEN { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public string Fax { get; set; }

        [DataMember]
        public System.Nullable<Int32> Rank { get; set; }

        [DataMember]
        public bool Used { get; set; }

        [DataMember]
        public string Note { get; set; }

        [DataMember]
        public bool Visible { get; set; }

        [DataMember]
        public string StoreID { get; set; }

        [DataMember]
        public string ProvinceID { get; set; }

        [DataMember]
        public string DistrictID { get; set; }

        [DataMember]
        public string Creater { get; set; }

        [DataMember]
        public System.Nullable<DateTime> CreateTime { get; set; }

        [DataMember]
        public string Editer { get; set; }

        [DataMember]
        public System.Nullable<DateTime> EditTime { get; set; }

        [DataMember]
        public string Activity { get; set; }

        [DataMember]
        public string UserID { get; set; }

        [DataMember]
        public string LanguageID { get; set; }
    }
}

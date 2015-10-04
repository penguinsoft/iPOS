using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using iPOS.DTO.Products;

namespace iPOS.DRO.Products
{
    public class PRO_tblStallDRO : BaseDRO
    {
        public List<PRO_tblStallDTO> StallList { get; set; }

        public PRO_tblStallDTO StallItem { get; set; }

        public PRO_tblStallDRO()
        {
            ResponseItem = new ResponseItem();
        }
    }

    [DataContract]
    public class PRO_tblStallDCO
    {
        [DataMember]
        public string StallID { get; set; }

        [DataMember]
        public string StallCode { get; set; }

        [DataMember]
        public string VNName { get; set; }

        [DataMember]
        public string ENName { get; set; }

        [DataMember]
        public string StallName { get; set; }

        [DataMember]
        public string FullStallName { get; set; }

        [DataMember]
        public string Rank { get; set; }

        [DataMember]
        public bool Used { get; set; }

        [DataMember]
        public string Note { get; set; }

        [DataMember]
        public string StoreID { get; set; }

        [DataMember]
        public string WarehouseID { get; set; }

        [DataMember]
        public bool Visible { get; set; }

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

        [DataMember]
        public string StoreName { get; set; }

        [DataMember]
        public string WarehouseName { get; set; }
    }
}

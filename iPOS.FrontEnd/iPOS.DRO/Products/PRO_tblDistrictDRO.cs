using System;
using System.Collections.Generic;
using iPOS.DTO.Products;
using System.Runtime.Serialization;

namespace iPOS.DRO.Products
{
    public class PRO_tblDistrictDRO : BaseDRO
    {
        public List<PRO_tblDistrictDTO> DistrictList { get; set; }

        public PRO_tblDistrictDTO DistrictItem { get; set; }
    }

    [DataContract]
    public class PRO_tblDistrictDCO
    {
        [DataMember]
        public string DistrictID { get; set; }

        [DataMember]
        public string DistrictCode { get; set; }

        [DataMember]
        public string ProvinceID { get; set; }

        [DataMember]
        public string VNName { get; set; }

        [DataMember]
        public string ENName { get; set; }

        [DataMember]
        public System.Nullable<Int32> Rank { get; set; }

        [DataMember]
        public bool Used { get; set; }

        [DataMember]
        public string Note { get; set; }

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
    }
}

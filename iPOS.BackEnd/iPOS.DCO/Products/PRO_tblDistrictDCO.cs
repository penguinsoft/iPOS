﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace iPOS.DCO.Products
{
    [DataContract]
    public class PRO_tblDistrictDCO
    {
        [DataMember]
        public Int32 DistrictID { get; set; }

        [DataMember]
        public string DistrictCode { get; set; }

        [DataMember]
        public Int32 ProvinceID { get; set; }

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

    [DataContract]
    public class PRO_tblDistrictDRO : BaseDRO
    {
        [DataMember]
        public List<PRO_tblDistrictDCO> DistrictList { get; set; }

        [DataMember]
        public PRO_tblDistrictDCO DistrictItem { get; set; } 
    }
}

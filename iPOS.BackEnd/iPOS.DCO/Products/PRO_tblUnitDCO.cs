using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace iPOS.DCO.Products
{
    [DataContract]
    public class PRO_tblUnitDCO
    {
        [DataMember]
        public Int32 UnitID { get; set; }

        [DataMember]
        public string UnitCode { get; set; }

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
        public System.Nullable<Int32> UnitTypeID { get; set; }

        [DataMember]
        public string Activity { get; set; }

        [DataMember]
        public string UserID { get; set; }

        [DataMember]
        public string LanguageID { get; set; }

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
        public string UnitName { get; set; }

        [DataMember]
        public string FullUnitName { get; set; }

        [DataMember]
        public string UnitTypeName { get; set; }
    }

    [DataContract]
    public class PRO_tblUnitDRO : BaseDRO
    {
        [DataMember]
        public List<PRO_tblDistrictDCO> UnitList { get; set; }

        [DataMember]
        public PRO_tblDistrictDCO UnitItem { get; set; }
    }
}

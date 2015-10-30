using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace iPOS.DCO.Products
{
    [DataContract]
    public class PRO_tblDistrictDCO
    {
        [DataMember(Order = 1)]
        public Int32 DistrictID { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public string DistrictCode { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public Int32 ProvinceID { get; set; }

        [DataMember(Order = 4, EmitDefaultValue = false)]
        public string VNName { get; set; }

        [DataMember(Order = 5, EmitDefaultValue = false)]
        public string ENName { get; set; }

        [DataMember(Order = 6, EmitDefaultValue = false)]
        public string DistrictName { get; set; }

        [DataMember(Order = 7, EmitDefaultValue = false)]
        public string FullDistrictName { get; set; }

        [DataMember(Order = 8, EmitDefaultValue = false)]
        public string ProvinceName { get; set; }

        [DataMember(Order = 9, EmitDefaultValue = false)]
        public System.Nullable<Int32> Rank { get; set; }

        [DataMember(Order = 10, EmitDefaultValue = false)]
        public bool Used { get; set; }

        [DataMember(Order = 11, EmitDefaultValue = false)]
        public string Note { get; set; }

        [DataMember(Order = 12, EmitDefaultValue = false)]
        public bool Visible { get; set; }

        [DataMember(Order = 13, EmitDefaultValue = false)]
        public string Creater { get; set; }

        [DataMember(Order = 14, EmitDefaultValue = false)]
        public System.Nullable<DateTime> CreateTime { get; set; }

        [DataMember(Order = 15, EmitDefaultValue = false)]
        public string Editer { get; set; }

        [DataMember(Order = 16, EmitDefaultValue = false)]
        public System.Nullable<DateTime> EditTime { get; set; }

        [DataMember(Order = 17, EmitDefaultValue = false)]
        public string Activity { get; set; }

        [DataMember(Order = 18, EmitDefaultValue = false)]
        public string UserID { get; set; }

        [DataMember(Order = 19, EmitDefaultValue = false)]
        public string LanguageID { get; set; }
    }

    [DataContract]
    public class PRO_tblDistrictDRO : BaseDRO
    {
        [DataMember(EmitDefaultValue = false)]
        public List<PRO_tblDistrictDCO> DistrictList { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public PRO_tblDistrictDCO DistrictItem { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace iPOS.DCO.Products
{
    [DataContract]
    public class PRO_tblProductGroupLevel2DCO
    {
        [DataMember]
        public Int32 Level2ID { get; set; }

        [DataMember]
        public string Level2Code { get; set; }

        [DataMember]
        public string Level2ShortCode { get; set; }

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
        public string Description { get; set; }

        [DataMember]
        public System.Nullable<Int32> Level1ID { get; set; }

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
        public string Level2Name { get; set; }

        [DataMember]
        public string FullLevel2Name { get; set; }

        [DataMember]
        public string Level1Name { get; set; }
    }

    [DataContract]
    public class PRO_tblProductGroupLevel2DRO : BaseDRO
    {
        [DataMember]
        public List<PRO_tblProductGroupLevel2DCO> Level2List { get; set; }

        [DataMember]
        public PRO_tblProductGroupLevel2DCO Level2Item { get; set; }
    }
}

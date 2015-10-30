using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace iPOS.DCO.Products
{
    [DataContract]
    public class PRO_tblProductGroupLevel1DCO
    {
        [DataMember(Order = 1)]
        public Int32 Level1ID { get; set; }

        [DataMember]
        public string Level1Code { get; set; }

        [DataMember]
        public string Level1ShortCode { get; set; }

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
        public string Level1Name { get; set; }

        [DataMember]
        public string FullLevel1Name { get; set; }
    }

    [DataContract]
    public class PRO_tblProductGroupLevel1DRO : BaseDRO
    {
        [DataMember]
        public List<PRO_tblProductGroupLevel1DCO> Level1List { get; set; }

        [DataMember]
        public PRO_tblProductGroupLevel1DCO Level1Item { get; set; }
    }
}

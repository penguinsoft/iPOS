using iPOS.DTO.Products;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace iPOS.DRO.Products
{
    public class PRO_tblLevel1DRO : BaseDRO
    {
        public List<PRO_tblLevel1DTO> Level1List { get; set; }

        public PRO_tblLevel1DTO Level1Item { get; set; }

        public PRO_tblLevel1DRO()
        {
            ResponseItem = new ResponseItem();
        }
    }

    [DataContract]
    public class PRO_tblLevel1DCO : BaseDCO
    {
        [DataMember]
        public string Level1ID { get; set; }

        [DataMember]
        public string Level1Code { get; set; }

        [DataMember]
        public string Level1ShortCode { get; set; }

        [DataMember]
        public string VNName { get; set; }

        [DataMember]
        public string ENName { get; set; }

        [DataMember]
        public string Rank { get; set; }

        [DataMember]
        public bool Used { get; set; }

        [DataMember]
        public string Note { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Level1Name { get; set; }

        [DataMember]
        public string FullLevel1Name { get; set; }
    }
}

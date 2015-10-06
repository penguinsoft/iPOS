using iPOS.DTO.Products;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace iPOS.DRO.Products
{
    public class PRO_tblLevel2DRO : BaseDRO
    {
        public List<PRO_tblLevel2DTO> Level2List { get; set; }

        public PRO_tblLevel2DTO Level2Item { get; set; }

        public PRO_tblLevel2DRO()
        {
            ResponseItem = new ResponseItem();
        }
    }

    [DataContract]
    public class PRO_tblLevel2DCO : BaseDCO
    {
        [DataMember]
        public string Level2ID { get; set; }

        [DataMember]
        public string Level2Code { get; set; }

        [DataMember]
        public string Level2ShortCode { get; set; }

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
        public string Level1ID { get; set; }

        [DataMember]
        public string Level2Name { get; set; }

        [DataMember]
        public string FullLevel2Name { get; set; }

        [DataMember]
        public string Level1Name { get; set; }
    }
}

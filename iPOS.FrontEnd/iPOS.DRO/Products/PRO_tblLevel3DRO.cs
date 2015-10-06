using iPOS.DTO.Products;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace iPOS.DRO.Products
{
    public class PRO_tblLevel3DRO : BaseDRO
    {
        public List<PRO_tblLevel3DTO> Level3List { get; set; }

        public PRO_tblLevel3DTO Level3Item { get; set; }

        public PRO_tblLevel3DRO()
        {
            ResponseItem = new ResponseItem();
        }
    }

    [DataContract]
    public class PRO_tblLevel3DCO : BaseDCO
    {
        [DataMember]
        public string Level3ID { get; set; }

        [DataMember]
        public string Level3Code { get; set; }

        [DataMember]
        public string Level3ShortCode { get; set; }

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
        public string Level2ID { get; set; }

        [DataMember]
        public string Level3Name { get; set; }

        [DataMember]
        public string FullLevel3Name { get; set; }

        [DataMember]
        public string Level1Name { get; set; }

        [DataMember]
        public string Level2Name { get; set; }
    }
}

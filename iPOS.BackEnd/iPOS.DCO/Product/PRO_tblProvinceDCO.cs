using System;
using System.Runtime.Serialization;

namespace iPOS.DCO.Product
{
    [DataContract]
    public class PRO_tblProvinceDCO //: BaseDCO
    {
        [DataMember]
        public string ProvinceID { get; set; }

        [DataMember]
        public string ProvinceCode { get; set; }

        [DataMember]
        public string VNName { get; set; }

        [DataMember]
        public string ENName { get; set; }

        [DataMember]
        public object Rank { get; set; }

        [DataMember]
        public bool Used { get; set; }

        [DataMember]
        public string Note { get; set; }
    }
}

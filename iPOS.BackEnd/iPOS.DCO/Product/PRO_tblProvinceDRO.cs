using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace iPOS.DCO.Product
{
    [DataContract]
    public class PRO_tblProvinceDRO : BaseDRO
    {
        [DataMember]
        public List<PRO_tblProvinceDCO> ProvinceList { get; set; }
    }
}

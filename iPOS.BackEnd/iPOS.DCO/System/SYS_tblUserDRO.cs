using System;
using System.Runtime.Serialization;

namespace iPOS.DCO.System
{
    [DataContract]
    public class SYS_tblUserDRO : BaseDRO
    {
        [DataMember]
        public SYS_tblUserDCO UserItem { get; set; }
    }
}

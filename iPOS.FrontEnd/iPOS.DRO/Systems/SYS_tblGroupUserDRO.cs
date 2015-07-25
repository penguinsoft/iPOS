using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using iPOS.DTO.Systems;

namespace iPOS.DRO.Systems
{
    public class SYS_tblGroupUserDRO : BaseDRO
    {
        public List<SYS_tblGroupUserDTO> GroupUserList { get; set; }

        public SYS_tblGroupUserDTO GroupUserItem { get; set; }
    }

    [DataContract]
    public class SYS_tblGroupUserDCO
    {
        [DataMember]
        public string GroupID { get; set; }

        [DataMember]
        public string GroupCode { get; set; }

        [DataMember]
        public string VNName { get; set; }

        [DataMember]
        public string ENName { get; set; }

        [DataMember]
        public string Note { get; set; }

        [DataMember]
        public bool Active { get; set; }

        [DataMember]
        public bool IsDefault { get; set; }

        [DataMember]
        public string Activity { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Language { get; set; }
    }
}

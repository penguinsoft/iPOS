using iPOS.DTO.Systems;
using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace iPOS.DRO.Systems
{
    public class SYS_tblUserLevelDRO : BaseDRO
    {
        public List<SYS_tblUserLevelDTO> UserLevelList { get; set; }

        public SYS_tblUserLevelDRO()
        {
            ResponseItem = new ResponseItem();
        }
    }

    [DataContract]
    public class SYS_tblUserLevelDCO : BaseDCO
    {
        [DataMember]
        public string UserLevelID { get; set; }

        [DataMember]
        public string VNName { get; set; }

        [DataMember]
        public string ENName { get; set; }

        [DataMember]
        public string Rank { get; set; }

        [DataMember]
        public bool Used { get; set; }

        [DataMember]
        public string UserLevelName { get; set; }
    }
}

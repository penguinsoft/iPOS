using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace iPOS.DCO.Systems
{
    [DataContract]
    public class SYS_tblUserLevelDCO
    {
        [DataMember]
        public Int32 UserLevelID { get; set; }

        [DataMember]
        public string VNName { get; set; }

        [DataMember]
        public string ENName { get; set; }

        [DataMember]
        public System.Nullable<Int32> Rank { get; set; }

        [DataMember]
        public bool Used { get; set; }

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
        public string UserLevelName { get; set; }
    }

    [DataContract]
    public class SYS_tblUserLevelDRO : BaseDRO
    {
        [DataMember]
        public List<SYS_tblUserLevelDCO> UserLevelList { get; set; }
    }
}

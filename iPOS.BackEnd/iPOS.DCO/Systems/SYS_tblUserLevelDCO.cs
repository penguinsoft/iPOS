using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace iPOS.DCO.Systems
{
    [DataContract]
    public class SYS_tblUserLevelDCO
    {
        [DataMember(Order = 1)]
        public Int32 UserLevelID { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public string VNName { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public string ENName { get; set; }

        [DataMember(Order = 4, EmitDefaultValue = false)]
        public System.Nullable<Int32> Rank { get; set; }

        [DataMember(Order = 5, EmitDefaultValue = false)]
        public bool Used { get; set; }

        [DataMember(Order = 6, EmitDefaultValue = false)]
        public bool Visible { get; set; }

        [DataMember(Order = 7, EmitDefaultValue = false)]
        public string Creater { get; set; }

        [DataMember(Order = 8, EmitDefaultValue = false)]
        public System.Nullable<DateTime> CreateTime { get; set; }

        [DataMember(Order = 9, EmitDefaultValue = false)]
        public string Editer { get; set; }

        [DataMember(Order = 10, EmitDefaultValue = false)]
        public System.Nullable<DateTime> EditTime { get; set; }

        [DataMember(Order = 11, EmitDefaultValue = false)]
        public string UserLevelName { get; set; }
    }

    [DataContract]
    public class SYS_tblUserLevelDRO : BaseDRO
    {
        [DataMember(EmitDefaultValue = false)]
        public List<SYS_tblUserLevelDCO> UserLevelList { get; set; }
    }
}

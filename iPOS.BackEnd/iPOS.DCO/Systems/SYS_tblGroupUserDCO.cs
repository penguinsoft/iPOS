using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace iPOS.DCO.Systems
{
    [DataContract]
    public class SYS_tblGroupUserDCO
    {
        [DataMember(Order = 1)]
        public Int32 GroupID { get; set; }

        [DataMember(Order = 2)]
        public string GroupCode { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public string GroupName { get; set; }

        [DataMember(Order = 4, EmitDefaultValue = false)]
        public string VNName { get; set; }

        [DataMember(Order = 5, EmitDefaultValue = false)]
        public string ENName { get; set; }

        [DataMember(Order = 6)]
        public string Note { get; set; }

        [DataMember(Order = 7)]
        public bool Active { get; set; }

        [DataMember(Order = 8)]
        public bool IsDefault { get; set; }

        [DataMember(Order = 9)]
        public bool IsRoot { get; set; }

        [DataMember(Order = 10, EmitDefaultValue = false)]
        public string Activity { get; set; }

        [DataMember(Order = 11, EmitDefaultValue = false)]
        public string UserID { get; set; }

        [DataMember(Order = 12, EmitDefaultValue = false)]
        public string LanguageID { get; set; }

        [DataMember(Order = 13, EmitDefaultValue = false)]
        public bool Visible { get; set; }

        [DataMember(Order = 14, EmitDefaultValue = false)]
        public string Creater { get; set; }

        [DataMember(Order = 15, EmitDefaultValue = false)]
        public DateTime CreateTime { get; set; }

        [DataMember(Order = 16, EmitDefaultValue = false)]
        public string Editer { get; set; }

        [DataMember(Order = 17, EmitDefaultValue = false)]
        public object EditTime { get; set; }
    }

    [DataContract]
    public class SYS_tblGroupUserDRO : BaseDRO
    {
        [DataMember(EmitDefaultValue = false)]
        public List<SYS_tblGroupUserDCO> GroupUserList { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public SYS_tblGroupUserDCO GroupUserItem { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace iPOS.DCO.System
{
    [DataContract]
    public class SYS_tblGroupUserDCO
    {
        [DataMember]
        public string GroupID { get; set; }

        [DataMember]
        public string GroupCode { get; set; }

        [DataMember]
        public string GroupName { get; set; }

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
        public bool IsRoot { get; set; }

        [DataMember]
        public string Activity { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string LanguageID { get; set; }

        [DataMember]
        public bool Visible { get; set; }

        [DataMember]
        public string Creater { get; set; }

        [DataMember]
        public DateTime CreateTime { get; set; }

        [DataMember]
        public string Editer { get; set; }

        [DataMember]
        public object EditTime { get; set; }
    }

    [DataContract]
    public class SYS_tblGroupUserDRO : BaseDRO
    {
        [DataMember]
        public List<SYS_tblGroupUserDCO> GroupUserList { get; set; }

        [DataMember]
        public SYS_tblGroupUserDCO GroupUserItem { get; set; }
    }
}

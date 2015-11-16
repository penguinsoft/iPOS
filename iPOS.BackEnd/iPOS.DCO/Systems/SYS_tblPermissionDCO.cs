using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace iPOS.DCO.Systems
{
    [DataContract]
    public class SYS_tblPermissionDCO
    {
        [DataMember]
        public string ID { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string GroupID { get; set; }

        [DataMember]
        public string FunctionID { get; set; }

        [DataMember]
        public string FunctionName { get; set; }

        [DataMember]
        public bool AllowInsert { get; set; }

        [DataMember]
        public bool AllowUpdate { get; set; }

        [DataMember]
        public bool AllowDelete { get; set; }

        [DataMember]
        public bool AllowAccess { get; set; }

        [DataMember]
        public bool AllowPrint { get; set; }

        [DataMember]
        public bool AllowImport { get; set; }

        [DataMember]
        public bool AllowExport { get; set; }

        [DataMember]
        public bool AllowAll { get; set; }

        [DataMember]
        public string UserLevelID { get; set; }

        [DataMember]
        public string Note { get; set; }

        [DataMember]
        public bool Visible { get; set; }

        [DataMember]
        public string Creater { get; set; }

        [DataMember]
        public DateTime CreateTime { get; set; }

        [DataMember]
        public string Editer { get; set; }

        [DataMember]
        public System.Nullable<DateTime> EditTime { get; set; }

        [DataMember]
        public string ParentID { get; set; }
    }

    [DataContract]
    public class SYS_tblPermissionDRO : BaseDRO
    {
        [DataMember]
        public List<SYS_tblPermissionDCO> PermissionList { get; set; }

        [DataMember]
        public SYS_tblPermissionDCO PermissionItem { get; set; }
    }
}

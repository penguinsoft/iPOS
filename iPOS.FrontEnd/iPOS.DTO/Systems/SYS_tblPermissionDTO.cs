using System;

namespace iPOS.DTO.Systems
{
    public class SYS_tblPermissionDTO
    {
        public string ID { get; set; }

        public string Username { get; set; }

        public string GroupID { get; set; }

        public string FunctionID { get; set; }

        public string FunctionName { get; set; }

        public bool AllowInsert { get; set; }

        public bool AllowUpdate { get; set; }

        public bool AllowDelete { get; set; }

        public bool AllowAccess { get; set; }

        public bool AllowPrint { get; set; }

        public bool AllowImport { get; set; }

        public bool AllowExport { get; set; }

        public bool AllowAll { get; set; }

        public string UserLevelID { get; set; }

        public string Note { get; set; }

        public bool Visible { get; set; }

        public string Creater { get; set; }

        public DateTime CreateTime { get; set; }

        public string Editer { get; set; }

        public System.Nullable<DateTime> EditTime { get; set; }

        public string UserLevelName { get; set; }
    }
}

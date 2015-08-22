using System;

namespace iPOS.DTO.Systems
{
    public class SYS_tblImportFileConfigDTO
    {
        public Int32 ImportFileConfigID { get; set; }

        public string ModuleID { get; set; }

        public string ExcelFile { get; set; }

        public string FilePath { get; set; }

        public Int32 FunctionID { get; set; }

        public string Note { get; set; }

        public bool Visible { get; set; }

        public string Creater { get; set; }

        public DateTime CreateTime { get; set; }

        public string Editer { get; set; }

        public System.Nullable<DateTime> EditTime { get; set; }
    }
}

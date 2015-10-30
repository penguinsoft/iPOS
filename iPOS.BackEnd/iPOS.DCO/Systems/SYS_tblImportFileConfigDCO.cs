using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace iPOS.DCO.Systems
{
    [DataContract]
    public class SYS_tblImportFileConfigDCO
    {
        [DataMember(Order = 1)]
        public Int32 ImportFileConfigID { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public string ModuleID { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public string ExcelFile { get; set; }

        [DataMember(Order = 4, EmitDefaultValue = false)]
        public string FilePath { get; set; }

        [DataMember(Order = 5, EmitDefaultValue = false)]
        public Int32 FunctionID { get; set; }

        [DataMember(Order = 6, EmitDefaultValue = false)]
        public string Note { get; set; }

        [DataMember(Order = 7, EmitDefaultValue = false)]
        public bool Visible { get; set; }

        [DataMember(Order = 8, EmitDefaultValue = false)]
        public string Creater { get; set; }

        [DataMember(Order = 9, EmitDefaultValue = false)]
        public DateTime CreateTime { get; set; }

        [DataMember(Order = 10, EmitDefaultValue = false)]
        public string Editer { get; set; }

        [DataMember(Order = 11, EmitDefaultValue = false)]
        public System.Nullable<DateTime> EditTime { get; set; }
    }

    [DataContract]
    public class SYS_tblImportFileConfigDRO : BaseDRO
    {
        [DataMember(EmitDefaultValue = false)]
        public SYS_tblImportFileConfigDCO ImportFileConfigItem { get; set; }
    }
}

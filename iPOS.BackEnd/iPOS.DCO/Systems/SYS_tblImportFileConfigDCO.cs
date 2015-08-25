﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace iPOS.DCO.Systems
{
    [DataContract]
    public class SYS_tblImportFileConfigDCO
    {
        [DataMember]
        public Int32 ImportFileConfigID { get; set; }

        [DataMember]
        public string ModuleID { get; set; }

        [DataMember]
        public string ExcelFile { get; set; }

        [DataMember]
        public string FilePath { get; set; }

        [DataMember]
        public Int32 FunctionID { get; set; }

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
    }

    [DataContract]
    public class SYS_tblImportFileConfigDRO : BaseDRO
    {
        [DataMember]
        public SYS_tblImportFileConfigDCO ImportFileConfigItem { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;

namespace iPOS.DCO.Systems
{
    [DataContract]
    public class SYS_tblReportCaptionDCO
    {
        [DataMember]
        public Int32 ID { get; set; }

        [DataMember]
        public Int32 FunctionID { get; set; }

        [DataMember]
        public string ControlID { get; set; }

        [DataMember]
        public string CaptionVN { get; set; }

        [DataMember]
        public string CaptionEN { get; set; }

        [DataMember]
        public string Caption { get; set; }

        [DataMember]
        public string Note { get; set; }

        [DataMember]
        public bool IsImport { get; set; }

        [DataMember]
        public bool IsRequire { get; set; }

        [DataMember]
        public bool IsList { get; set; }

        [DataMember]
        public string DataType { get; set; }

        [DataMember]
        public string TableName { get; set; }
    }

    [DataContract]
    public class ComboDynamicItemDCO
    {
        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Name { get; set; }
    }

    [DataContract]
    public class SYS_tblReportCaptionDRO : BaseDRO
    {
        [DataMember]
        public List<SYS_tblReportCaptionDCO> ReportCaptionList { get; set; }

        [DataMember]
        public List<ComboDynamicItemDCO> ComboDynamicList { get; set; }
    }
}

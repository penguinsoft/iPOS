using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace iPOS.DCO.Systems
{
    [DataContract]
    public class SYS_tblActionLogDCO
    {
        [DataMember]
        public string ID { get; set; }

        [DataMember]
        public string FullName { get; set; }

        [DataMember]
        public string ComputerName { get; set; }

        [DataMember]
        public string AccountWindows { get; set; }

        [DataMember]
        public string ActionVN { get; set; }

        [DataMember]
        public string ActionEN { get; set; }

        [DataMember]
        public DateTime ActionTime { get; set; }

        [DataMember]
        public string FunctionID { get; set; }

        [DataMember]
        public string FunctionNameVN { get; set; }

        [DataMember]
        public string FunctionNameEN { get; set; }

        [DataMember]
        public string IPLAN { get; set; }

        [DataMember]
        public string IPWAN { get; set; }

        [DataMember]
        public string MacAddress { get; set; }

        [DataMember]
        public string DescriptionVN { get; set; }

        [DataMember]
        public string DescriptionEN { get; set; }

        [DataMember]
        public string Activity { get; set; }

        [DataMember]
        public string UserID { get; set; }

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
        public System.Nullable<DateTime> EditTime { get; set; }
    }

    [DataContract]
    public class SYS_tblActionLogDRO : BaseDRO
    {
        [DataMember]
        public List<SYS_tblActionLogDCO> ActionLogList { get; set; }
    }
}

using System;
using System.Runtime.Serialization;

namespace iPOS.DCO.Product
{
    [DataContract]
    public class PRO_tblProvinceDCO
    {
        [DataMember]
        public string ProvinceID { get; set; }

        [DataMember]
        public string ProvinceCode { get; set; }

        [DataMember]
        public string VNName { get; set; }

        [DataMember]
        public string ENName { get; set; }

        [DataMember]
        public object Rank { get; set; }

        [DataMember]
        public bool Used { get; set; }

        [DataMember]
        public string Note { get; set; }

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

        [DataMember]
        public string ProvinceName { get; set; }

        [DataMember]
        public string UsedString { get; set; }
    }
}

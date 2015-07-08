using System;
using System.Runtime.Serialization;

namespace iPOS.DCO
{
    [DataContract]
    public class BaseDCO
    {
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
        public DateTime EditTime { get; set; }
    }
}

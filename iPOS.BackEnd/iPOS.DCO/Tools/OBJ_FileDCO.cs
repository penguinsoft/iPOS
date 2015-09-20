using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace iPOS.DCO.Tools
{
    [DataContract]
    public class OBJ_FileDCO
    {
        [DataMember]
        public string Data { get; set; }

        [DataMember]
        public int Key { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string Owner { get; set; }
    }
}

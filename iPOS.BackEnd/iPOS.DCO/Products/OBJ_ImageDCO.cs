using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace iPOS.DCO.Products
{
    [DataContract]
    public class OBJ_ImageDCO
    {
        [DataMember]
        public string Image { get; set; }

        [DataMember]
        public int I { get; set; }
    }
}

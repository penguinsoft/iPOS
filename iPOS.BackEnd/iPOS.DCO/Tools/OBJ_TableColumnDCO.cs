using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace iPOS.DCO.Tools
{
    [DataContract]
    public class OBJ_TableColumnDCO
    {
        [DataMember]
        public string ColumnName { get; set; }

        [DataMember]
        public string DateType { get; set; }

        [DataMember]
        public int Length { get; set; }

        [DataMember]
        public int Size { get; set; }

        [DataMember]
        public string InOut { get; set; }
    }

    [DataContract]
    public class OBJ_TableColumnDRO : BaseDRO
    {
        [DataMember]
        public List<OBJ_TableColumnDCO> TableColumnObjectList { get; set; }
    }
}

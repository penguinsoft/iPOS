using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using iPOS.DTO.Tools;

namespace iPOS.DRO.Tools
{
    [DataContract]
    public class OBJ_TableColumnDRO : BaseDRO
    {
        [DataMember]
        public List<OBJ_TableColumnDTO> TableColumnObjectList { get; set; }
    }

    [DataContract]
    public class OBJ_TableColumnDCO
    {
        [DataMember]
        public string ColumnName { get; set; }

        [DataMember]
        public string DateType { get; set; }

        [DataMember]
        public string Length { get; set; }

        [DataMember]
        public string Size { get; set; }

        [DataMember]
        public string InOut { get; set; }
    }
}

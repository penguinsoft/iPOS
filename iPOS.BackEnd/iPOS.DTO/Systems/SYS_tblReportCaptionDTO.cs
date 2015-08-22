using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPOS.DTO.Systems
{
    public class SYS_tblReportCaptionDTO
    {
        public Int32 ID { get; set; }

        public Int32 FunctionID { get; set; }

        public string ControlID { get; set; }

        public string CaptionVN { get; set; }

        public string CaptionEN { get; set; }

        public string Caption { get; set; }

        public string Note { get; set; }

        public bool IsImport { get; set; }

        public bool IsRequire { get; set; }

        public bool IsList { get; set; }

        public string DataType { get; set; }

        public string TableName { get; set; }
    }

    public class ComboDynamicItemDTO
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPOS.DTO.Systems
{
    public class SYS_tblUserLevelDTO
    {
        public Int32 UserLevelID { get; set; }

        public string VNName { get; set; }

        public string ENName { get; set; }

        public System.Nullable<Int32> Rank { get; set; }

        public bool Used { get; set; }

        public bool Visible { get; set; }

        public string Creater { get; set; }

        public System.Nullable<DateTime> CreateTime { get; set; }

        public string Editer { get; set; }

        public System.Nullable<DateTime> EditTime { get; set; }

        public string UserLevelName { get; set; }
    }
}

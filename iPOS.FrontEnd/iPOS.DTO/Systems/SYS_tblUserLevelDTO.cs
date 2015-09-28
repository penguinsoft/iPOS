using System;

namespace iPOS.DTO.Systems
{
    public class SYS_tblUserLevelDTO : BaseDTO
    {
        public string UserLevelID { get; set; }

        public string VNName { get; set; }

        public string ENName { get; set; }

        public string Rank { get; set; }

        public bool Used { get; set; }

        public string UserLevelName { get; set; }
    }
}

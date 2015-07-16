using System;
using System.Collections.Generic;
using iPOS.DTO.System;

namespace iPOS.DRO.System
{
    public class SYS_tblGroupUserDRO : BaseDRO
    {
        public List<SYS_tblGroupUserDTO> GroupUserList { get; set; }

        public SYS_tblGroupUserDTO GroupUserItem { get; set; }
    }
}

using System;

namespace iPOS.DTO.System
{
    public class SYS_tblGroupUserDTO : BaseDTO
    {
        public string GroupID { get; set; }

        public string GroupCode { get; set; }

        public string GroupName { get; set; }

        public string Note { get; set; }

        public bool Active { get; set; }

        public bool IsDefault { get; set; }

        public bool IsRoot { get; set; }
    }
}

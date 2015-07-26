using System;

namespace iPOS.DTO.Systems
{
    public class SYS_tblGroupUserDTO : BaseDTO
    {
        public string GroupID { get; set; }

        public string GroupCode { get; set; }

        public string GroupName { get; set; }

        public string VNName { get; set; }

        public string ENName { get; set; }

        public string Note { get; set; }

        public bool Active { get; set; }

        public bool IsDefault { get; set; }

        public bool IsRoot { get; set; }

        public string ActiveString
        {
            get
            {
                if (Active) return "X";
                else return "";
            }
        }

        public string IsDefaultString
        {
            get
            {
                if (IsDefault) return "X";
                else return "";
            }
        }
    }
}

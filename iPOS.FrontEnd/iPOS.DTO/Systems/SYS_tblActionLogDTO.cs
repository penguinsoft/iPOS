using System;
using iPOS.Core.Helper;

namespace iPOS.DTO.System
{
    public class SYS_tblActionLogDTO : BaseDTO
    {
        public string ID { get; set; }

        public string FullName { get; set; }

        public string ComputerName { get { return Environment.MachineName; } }

        public string AccountWindows { get { return Environment.UserName; } }

        public string ActionVN { get; set; }

        public string ActionEN { get; set; }

        public DateTime ActionTime { get; set; }

        public string FunctionID { get; set; }

        public string FunctionNameVN { get; set; }

        public string FunctionNameEN { get; set; }

        public string IPLAN { get { return ConfigEngine.IPLAN; } }

        public string IPWAN { get { return ConfigEngine.IPWAN; } }

        public string MacAddress { get { return ConfigEngine.MacAddress; } }

        public string DescriptionVN { get; set; }

        public string DescriptionEN { get; set; }
    }
}

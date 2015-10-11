using System;
using System.Collections.Generic;

namespace iPOS.DTO.Products
{
    public class PRO_tblInputExportMethodDTO : BaseDTO
    {
        public Int32 InputExportMethodID { get; set; }

        public string InputExportMethodCode { get; set; }

        public string VNName { get; set; }

        public string ENName { get; set; }

        public int Type { get; set; }

        public int ExportPrice { get; set; }

        public bool IsCreateReciprocalBill { get; set; }
    }
}

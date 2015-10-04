using System;

namespace iPOS.DTO.Products
{
    public class PRO_tblLevel1DTO : BaseDTO
    {
        public string Level1ID { get; set; }

        public string Level1Code { get; set; }

        public string Level1ShortCode { get; set; }

        public string VNName { get; set; }

        public string ENName { get; set; }

        public string Rank { get; set; }

        public bool Used { get; set; }

        public string Note { get; set; }

        public string Description { get; set; }

        public string Level1Name { get; set; }

        public string FullLevel1Name { get; set; }

        public string UsedString
        {
            get
            {
                return Used ? "X" : "";
            }
        }
    }
}

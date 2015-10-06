using System;

namespace iPOS.DTO.Products
{
    public class PRO_tblLevel2DTO : BaseDTO
    {
        public string Level2ID { get; set; }

        public string Level2Code { get; set; }

        public string Level2ShortCode { get; set; }

        public string VNName { get; set; }

        public string ENName { get; set; }

        public string Rank { get; set; }

        public bool Used { get; set; }

        public string Note { get; set; }

        public string Description { get; set; }

        public string Level1ID { get; set; }

        public string Level2Name { get; set; }

        public string FullLevel2Name { get; set; }

        public string Level1Name { get; set; }

        public string UsedString
        {
            get { return Used ? "X" : ""; }
        }
    }
}

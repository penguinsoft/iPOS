using System;

namespace iPOS.DTO.Products
{
    public class PRO_tblProductGroupLevel3DTO
    {
        public Int32 Level3ID { get; set; }

        public string Level3Code { get; set; }

        public string Level3ShortCode { get; set; }

        public string VNName { get; set; }

        public string ENName { get; set; }

        public System.Nullable<Int32> Rank { get; set; }

        public bool Used { get; set; }

        public string Note { get; set; }

        public string Description { get; set; }

        public Int32 Level1ID { get; set; }

        public Int32 Level2ID { get; set; }

        public bool Visible { get; set; }

        public string Creater { get; set; }

        public DateTime CreateTime { get; set; }

        public string Editer { get; set; }

        public System.Nullable<DateTime> EditTime { get; set; }

        public string Activity { get; set; }

        public string UserID { get; set; }

        public string LanguageID { get; set; }
    }
}

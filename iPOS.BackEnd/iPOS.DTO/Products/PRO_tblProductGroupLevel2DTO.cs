﻿using System;

namespace iPOS.DTO.Products
{
    public class PRO_tblProductGroupLevel2DTO
    {
        public Int32 Level2ID { get; set; }

        public string Level2Code { get; set; }

        public string Level2ShortCode { get; set; }

        public string VNName { get; set; }

        public string ENName { get; set; }

        public System.Nullable<Int32> Rank { get; set; }

        public bool Used { get; set; }

        public string Note { get; set; }

        public string Description { get; set; }

        public System.Nullable<Int32> Level1ID { get; set; }

        public bool Visible { get; set; }

        public string Creater { get; set; }

        public System.Nullable<DateTime> CreateTime { get; set; }

        public string Editer { get; set; }

        public System.Nullable<DateTime> EditTime { get; set; }

        public string Activity { get; set; }

        public string UserID { get; set; }

        public string LanguageID { get; set; }

        public string Level2Name { get; set; }

        public string FullLevel2Name { get; set; }

        public string Level1Name { get; set; }
    }
}

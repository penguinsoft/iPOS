﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using iPOS.DTO.Products;

namespace iPOS.DRO.Products
{
    public class PRO_tblProvinceDRO : BaseDRO
    {
        public List<PRO_tblProvinceDTO> ProvinceList { get; set; }

        public PRO_tblProvinceDTO ProvinceItem { get; set; }

        public PRO_tblProvinceDRO()
        {
            ResponseItem = new ResponseItem();
        }
    }

    [DataContract]
    public class PRO_tblProvinceDCO
    {
        [DataMember]
        public string ProvinceID { get; set; }

        [DataMember]
        public string ProvinceCode { get; set; }

        [DataMember]
        public string VNName { get; set; }

        [DataMember]
        public string ENName { get; set; }

        [DataMember]
        public System.Nullable<Int32> Rank { get; set; }

        [DataMember]
        public bool Used { get; set; }

        [DataMember]
        public string Note { get; set; }

        [DataMember]
        public string Activity { get; set; }

        [DataMember]
        public string UserID { get; set; }

        [DataMember]
        public string LanguageID { get; set; }

        [DataMember]
        public bool Visible { get; set; }

        [DataMember]
        public string Creater { get; set; }

        [DataMember]
        public System.Nullable<DateTime> CreateTime { get; set; }

        [DataMember]
        public string Editer { get; set; }

        [DataMember]
        public System.Nullable<DateTime> EditTime { get; set; }

        [DataMember]
        public string ProvinceName { get; set; }
    }
}

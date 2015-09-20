using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace iPOS.DCO.Products
{
    [DataContract]
    public class PRO_tblStoreDCO
    {
        [DataMember]
        public Int32 StoreID { get; set; }

        [DataMember]
        public string StoreCode { get; set; }

        [DataMember]
        public string ShortCode { get; set; }

        [DataMember]
        public string VNName { get; set; }

        [DataMember]
        public string ENName { get; set; }

        [DataMember]
        public string StoreName { get; set; }

        [DataMember]
        public string FullStoreName { get; set; }

        [DataMember]
        public System.Nullable<DateTime> BuildDate { get; set; }

        [DataMember]
        public System.Nullable<DateTime> EndDate { get; set; }

        [DataMember]
        public string AddressVN { get; set; }

        [DataMember]
        public string AddressEN { get; set; }

        [DataMember]
        public string StoreAddress { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public string Fax { get; set; }

        [DataMember]
        public string TaxCode { get; set; }

        [DataMember]
        public System.Nullable<Int32> Rank { get; set; }

        [DataMember]
        public bool Used { get; set; }

        [DataMember]
        public bool IsRoot { get; set; }

        [DataMember]
        public string Representatives { get; set; }

        [DataMember]
        public string Note { get; set; }

        [DataMember]
        public string Photo { get; set; }

        [DataMember]
        public System.Nullable<Int32> ProvinceID { get; set; }

        [DataMember]
        public System.Nullable<Int32> DistrictID { get; set; }

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
        public string Activity { get; set; }

        [DataMember]
        public string UserID { get; set; }

        [DataMember]
        public string LanguageID { get; set; }

        [DataMember]
        public string ProvinceName { get; set; }

        [DataMember]
        public string DistrictName { get; set; }
    }

    [DataContract]
    public class PRO_tblStoreDRO : BaseDRO
    {
        [DataMember]
        public List<PRO_tblStoreDCO> StoreList { get; set; }

        [DataMember]
        public PRO_tblStoreDCO StoreItem { get; set; }
    }
}

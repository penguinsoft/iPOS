using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iPOS.BUS.Systems;
using iPOS.DAO.Products;
using iPOS.DRO.Products;
using iPOS.DTO.Products;
using iPOS.DTO.Systems;
using Newtonsoft.Json;

namespace iPOS.BUS.Products
{
    public class PRO_tblStoreBUS : BaseBUS
    {
        public async static Task<PRO_tblStoreDRO> GetAllStores(string username, string language_id, bool is_combobox, SYS_tblActionLogDTO actionLog)
        {
            PRO_tblStoreDRO result = new PRO_tblStoreDRO();
            try
            {
                string url = string.Format(@"{0}/GetAllStores?Username={1}&LanguageID={2}&GetCombobox={3}", GetBaseUrl(), username, language_id, is_combobox ? "True" : "False");

                result = await PRO_tblStoreDAO.GetAllStores(url);
                if(string.IsNullOrEmpty(result.ResponseItem.Message))
                if (actionLog != null) result.ResponseItem = await SYS_tblActionLogBUS.InsertUpdateLog(actionLog);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                result.ResponseItem.Message = ex.Message;
            }

            return result;
        }

        public async static Task<PRO_tblStoreDRO> GetStoreItem(string username, string language_id, string store_id)
        {
            PRO_tblStoreDRO result = new PRO_tblStoreDRO();
            try
            {
                string url = string.Format(@"{0}/GetStoreByID?Username={1}&LanguageID={2}&StoreID={3}", GetBaseUrl(), username, language_id, store_id);

                result = await PRO_tblStoreDAO.GetStoreItem(url);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                result.ResponseItem.Message = ex.Message;
            }

            return result;
        }

        public async static Task<PRO_tblStoreDRO> InsertUpdateStore(PRO_tblStoreDTO item, SYS_tblActionLogDTO actionLog)
        {
            PRO_tblStoreDRO result = new PRO_tblStoreDRO();
            try
            {
                string url = string.Format(@"{0}/InsertUpdateStore", GetBaseUrl());
                var postData = new PRO_tblStoreDCO
                {
                    StoreID = item.StoreID,
                    StoreCode = item.StoreCode,
                    ShortCode = item.ShortCode,
                    VNName = item.VNName,
                    ENName = item.ENName,
                    BuildDate = item.BuildDate,
                    EndDate = item.EndDate,
                    AddressVN = item.AddressVN,
                    AddressEN = item.AddressEN,
                    Phone = item.Phone,
                    Fax = item.Fax,
                    TaxCode = item.TaxCode,
                    Rank = item.Rank,
                    Used = item.Used,
                    IsRoot = item.IsRoot,
                    Representatives = item.Representatives,
                    Note = item.Note,
                    Photo = item.Photo,
                    ProvinceID = string.IsNullOrEmpty(item.ProvinceID) ? null : item.ProvinceID,
                    DistrictID = string.IsNullOrEmpty(item.DistrictID) ? null : item.DistrictID,
                    UserID = item.UserID,
                    Activity = item.Activity,
                    LanguageID = item.LanguageID
                };
                var json_data = "{\"store\":" + JsonConvert.SerializeObject(postData, new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                }) + "}";

                result = await PRO_tblStoreDAO.InsertUpdateStore(url, json_data);
                if (string.IsNullOrEmpty(result.ResponseItem.Message)) result.ResponseItem = await SYS_tblActionLogBUS.InsertUpdateLog(actionLog);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                result.ResponseItem.Message = ex.Message;
            }

            return result;
        }

        public async static Task<PRO_tblStoreDRO> DeleteStore(string username, string language_id, string store_id_list, SYS_tblActionLogDTO actionLog)
        {
            PRO_tblStoreDRO result = new PRO_tblStoreDRO();
            try
            {
                string url = string.Format(@"{0}/DeleteStore?Username={1}&LanguageID={2}&StoreIDList={3}", GetBaseUrl(), username, language_id, store_id_list);

                result = await PRO_tblStoreDAO.DeleteStore(url);
                if (string.IsNullOrEmpty(result.ResponseItem.Message)) result.ResponseItem = await SYS_tblActionLogBUS.InsertUpdateLog(actionLog);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                result.ResponseItem.Message = ex.Message;
            }

            return result;
        }
    }
}

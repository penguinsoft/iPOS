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
    public class PRO_tblWarehouseBUS : BaseBUS
    {
        public async static Task<PRO_tblWarehouseDRO> GetAllWarehouses(string username, string language_id, bool is_combobox, string store_id, string province_id, string district_id, SYS_tblActionLogDTO actionLog)
        {
            PRO_tblWarehouseDRO result = new PRO_tblWarehouseDRO();
            try
            {
                string url = string.Format(@"{0}/GetAllWarehouses?Username={1}&LanguageID={2}&StoreID={3}&ProvinceID={4}&DistrictID={5}&GetCombobox={6}", GetBaseUrl(), username, language_id, store_id, province_id, district_id, is_combobox ? "True" : "False");

                result = await PRO_tblWarehouseDAO.GetAllWarehouses(url);
                if (string.IsNullOrEmpty(result.ResponseItem.Message))
                    if (actionLog != null) result.ResponseItem = await SYS_tblActionLogBUS.InsertUpdateLog(actionLog);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                result.ResponseItem.Message = ex.Message;
            }

            return result;
        }

        public async static Task<PRO_tblWarehouseDRO> GetWarehouseItem(string username, string language_id, string warehouse_id)
        {
            PRO_tblWarehouseDRO result = new PRO_tblWarehouseDRO();
            try
            {
                string url = string.Format(@"{0}/GetWarehouseByID?Username={1}&LanguageID={2}&WarehouseID={3}", GetBaseUrl(), username, language_id, warehouse_id);

                result = await PRO_tblWarehouseDAO.GetWarehouseItem(url);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                result.ResponseItem.Message = ex.Message;
            }

            return result;
        }

        public async static Task<PRO_tblWarehouseDRO> InsertUpdateStore(PRO_tblWarehouseDTO item, SYS_tblActionLogDTO actionLog)
        {
            PRO_tblWarehouseDRO result = new PRO_tblWarehouseDRO();
            try
            {
                string url = string.Format(@"{0}/InsertUpdateWarehouse", GetBaseUrl());
                var postData = new PRO_tblWarehouseDCO
                {
                    WarehouseID = item.WarehouseID,
                    WarehouseCode = item.WarehouseCode,
                    VNName = item.VNName,
                    ENName = item.ENName,
                    StoreID = item.StoreID,
                    AddressVN = item.AddressVN,
                    AddressEN = item.AddressEN,
                    Phone = item.Phone,
                    Fax = item.Fax,
                    ProvinceID = string.IsNullOrEmpty(item.ProvinceID) ? null : item.ProvinceID,
                    DistrictID = string.IsNullOrEmpty(item.DistrictID) ? null : item.DistrictID,
                    Rank = item.Rank,
                    Used = item.Used,
                    Note = item.Note,
                    UserID = item.UserID,
                    Activity = item.Activity,
                    LanguageID = item.LanguageID
                };
                var json_data = "{\"warehouse\":" + JsonConvert.SerializeObject(postData, new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                }) + "}";

                result = await PRO_tblWarehouseDAO.InsertUpdateWarehouse(url, json_data);
                if (string.IsNullOrEmpty(result.ResponseItem.Message)) result.ResponseItem = await SYS_tblActionLogBUS.InsertUpdateLog(actionLog);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                result.ResponseItem.Message = ex.Message;
            }

            return result;
        }

        public async static Task<PRO_tblWarehouseDRO> DeleteWarehouse(string username, string language_id, string warehouse_id_list, SYS_tblActionLogDTO actionLog)
        {
            PRO_tblWarehouseDRO result = new PRO_tblWarehouseDRO();
            try
            {
                string url = string.Format(@"{0}/DeleteWarehouse?Username={1}&LanguageID={2}&WarehouseIDList={3}", GetBaseUrl(), username, language_id, warehouse_id_list);

                result = await PRO_tblWarehouseDAO.DeleteWarehouse(url);
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

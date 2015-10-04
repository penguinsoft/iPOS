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
    public class PRO_tblStallBUS : BaseBUS
    {
        public async static Task<PRO_tblStallDRO> GetAllStall(string username, string language_id, bool is_combobox, string store_id, string warehouse_id, SYS_tblActionLogDTO actionLog)
        {
            PRO_tblStallDRO result = new PRO_tblStallDRO();
            try
            {
                string url = string.Format(@"{0}/GetAllStalls?Username={1}&LanguageID={2}&StoreID={3}&WarehouseID={4}&GetCombobox={5}", GetBaseUrl(), username, language_id, store_id, warehouse_id, is_combobox ? "True" : "False");

                result = await PRO_tblStallDAO.GetAllStalls(url);
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

        public async static Task<PRO_tblStallDRO> GetStallItem(string username, string language_id, string stall_id)
        {
            PRO_tblStallDRO result = new PRO_tblStallDRO();
            try
            {
                string url = string.Format(@"{0}/GetStallByID?Username={1}&LanguageID={2}&StallID={3}", GetBaseUrl(), username, language_id, stall_id);

                result = await PRO_tblStallDAO.GetStallItem(url);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                result.ResponseItem.Message = ex.Message;
            }

            return result;
        }

        public async static Task<PRO_tblStallDRO> InsertUpdateStall(PRO_tblStallDTO item, SYS_tblActionLogDTO actionLog)
        {
            PRO_tblStallDRO result = new PRO_tblStallDRO();
            try
            {
                string url = string.Format(@"{0}/InsertUpdateStall", GetBaseUrl());
                var postData = new PRO_tblStallDCO
                {
                    StallID = item.StallID,
                    StallCode = item.StallCode,
                    VNName = item.VNName,
                    ENName = item.ENName,
                    StoreID = item.StoreID,
                    WarehouseID = item.WarehouseID,
                    Rank = item.Rank,
                    Used = item.Used,
                    Note = item.Note,
                    UserID = item.UserID,
                    Activity = item.Activity,
                    LanguageID = item.LanguageID
                };
                var json_data = "{\"stall\":" + JsonConvert.SerializeObject(postData, new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                }) + "}";

                result = await PRO_tblStallDAO.InsertUpdateStall(url, json_data);
                if (string.IsNullOrEmpty(result.ResponseItem.Message)) result.ResponseItem = await SYS_tblActionLogBUS.InsertUpdateLog(actionLog);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                result.ResponseItem.Message = ex.Message;
            }

            return result;
        }

        public async static Task<PRO_tblStallDRO> DeleteStall(string username, string language_id, string stall_id_list, SYS_tblActionLogDTO actionLog)
        {
            PRO_tblStallDRO result = new PRO_tblStallDRO();
            try
            {
                string url = string.Format(@"{0}/DeleteStall?Username={1}&LanguageID={2}&StallIDList={3}", GetBaseUrl(), username, language_id, stall_id_list);

                result = await PRO_tblStallDAO.DeleteStall(url);
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

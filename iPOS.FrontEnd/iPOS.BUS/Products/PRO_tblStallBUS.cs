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
        public async static Task<List<PRO_tblStallDTO>> GetAllStall(string username, string language_id, bool is_combobox, string store_id, string warehouse_id, SYS_tblActionLogDTO actionLog)
        {
            string url = string.Format(@"{0}/GetAllStalls?Username={1}&LanguageID={2}&StoreID={3}&WarehouseID={4}&GetCombobox={5}", GetBaseUrl(), username, language_id, store_id, warehouse_id, is_combobox ? "True" : "False");

            if (actionLog != null) await SYS_tblActionLogBUS.InsertUpdateLog(actionLog);
            return await PRO_tblStallDAO.GetAllStalls(url);
        }

        public async static Task<PRO_tblStallDTO> GetStallItem(string username, string language_id, string stall_id)
        {
            string url = string.Format(@"{0}/GetStallByID?Username={1}&LanguageID={2}&StallID={3}", GetBaseUrl(), username, language_id, stall_id);

            return await PRO_tblStallDAO.GetStallItem(url);
        }

        public async static Task<string> InsertUpdateStall(PRO_tblStallDTO item, SYS_tblActionLogDTO actionLog)
        {
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

                string result = await PRO_tblStallDAO.InsertUpdateStall(url, json_data);
                if (string.IsNullOrEmpty(result)) result = await SYS_tblActionLogBUS.InsertUpdateLog(actionLog);
                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return ex.Message;
            }
        }

        public async static Task<string> DeleteStall(string username, string language_id, string stall_id_list, SYS_tblActionLogDTO actionLog)
        {
            try
            {
                string url = string.Format(@"{0}/DeleteStall?Username={1}&LanguageID={2}&StallIDList={3}", GetBaseUrl(), username, language_id, stall_id_list);

                string result = await PRO_tblStallDAO.DeleteStall(url);
                if (string.IsNullOrEmpty(result)) result = await SYS_tblActionLogBUS.InsertUpdateLog(actionLog);
                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return ex.Message;
            }
        }
    }
}

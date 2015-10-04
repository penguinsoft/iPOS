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
    public class PRO_tblProvinceBUS : BaseBUS
    {
        public async static Task<PRO_tblProvinceDRO> GetAllProvinces(string username, string language_id, bool is_combobox, SYS_tblActionLogDTO actionLog)
        {
            PRO_tblProvinceDRO result = new PRO_tblProvinceDRO();
            try
            {
                string url = string.Format(@"{0}/GetAllProvinces?Username={1}&LanguageID={2}&GetCombobox={3}", GetBaseUrl(), username, language_id, is_combobox ? "True" : "False");

                result = await PRO_tblProvinceDAO.GetAllProvinces(url);
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

        public async static Task<PRO_tblProvinceDRO> GetProvinceItem(string username, string language_id, string province_id)
        {
            PRO_tblProvinceDRO result = new PRO_tblProvinceDRO();
            try
            {
                string url = string.Format(@"{0}/GetProvinceByID?Username={1}&LanguageID={2}&ProvinceID={3}", GetBaseUrl(), username, language_id, province_id);

                result = await PRO_tblProvinceDAO.GetProvinceItem(url);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                result.ResponseItem.Message = ex.Message;
            }

            return result;
        }

        public async static Task<PRO_tblProvinceDRO> InsertUpdateProvince(PRO_tblProvinceDTO item, SYS_tblActionLogDTO actionLog)
        {
            PRO_tblProvinceDRO result = new PRO_tblProvinceDRO();
            try
            {
                string url = string.Format(@"{0}/InsertUpdateProvince", GetBaseUrl());
                var postData = new PRO_tblProvinceDCO
                {
                    ProvinceID = item.ProvinceID,
                    ProvinceCode = item.ProvinceCode,
                    VNName = item.VNName,
                    ENName = item.ENName,
                    Rank = item.Rank,
                    Used = item.Used,
                    Note = item.Note,
                    Activity = item.Activity,
                    UserID = item.UserID,
                    LanguageID = item.LanguageID
                };
                var json_data = "{\"province\":" + JsonConvert.SerializeObject(postData, new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                }) + "}";

                result = await PRO_tblProvinceDAO.InsertUpdateProvince(url, json_data);
                if (string.IsNullOrEmpty(result.ResponseItem.Message)) result.ResponseItem = await SYS_tblActionLogBUS.InsertUpdateLog(actionLog);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                result.ResponseItem.Message = ex.Message;
            }

            return result;
        }

        public async static Task<PRO_tblProvinceDRO> DeleteProvince(string username, string language_id, string province_id_list, SYS_tblActionLogDTO actionLog)
        {
            PRO_tblProvinceDRO result = new PRO_tblProvinceDRO();
            try
            {
                string url = string.Format(@"{0}/DeleteProvince?Username={1}&LanguageID={2}&ProvinceIDList={3}", GetBaseUrl(), username, language_id, province_id_list);

                result = await PRO_tblProvinceDAO.DeleteProvince(url);
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

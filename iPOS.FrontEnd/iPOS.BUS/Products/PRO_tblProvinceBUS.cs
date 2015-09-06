using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iPOS.BUS.Systems;
using iPOS.DAO.Products;
using iPOS.DTO.Products;
using iPOS.DTO.Systems;
using Newtonsoft.Json;

namespace iPOS.BUS.Products
{
    public class PRO_tblProvinceBUS : BaseBUS
    {
        public async static Task<List<PRO_tblProvinceDTO>> GetAllProvinces(string username, string language_id, bool is_combobox, SYS_tblActionLogDTO actionLog)
        {
            string url = string.Format(@"{0}/GetAllProvinces?Username={1}&LanguageID={2}&GetCombobox={3}", GetBaseUrl(), username, language_id, is_combobox ? "True" : "False");

            if (actionLog != null) await SYS_tblActionLogBUS.InsertUpdateLog(actionLog);
            return await PRO_tblProvinceDAO.GetAllProvinces(url);
        }

        public async static Task<PRO_tblProvinceDTO> GetProvinceItem(string username, string language_id, string province_id)
        {
            string url = string.Format(@"{0}/GetProvinceByID?Username={1}&LanguageID={2}&ProvinceID={3}", GetBaseUrl(), username, language_id, province_id);

            return await PRO_tblProvinceDAO.GetProvinceItem(url);
        }

        public async static Task<string> InsertUpdateProvince(PRO_tblProvinceDTO item, SYS_tblActionLogDTO actionLog)
        {
            try
            {
                string url = string.Format(@"{0}/InsertUpdateProvince", GetBaseUrl());
                var postData = new PRO_tblProvinceDTO
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

                string result = await PRO_tblProvinceDAO.InsertUpdateProvince(url, json_data);
                if (string.IsNullOrEmpty(result)) result = await SYS_tblActionLogBUS.InsertUpdateLog(actionLog);
                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return ex.Message;
            }
        }

        public async static Task<string> DeleteProvince(string username, string language_id, string province_id_list, SYS_tblActionLogDTO actionLog)
        {
            try
            {
                string url = string.Format(@"{0}/DeleteProvince?Username={1}&LanguageID={2}&ProvinceIDList={3}", GetBaseUrl(), username, language_id, province_id_list);

                string result = await PRO_tblProvinceDAO.DeleteProvince(url);
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

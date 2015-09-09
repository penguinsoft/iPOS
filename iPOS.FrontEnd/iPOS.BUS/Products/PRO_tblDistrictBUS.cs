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
    public class PRO_tblDistrictBUS : BaseBUS
    {
        public async static Task<List<PRO_tblDistrictDTO>> GetAllDistricts(string username, string language_id, bool is_combobox, string province_id, SYS_tblActionLogDTO actionLog)
        {
            string url = string.Format(@"{0}/GetAllDistrict?Username={1}&LanguageID={2}&ProvinceID={3}&GetCombobox={4}", GetBaseUrl(), username, language_id, province_id, is_combobox ? "True" : "False");

            if (actionLog != null) await SYS_tblActionLogBUS.InsertUpdateLog(actionLog);
            return await PRO_tblDistrictDAO.GetAllDistricts(url);
        }

        public async static Task<PRO_tblDistrictDTO> GetDistrictItem(string username, string language_id, string district_id)
        {
            string url = string.Format(@"{0}/GetDistrictByID?Username={1}&LanguageID={2}&DistrictID={3}", GetBaseUrl(), username, language_id, district_id);

            return await PRO_tblDistrictDAO.GetDistrictItem(url);
        }

        public async static Task<string> InsertUpdateDistrict(PRO_tblDistrictDTO item, SYS_tblActionLogDTO actionLog)
        {
            try
            {
                string url = string.Format(@"{0}/InsertUpdateDistrict", GetBaseUrl());
                var postData = new PRO_tblDistrictDCO
                {
                    DistrictID = item.DistrictID,
                    DistrictCode = item.DistrictCode,
                    VNName = item.VNName, 
                    ENName = item.ENName,
                    ProvinceID = item.ProvinceID,
                    Rank = item.Rank,
                    Used = item.Used,
                    Note = item.Note,
                    Activity = item.Activity,
                    UserID = item.UserID,
                    LanguageID = item.LanguageID
                };
                var json_data = "{\"district\":" + JsonConvert.SerializeObject(postData, new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                }) + "}";

                string result = await PRO_tblDistrictDAO.InsertUpdateDistrict(url, json_data);
                if (string.IsNullOrEmpty(result)) result = await SYS_tblActionLogBUS.InsertUpdateLog(actionLog);
                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return ex.Message;
            }
        }

        public async static Task<string> DeleteDistrict(string username, string language_id, string district_id_list, SYS_tblActionLogDTO actionLog)
        {
            try
            {
                string url = string.Format(@"{0}/DeleteDistrict?Username={1}&LanguageID={2}&DistrictIDList={3}", GetBaseUrl(), username, language_id, district_id_list);

                string result = await PRO_tblDistrictDAO.DeleteDistrict(url);
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

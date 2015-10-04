using iPOS.BUS.Systems;
using iPOS.DAO.Products;
using iPOS.DRO.Products;
using iPOS.DTO.Products;
using iPOS.DTO.Systems;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iPOS.BUS.Products
{
    public class PRO_tblLevel1BUS : BaseBUS
    {
        public async static Task<PRO_tblLevel1DRO> GetAllLevel1(string username, string language_id, bool is_combobox, SYS_tblActionLogDTO actionLog)
        {
            PRO_tblLevel1DRO result = new PRO_tblLevel1DRO();
            try
            {
                string url = string.Format(@"{0}/GetAllLevel1?Username={1}&LanguageID={2}&GetCombobox={3}", GetBaseUrl(), username, language_id, is_combobox ? "True" : "False");

                result = await PRO_tblLevel1DAO.GetAllLevel1(url);
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

        public async static Task<PRO_tblLevel1DRO> GetLevel1ByID(string username, string language_id, string level1_id)
        {
            PRO_tblLevel1DRO result = new PRO_tblLevel1DRO();
            try
            {
                string url = string.Format(@"{0}/GetLevel1ByID?Username={1}&LanguageID={2}&Level1ID={3}", GetBaseUrl(), username, language_id, level1_id);

                result = await PRO_tblLevel1DAO.GetLevel1ByID(url);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                result.ResponseItem.Message = ex.Message;
            }

            return result;
        }

        public async static Task<PRO_tblLevel1DRO> InsertUpdateLevel1(PRO_tblLevel1DTO item, SYS_tblActionLogDTO actionLog)
        {
            PRO_tblLevel1DRO result = new PRO_tblLevel1DRO();
            try
            {
                string url = string.Format(@"{0}/InsertUpdateLevel1", GetBaseUrl());
                var postData = new PRO_tblLevel1DCO
                {
                    Level1ID = item.Level1ID,
                    Level1Code = item.Level1Code,
                    Level1ShortCode = item.Level1ShortCode,
                    VNName = item.VNName,
                    ENName = item.ENName,
                    Rank = string.IsNullOrEmpty(item.Rank) ? null : item.Rank,
                    Note = item.Note,
                    Description = item.Description,
                    Used = item.Used,
                    Activity = item.Activity,
                    UserID = item.UserID,
                    LanguageID = item.LanguageID
                };
                var json_data = "{\"level1\":" + JsonConvert.SerializeObject(postData, new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                }) + "}";

                result = await PRO_tblLevel1DAO.InsertUpdateLevel1(url, json_data);
                if (string.IsNullOrEmpty(result.ResponseItem.Message)) result.ResponseItem = await SYS_tblActionLogBUS.InsertUpdateLog(actionLog);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                result.ResponseItem.Message = ex.Message;
            }

            return result;
        }

        public async static Task<PRO_tblLevel1DRO> DeleteLevel1(string username, string language_id, string level1_id_list, SYS_tblActionLogDTO actionLog)
        {
            PRO_tblLevel1DRO result = new PRO_tblLevel1DRO();
            try
            {
                string url = string.Format(@"{0}/DeleteLevel1?Username={1}&LanguageID={2}&Level1IDList={3}", GetBaseUrl(), username, language_id, level1_id_list);

                result = await PRO_tblLevel1DAO.DeleteLevel1(url);
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

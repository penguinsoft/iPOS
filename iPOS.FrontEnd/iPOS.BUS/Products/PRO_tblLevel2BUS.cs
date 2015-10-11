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
    public class PRO_tblLevel2BUS : BaseBUS
    {
        public async static Task<PRO_tblLevel2DRO> GetAllLevel2(string username, string language_id, string level1_id, bool is_combobox, SYS_tblActionLogDTO actionLog)
        {
            PRO_tblLevel2DRO result = new PRO_tblLevel2DRO();
            try
            {
                string url = string.Format(@"{0}/GetAllLevel2?Username={1}&LanguageID={2}&Level1ID={3}&GetCombobox={4}", GetBaseUrl(), username, language_id, level1_id, is_combobox ? "True" : "False");

                result = await PRO_tblLevel2DAO.GetAllLevel2(url);
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

        public async static Task<PRO_tblLevel2DRO> GetLevel2ByID(string username, string language_id, string level2_id)
        {
            PRO_tblLevel2DRO result = new PRO_tblLevel2DRO();
            try
            {
                string url = string.Format(@"{0}/GetLevel2ByID?Username={1}&LanguageID={2}&Level2ID={3}", GetBaseUrl(), username, language_id, level2_id);

                result = await PRO_tblLevel2DAO.GetLevel2ByID(url);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                result.ResponseItem.Message = ex.Message;
            }

            return result;
        }

        public async static Task<PRO_tblLevel2DRO> InsertUpdateLevel2(PRO_tblLevel2DTO item, SYS_tblActionLogDTO actionLog)
        {
            PRO_tblLevel2DRO result = new PRO_tblLevel2DRO();
            try
            {
                string url = string.Format(@"{0}/InsertUpdateLevel2", GetBaseUrl());
                var postData = new PRO_tblLevel2DCO
                {
                    Level2ID = item.Level2ID,
                    Level2Code = item.Level2Code,
                    Level2ShortCode = item.Level2ShortCode,
                    Level1ID = item.Level1ID,
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
                var json_data = "{\"level2\":" + JsonConvert.SerializeObject(postData, new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                }) + "}";

                result = await PRO_tblLevel2DAO.InsertUpdateLevel2(url, json_data);
                if (string.IsNullOrEmpty(result.ResponseItem.Message)) result.ResponseItem = await SYS_tblActionLogBUS.InsertUpdateLog(actionLog);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                result.ResponseItem.Message = ex.Message;
            }

            return result;
        }

        public async static Task<PRO_tblLevel2DRO> DeleteLevel2(string username, string language_id, string level2_id_list, SYS_tblActionLogDTO actionLog)
        {
            PRO_tblLevel2DRO result = new PRO_tblLevel2DRO();
            try
            {
                string url = string.Format(@"{0}/DeleteLevel2?Username={1}&LanguageID={2}&Level2IDList={3}", GetBaseUrl(), username, language_id, level2_id_list);

                result = await PRO_tblLevel2DAO.DeleteLevel2(url);
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

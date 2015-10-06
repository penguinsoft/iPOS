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
    public class PRO_tblLevel3BUS : BaseBUS
    {
        public async static Task<PRO_tblLevel3DRO> GetAllLevel3(string username, string language_id, string level1_id, string level2_id, bool is_combobox, SYS_tblActionLogDTO actionLog)
        {
            PRO_tblLevel3DRO result = new PRO_tblLevel3DRO();
            try
            {
                string url = string.Format(@"{0}/GetAllLevel3?Username={1}&LanguageID={2}&Level1ID={3}&Level2ID={4}&GetCombobox={5}", GetBaseUrl(), username, language_id, level1_id, level2_id, is_combobox ? "True" : "False");

                result = await PRO_tblLevel3DAO.GetAllLevel3(url);
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

        public async static Task<PRO_tblLevel3DRO> GetLevel3ByID(string username, string language_id, string Level3_id)
        {
            PRO_tblLevel3DRO result = new PRO_tblLevel3DRO();
            try
            {
                string url = string.Format(@"{0}/GetLevel3ByID?Username={1}&LanguageID={2}&Level3ID={3}", GetBaseUrl(), username, language_id, Level3_id);

                result = await PRO_tblLevel3DAO.GetLevel3ByID(url);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                result.ResponseItem.Message = ex.Message;
            }

            return result;
        }

        public async static Task<PRO_tblLevel3DRO> InsertUpdateLevel3(PRO_tblLevel3DTO item, SYS_tblActionLogDTO actionLog)
        {
            PRO_tblLevel3DRO result = new PRO_tblLevel3DRO();
            try
            {
                string url = string.Format(@"{0}/InsertUpdateLevel3", GetBaseUrl());
                var postData = new PRO_tblLevel3DCO
                {
                    Level3ID = item.Level3ID,
                    Level3Code = item.Level3Code,
                    Level3ShortCode = item.Level3ShortCode,
                    Level1ID = item.Level1ID,
                    Level2ID = item.Level2ID,
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
                var json_data = "{\"level3\":" + JsonConvert.SerializeObject(postData, new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                }) + "}";

                result = await PRO_tblLevel3DAO.InsertUpdateLevel3(url, json_data);
                if (string.IsNullOrEmpty(result.ResponseItem.Message)) result.ResponseItem = await SYS_tblActionLogBUS.InsertUpdateLog(actionLog);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                result.ResponseItem.Message = ex.Message;
            }

            return result;
        }

        public async static Task<PRO_tblLevel3DRO> DeleteLevel3(string username, string language_id, string Level3_id_list, SYS_tblActionLogDTO actionLog)
        {
            PRO_tblLevel3DRO result = new PRO_tblLevel3DRO();
            try
            {
                string url = string.Format(@"{0}/DeleteLevel3?Username={1}&LanguageID={2}&Level3IDList={3}", GetBaseUrl(), username, language_id, Level3_id_list);

                result = await PRO_tblLevel3DAO.DeleteLevel3(url);
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

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iPOS.DRO.Systems;
using iPOS.DTO.Systems;
using Newtonsoft.Json;

namespace iPOS.DAO.Systems
{
    public class SYS_tblReportCaptionDAO : BaseDAO
    {
        public async static Task<SYS_tblReportCaptionDRO> GetReportCaption(string url)
        {
            SYS_tblReportCaptionDRO result = new SYS_tblReportCaptionDRO();
            try
            {
                var response_data = await HttpGet(url);
                if (response_data.ToLower().StartsWith("error"))
                {
                    result.ResponseItem.IsError = true;
                    string[] tmp = response_data.Split('|');
                    result.ResponseItem.ErrorCode = tmp[1];
                    result.ResponseItem.ErrorMessage = tmp[2];
                }
                else
                {
                    var response_collection = JsonConvert.DeserializeObject<SYS_tblReportCaptionDRO>(response_data + "");

                    if (response_collection != null)
                    {
                        result.ReportCaptionList = response_collection.ReportCaptionList;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                result.ResponseItem.Message = ex.Message;
            }

            return result;
        }

        public async static Task<SYS_tblReportCaptionDRO> GetComboDynamicList(string url)
        {
            SYS_tblReportCaptionDRO result = new SYS_tblReportCaptionDRO();
            try
            {
                var response_data = await HttpGet(url);
                if (response_data.ToLower().StartsWith("error"))
                {
                    result.ResponseItem.IsError = true;
                    string[] tmp = response_data.Split('|');
                    result.ResponseItem.ErrorCode = tmp[1];
                    result.ResponseItem.ErrorMessage = tmp[2];
                }
                else
                {
                    var response_collection = JsonConvert.DeserializeObject<SYS_tblReportCaptionDRO>(response_data + "");

                    if (response_collection != null)
                    {
                        result.ComboDynamicList = response_collection.ComboDynamicList;
                    }
                }
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

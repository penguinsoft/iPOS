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
        public async static Task<List<SYS_tblReportCaptionDTO>> GetReportCaption(string url)
        {
            try
            {
                var response_data = await HttpGet(url);
                var response_collection = JsonConvert.DeserializeObject<SYS_tblReportCaptionDRO>(response_data + "");

                if (response_collection != null)
                    return response_collection.ReportCaptionList;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return null;
        }

        public async static Task<List<ComboDynamicItemDTO>> GetComboDynamicList(string url)
        {
            try
            {
                var response_data = await HttpGet(url);
                var response_collection = JsonConvert.DeserializeObject<SYS_tblReportCaptionDRO>(response_data + "");

                if (response_collection != null)
                    return response_collection.ComboDynamicList;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return null;
        }
    }
}

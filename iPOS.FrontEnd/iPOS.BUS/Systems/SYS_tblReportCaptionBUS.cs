using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iPOS.DAO.Systems;
using iPOS.DTO.Systems;
using iPOS.DRO.Systems;

namespace iPOS.BUS.Systems
{
    public class SYS_tblReportCaptionBUS : BaseBUS
    {
        public async static Task<SYS_tblReportCaptionDRO> GetReportCaption(string username, string language_id, string function_id, bool is_import)
        {
            SYS_tblReportCaptionDRO result = new SYS_tblReportCaptionDRO();
            try
            {
                string url = string.Format(@"{0}/GetReportCaption?Username={1}&LanguageID={2}&FunctionID={3}&IsImport={4}", GetBaseUrl(), username, language_id, function_id, is_import);

                result = await SYS_tblReportCaptionDAO.GetReportCaption(url);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                result.ResponseItem.Message = ex.Message;
            }

            return result;
        }

        public async static Task<SYS_tblReportCaptionDRO> GetComboDynamicList(string username, string language_id, string code, string table_name, string get_by)
        {
            SYS_tblReportCaptionDRO result = new SYS_tblReportCaptionDRO();
            try
            {
                string url = string.Format(@"{0}/GetComboDynamicList?Username={1}&LanguageID={2}&Code={3}&TableName={4}&GetBy={5}", GetBaseUrl(), username, language_id, code, table_name, get_by);

                result = await SYS_tblReportCaptionDAO.GetComboDynamicList(url);
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

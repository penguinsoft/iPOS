using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iPOS.Core.Helper;
using iPOS.DTO.Systems;

namespace iPOS.DAO.Systems
{
    public interface ISYS_tblReportCaptionDAO
    {
        List<SYS_tblReportCaptionDTO> LoadImportCaption(string username, string language_id, string function_id, bool is_import);

        List<ComboDynamicItemDTO> LoadComboDynamicList(string username, string language_id, string code, string table_name, string get_by);
    }

    public class SYS_tblReportCaptionDAO : BaseDAO, ISYS_tblReportCaptionDAO
    {
        public List<SYS_tblReportCaptionDTO> LoadImportCaption(string username, string language_id, string function_id, bool is_import)
        {
            List<SYS_tblReportCaptionDTO> result = new List<SYS_tblReportCaptionDTO>();
            try
            {
                DataTable data = db.GetDataTable("SYS_spfrmReportCaption", new string[] { "Activity", "Username", "LanguageID", "FunctionID", "IsImport" }, new object[] { "LoadImportCaption", username, language_id, function_id, is_import });

                if (data != null && data.Rows.Count > 0)
                    result = ConvertEngine.ConvertDataTableToObjectList<SYS_tblReportCaptionDTO>(data);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }

        public List<ComboDynamicItemDTO> LoadComboDynamicList(string username, string language_id, string code, string table_name, string get_by)
        {
            List<ComboDynamicItemDTO> result = new List<ComboDynamicItemDTO>();
            try
            {
                DataTable data = db.GetDataTable("SYS_spfrmComboDynamic", new string[] { "Username", "LanguageID", "Code", "TableName", "GetBy" }, new object[] { username, language_id, code, table_name, get_by });

                if (result != null && data.Rows.Count > 0)
                    result = ConvertEngine.ConvertDataTableToObjectList<ComboDynamicItemDTO>(data);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }
    }
}

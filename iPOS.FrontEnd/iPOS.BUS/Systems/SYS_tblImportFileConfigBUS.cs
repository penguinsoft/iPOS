using System;
using System.Threading.Tasks;
using iPOS.DAO.Systems;
using iPOS.DTO.Systems;

namespace iPOS.BUS.Systems
{
    public class SYS_tblImportFileConfigBUS : BaseBUS
    {
        public async static Task<SYS_tblImportFileConfigDTO> CheckValidImportTemplate(string username, string language_id, string store_procedure, string file_name, string module_id, string function_id)
        {
            string url = string.Format(@"{0}/CheckValidImportTemplate?Username={1}&LanguageID={2}&StoreProcedure={3}&FileName={4}&ModuleID={5}&FunctionID={6}", GetBaseUrl(), username, language_id, store_procedure, file_name, module_id, function_id);

            return await SYS_tblImportFileConfigDAO.CheckValidImportTemplate(url);
        }
    }
}

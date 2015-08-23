using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iPOS.DAO.Systems;
using iPOS.DTO.Systems;
using Newtonsoft.Json;

namespace iPOS.BUS.Systems
{
    public class SYS_tblImportFileConfigBUS : BaseBUS
    {
        public async static Task<SYS_tblImportFileConfigDTO> CheckValidImportTemplate(string username, string language_id, string store_procedure, string file_name, string module_id, string function_id)
        {
            string url = string.Format(@"{0}/CheckValidImportTemplate?Username={1}&LanguageID={2}&StoreProcedure={3}&FileName={4}&ModuleID={5}&FunctionID={6}", GetBaseUrl(), username, language_id, store_procedure, file_name, module_id, function_id);

            return await SYS_tblImportFileConfigDAO.CheckValidImportTemplate(url);
        }

        public async static Task<string> ImportDataRow(string username, string language_id, string store_procedure, System.Data.DataRow dr, string column_array)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            string[] arrColumn = { };
            arrColumn = column_array.Trim().Split('|');
            if (dr != null && arrColumn.Length > 0)
            {
                dictionary.Add("Username", username);
                dictionary.Add("LanguageID", language_id);
                for (int i = 0; i < arrColumn.Length; i++)
                    dictionary.Add(arrColumn[i], dr[i] + "");
            }

            var json = JsonConvert.SerializeObject(dictionary);
            string url = string.Format(@"{0}/ImportDataRow?Username={1}&InputData={2}&StoreProcedure={3}", GetBaseUrl(), username, json + "", store_procedure);

            return await SYS_tblImportFileConfigDAO.ImportDataRow(url);
        }
    }
}

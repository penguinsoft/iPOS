using System;
using System.Data;
using iPOS.Core.Helper;
using iPOS.DTO.Systems;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iPOS.DAO.Systems
{
    public interface ISYS_tblImportFileConfigDAO
    {
        SYS_tblImportFileConfigDTO CheckValidImportTemplate(string username, string language_id, string store_procedure, string file_name, string module_id, string function_id);

        string ImportDataRow(Dictionary<string, string> input, string store_procedure);
    }

    public class SYS_tblImportFileConfigDAO : BaseDAO, ISYS_tblImportFileConfigDAO
    {
        public SYS_tblImportFileConfigDTO CheckValidImportTemplate(string username, string language_id, string store_procedure, string file_name, string module_id, string function_id)
        {
            SYS_tblImportFileConfigDTO result = new SYS_tblImportFileConfigDTO();
            try
            {
                DataRow dr = db.GetDataRow("SYS_spfrmImportFileConfig", new string[] { "Activity", "Username", "LanguageID", "ExcelFile", "FunctionID", "ModuleID" }, new object[] { "CheckValidTemplate", username, language_id, file_name, function_id, module_id });
                if (dr != null)
                {
                    result = new SYS_tblImportFileConfigDTO
                    {
                        ImportFileConfigID = Convert.ToInt32(dr["ImportFileConfigID"]),
                        ModuleID = dr["ModuleID"] + "",
                        ExcelFile = dr["ExcelFile"] + "",
                        FunctionID = Convert.ToInt32(dr["FunctionID"])
                    };

                    return result;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }

        public string ImportDataRow(Dictionary<string, string> input, string store_procedure)
        {
            string result = "";
            try
            {
                if (input != null && input.Count > 0)
                {
                    string[] parameters = new string[input.Count];
                    string[] values = new string[input.Count];
                    int index = 0;
                    foreach (KeyValuePair<string, string> item in input)
                    {
                        parameters[index] = item.Key + "";
                        values[index] = item.Value + "";
                        index++;
                    }

                    result = db.sExecuteSQL(store_procedure, parameters, values);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                result = ex.Message;
            }

            return result;
        }
    }
}

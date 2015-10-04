using System;
using System.Threading.Tasks;
using iPOS.DRO.Systems;
using iPOS.DTO.Systems;
using Newtonsoft.Json;

namespace iPOS.DAO.Systems
{
    public class SYS_tblImportFileConfigDAO : BaseDAO
    {
        public async static Task<SYS_tblImportFileConfigDRO> CheckValidImportTemplate(string url)
        {
            SYS_tblImportFileConfigDRO result = new SYS_tblImportFileConfigDRO();
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
                    var response_collection = JsonConvert.DeserializeObject<SYS_tblImportFileConfigDRO>(response_data + "");

                    if (response_collection != null)
                        result.ImportFileConfigItem = response_collection.ImportFileConfigItem;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                result.ResponseItem.Message = ex.Message;
            }

            return result;
        }

        public async static Task<SYS_tblImportFileConfigDRO> ImportDataRow(string url)
        {
            SYS_tblImportFileConfigDRO result = new SYS_tblImportFileConfigDRO();
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
                    var response_collection = JsonConvert.DeserializeObject<SYS_tblImportFileConfigDRO>(response_data + "");

                    if (response_collection != null)
                        result.ResponseItem = response_collection.ResponseItem;
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

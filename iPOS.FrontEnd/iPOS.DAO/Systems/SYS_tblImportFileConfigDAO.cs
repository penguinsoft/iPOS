using System;
using System.Threading.Tasks;
using iPOS.DRO.Systems;
using iPOS.DTO.Systems;
using Newtonsoft.Json;

namespace iPOS.DAO.Systems
{
    public class SYS_tblImportFileConfigDAO : BaseDAO
    {
        public async static Task<SYS_tblImportFileConfigDTO> CheckValidImportTemplate(string url)
        {
            try
            {
                var response_data = await HttpGet(url);
                var response_collection = JsonConvert.DeserializeObject<SYS_tblImportFileConfigDRO>(response_data + "");
                
                if (response_collection != null)
                    return response_collection.ImportFileConfigItem;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return null;
        }
    }
}

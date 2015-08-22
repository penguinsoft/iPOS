using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iPOS.DRO.Tools;
using iPOS.DTO.Tools;
using Newtonsoft.Json;

namespace iPOS.DAO.Tools
{
    public class OBJ_TableColumnDAO : BaseDAO
    {
        public async static Task<List<OBJ_TableColumnDTO>> GetTableColumnList(string url)
        {
            try
            {
                var response_data = await HttpGet(url);
                var response_collection = JsonConvert.DeserializeObject<OBJ_TableColumnDRO>(response_data + "");

                if (response_collection != null)
                    return response_collection.TableColumnObjectList;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return null;
        }
    }
}

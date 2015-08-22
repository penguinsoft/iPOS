using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iPOS.DAO.Tools;
using iPOS.DTO.Tools;

namespace iPOS.BUS.Tools
{
    public class OBJ_TableColumnBUS : BaseBUS
    {
        public async static Task<List<OBJ_TableColumnDTO>> GetTableColumnList(string username, string object_name)
        {
            string url = string.Format(@"{0}/GetTableColumnList?Username={1}&ObjectName={2}", GetBaseUrl(), username, object_name);

            return await OBJ_TableColumnDAO.GetTableColumnList(url);
        }
    }
}

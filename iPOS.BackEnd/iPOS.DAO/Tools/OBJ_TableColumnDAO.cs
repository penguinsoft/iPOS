using System;
using System.Collections.Generic;
using System.Data;
using iPOS.Core.Helper;
using iPOS.DTO.Tools;

namespace iPOS.DAO.Tools
{
    public interface IOBJ_TableColumnDAO
    {
        List<OBJ_TableColumnDTO> GetTableColumnList(string object_name);
    }

    public class OBJ_TableColumnDAO : BaseDAO, IOBJ_TableColumnDAO
    {
        public List<OBJ_TableColumnDTO> GetTableColumnList(string object_name)
        {
            List<OBJ_TableColumnDTO> result = new List<OBJ_TableColumnDTO>();
            try
            {
                DataTable data = db.GetDataTable("SYS_spCommon", new string[] { "ObjectName" }, new object[] { object_name });
                if (data != null && data.Rows.Count > 0)
                {
                    result = ConvertEngine.ConvertDataTableToObjectList<OBJ_TableColumnDTO>(data);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }
    }
}
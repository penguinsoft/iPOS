using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using iPOS.Core.Logger;
using System.Linq;

namespace iPOS.Core.Helper
{
    public class ConvertEngine
    {
        private static ILogEngine logger = new LogEngine();

        public static List<T> ConvertDataTableToObjectList<T>(DataTable data_source)
        {
            var column_names = data_source.Columns.Cast<DataColumn>()
                                    .Select(c => c.ColumnName)
                                    .ToList();
            var properties = typeof(T).GetProperties();
            return data_source.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                    if (column_names.Contains(pro.Name))
                    {
                        if (pro.PropertyType.Equals(typeof(Boolean)))
                        {
                            pro.SetValue(objT, row[pro.Name] == DBNull.Value ? false : Convert.ToBoolean(row[pro.Name]));
                        }
                        else pro.SetValue(objT, row[pro.Name] == DBNull.Value ? null : row[pro.Name]);
                    }
                return objT;
            }).ToList();
        }

        public static DataTable ConvertObjectListToDataTable<T>(IEnumerable<T> list)
        {
            try
            {
                DataTable dtResult = new DataTable();
                PropertyInfo[] oProps = null;

                if (list == null)
                    return null;

                foreach (T item in list)
                {
                    if (oProps == null)
                    {
                        oProps = ((Type)item.GetType()).GetProperties();
                        foreach (PropertyInfo oProp in oProps)
                        {
                            Type colType = oProp.PropertyType;
                            if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                                colType = colType.GetGenericArguments()[0];

                            dtResult.Columns.Add(new DataColumn(oProp.Name, colType));
                        }
                    }

                    DataRow dr = dtResult.NewRow();
                    foreach (PropertyInfo oProp in oProps)
                    {
                        var value = oProp.GetValue(item, null);
                        dr[oProp.Name] = value == null ? DBNull.Value : value;
                    }
                    dtResult.Rows.Add(dr);
                }

                return dtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public static DataRow ConvertObjectListToDataRow<T>(IEnumerable<T> list)
        {
            try
            {
                DataTable temp = ConvertObjectListToDataTable<T>(list);
                if (temp != null && temp.Rows.Count > 0)
                    return temp.Rows[0];

                return null;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }
    }
}

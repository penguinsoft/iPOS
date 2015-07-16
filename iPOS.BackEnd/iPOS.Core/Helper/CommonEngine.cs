using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace iPOS.Core.Helper
{
    public class CommonEngine
    {
        public static DateTime ConvertJsonStringToDateTime(string jsonTime)
        {
            if (!string.IsNullOrEmpty(jsonTime) && jsonTime.IndexOf("Date") > -1)
            {
                string milis = jsonTime.Substring(jsonTime.IndexOf("(") + 1);
                string sign = milis.IndexOf("+") > -1 ? "+" : "-";
                string hours = milis.Substring(milis.IndexOf(sign));
                milis = milis.Substring(0, milis.IndexOf(sign));
                hours = hours.Substring(0, hours.IndexOf(")"));
                return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(Convert.ToInt64(milis)).AddHours(Convert.ToInt64(hours) / 100);
            }

            return DateTime.Now;
        }

        public static List<T> ConvertDataTableToList<T>(DataTable data)
        {
            if (data == null)
                return null;

            try
            {
                var columnNames = data.Columns.Cast<DataColumn>()
                            .Select(c => c.ColumnName).ToList();
                var properties = typeof(T).GetProperties();

                return data.AsEnumerable().Select(row =>
                {
                    var objT = Activator.CreateInstance<T>();
                    foreach (var pro in properties)
                        if (columnNames.Contains(pro.Name))
                            pro.SetValue(objT, row[pro.Name]);

                    return objT;
                }).ToList();
            }
            catch 
            {
                return null;
            }
        }

        public static DataTable ConvertListToDataTable<T>(IEnumerable<T> list)
        {
            try
            {
                System.Data.DataTable dtReturn = new System.Data.DataTable();
                System.Reflection.PropertyInfo[] oProps = null;

                if (list == null)
                    return dtReturn;

                foreach (T rec in list)
                {
                    if (oProps == null)
                    {
                        oProps = ((Type)rec.GetType()).GetProperties();
                        foreach (System.Reflection.PropertyInfo pi in oProps)
                        {
                            Type colType = pi.PropertyType;
                            if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                            {
                                colType = colType.GetGenericArguments()[0];
                            }
                            dtReturn.Columns.Add(new System.Data.DataColumn(pi.Name, colType));
                        }
                    }

                    System.Data.DataRow dr = dtReturn.NewRow();
                    foreach (System.Reflection.PropertyInfo pi in oProps)
                    {
                        dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue(rec, null);
                    }
                    dtReturn.Rows.Add(dr);
                }
                return dtReturn;
            }
            catch 
            {
                return null;
            }
        }
    }
}

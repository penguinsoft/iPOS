using System;
using System.Data;
using System.Data.SqlClient;

namespace iPOS.Core.SQLServer
{
    public class SQLEngine : SQLDatabase
    {
        ///<summary>
        ///Get datatable from database by store procedure
        ///</summary>
        public DataTable GetDataTable(string strStoreName, string[] arrParams, object[] arrValues)
        {
            DataTable dt = new DataTable();
            try
            {
                OpenConnection();
                mCommand = new SqlCommand();
                mCommand.CommandText = strStoreName;
                mCommand.Connection = mConn;
                mCommand.CommandType = CommandType.StoredProcedure;
                if (arrParams != null && arrValues != null)
                {
                    if (arrParams.Length == arrValues.Length)
                    {
                        int _length = arrParams.Length - 1;
                        for (int i = 0; i <= _length; i++)
                        {
                            if (arrParams[i] + "" != "")
                                mCommand.Parameters.Add(new SqlParameter("@" + arrParams[i], arrValues[i]));
                        }
                    }
                }

                mDataAdapter = new SqlDataAdapter(mCommand);
                mDataAdapter.SelectCommand = mCommand;
                mDataAdapter.Fill(dt);
                CloseConnection();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
            finally
            {
                if (mCommand != null) mCommand.Dispose();
                if (mDataAdapter != null) mDataAdapter.Dispose();
            }

            return dt;
        }

        ///<summary>
        ///Get datatable from database by T-SQL query string
        ///</summary>
        public DataTable GetDataTable(string strQuery)
        {
            DataTable dt = new DataTable();
            try
            {
                OpenConnection();
                mCommand = new SqlCommand();
                mCommand.CommandText = strQuery;
                mCommand.Connection = mConn;
                mCommand.CommandType = CommandType.Text;

                mDataAdapter = new SqlDataAdapter(mCommand);
                mDataAdapter.SelectCommand = mCommand;
                mDataAdapter.Fill(dt);
                CloseConnection();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
            finally
            {
                if (mCommand != null) mCommand.Dispose();
                if (mDataAdapter != null) mDataAdapter.Dispose();
            }

            return dt;
        }

        ///<summary>
        ///Get data row from database by store procedure
        ///</summary>
        public DataRow GetDataRow(string strStoreName, string[] arrParams, object[] arrValues)
        {
            DataTable dt = new DataTable();
            dt = GetDataTable(strStoreName, arrParams, arrValues);

            if (dt != null && dt.Rows.Count > 0)
                return dt.Rows[0];
            return null;
        }

        ///<summary>
        ///Execute T-SQL and return message
        ///</summary>
        public string sExecuteSQL(string strStoreName, string[] arrParams, object[] arrValues)
        {
            try
            {
                OpenConnection();
                mCommand = new SqlCommand();
                mCommand.CommandText = strStoreName;
                mCommand.Connection = mConn;
                mCommand.CommandType = CommandType.StoredProcedure;
                mTransaction = mConn.BeginTransaction();
                mCommand.Transaction = mTransaction;

                if (arrParams != null && arrValues != null)
                {
                    if (arrParams.Length == arrValues.Length)
                    {
                        int _length = arrParams.Length - 1;
                        for (int i = 0; i <= _length; i++)
                        {
                            if (arrParams[i] + "" != "")
                                mCommand.Parameters.Add(new SqlParameter("@" + arrParams[i], arrValues[i]));
                        }
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }

                mCommand.Parameters.Add("@ReturnMess", SqlDbType.NVarChar, 255).Direction = ParameterDirection.InputOutput;
                mCommand.ExecuteNonQuery();
                mTransaction.Commit();
                CloseConnection();
                string strReturnMess = mCommand.Parameters["@ReturnMess"].Value.ToString();

                return strReturnMess;
            }
            catch (Exception ex)
            {
                if (mTransaction != null)
                    mTransaction.Dispose();

                logger.Error(ex);
                return ex.Message;
            }
            finally
            {
                if (mCommand != null) mCommand.Dispose();
                if (mDataAdapter != null) mDataAdapter.Dispose();
            }
        }

        ///<summary>
        ///Execute T-SQL
        ///</summary>
        public bool bExecuteSQL(string strStoreName, string[] arrParams, object[] arrValues)
        {
            try
            {
                OpenConnection();
                mCommand = new SqlCommand();
                mCommand.Connection = mConn;
                mCommand.CommandText = strStoreName;
                mCommand.CommandType = CommandType.StoredProcedure;
                mTransaction = mConn.BeginTransaction();
                mCommand.Transaction = mTransaction;

                if (arrParams != null && arrValues != null)
                {
                    if (arrParams.Length == arrValues.Length)
                    {
                        int _length = arrParams.Length - 1;
                        for (int i = 0; i <= _length; i++)
                        {
                            if (arrParams[i] + "" != "")
                                mCommand.Parameters.Add(new SqlParameter("@" + arrParams[i], arrValues[i]));
                        }
                    }
                }

                mCommand.ExecuteNonQuery();
                mTransaction.Commit();
                CloseConnection();
            }
            catch (Exception ex)
            {
                if (mTransaction != null)
                    mTransaction.Rollback();

                logger.Error(ex);
                return false;
            }
            finally
            {
                if (mCommand != null) mCommand.Dispose();
                if (mTransaction != null) mTransaction.Dispose();
            }

            return true;
        }
    }
}

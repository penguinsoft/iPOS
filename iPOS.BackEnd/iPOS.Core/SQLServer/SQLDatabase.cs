using System;
using System.Data;
using System.Data.SqlClient;
using iPOS.Core.Helper;

namespace iPOS.Core.SQLServer
{
    public class SQLDatabase
    {
        #region [Declare Variables]
        protected string mConnectionString;
        protected SqlConnection mConn;
        protected string mCommandText;
        protected int mTimeOut = 999999;
        protected SqlDataAdapter mDataAdapter;
        protected SqlCommand mCommand;
        protected SqlDataReader mDataReader;
        protected SqlTransaction mTransaction;
        //protected Helper.Configuration mConfig;
        #endregion

        public SQLDatabase()
        {
            mConnectionString = GetConnectionString();
            try
            {
                mConn = new SqlConnection(mConnectionString);
            }
            catch
            {

            }
        }

        protected string GetConnectionString()
        {
            if (Configuration.IsEncrypt.Equals("0"))
            {
                return string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", Configuration.ServerName, Configuration.Database, Configuration.UserName, Configuration.Password);
            }
            else return "";
        }

        public void OpenConnection()
        {
            try
            {
                if (mConn != null)
                    if (mConn.State != ConnectionState.Open)
                        mConn.Open();
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (mConn != null)
                    if (mConn.State != ConnectionState.Closed)
                    {
                        mConn.Close();
                    }
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}

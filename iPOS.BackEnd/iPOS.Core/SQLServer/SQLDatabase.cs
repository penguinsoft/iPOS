using System;
using System.Data;
using System.Data.SqlClient;
using iPOS.Core.Helper;
using iPOS.Core.Logger;

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
        protected ILogEngine logger;
        //protected Helper.Configuration mConfig;
        #endregion

        public SQLDatabase()
        {
            logger = new LogEngine();
            mConnectionString = GetConnectionString();
            try
            {
                mConn = new SqlConnection(mConnectionString);
            }
            catch (Exception ex)
            {
                logger.Error(@"Can't create new sql database engine because " + ex.Message);
            }
        }

        protected string GetConnectionString()
        {
            if (ConfigEngine.IsEncrypt.Equals("0"))
            {
                return string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", ConfigEngine.ServerName, ConfigEngine.Database, ConfigEngine.UserName, ConfigEngine.Password);
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
                logger.Error(ex);
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
                logger.Error(ex);
                return;
            }
        }
    }
}

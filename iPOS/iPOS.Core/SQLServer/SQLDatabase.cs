using System;
using System.Data;
using System.Data.SqlClient;

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
        protected Helper.Configuration mConfig;
        #endregion

        public SQLDatabase()
        {
            mConfig = new Helper.Configuration();
            mConnectionString = DecryptConnectionString();
            mConn = new SqlConnection(mConnectionString);
        }

        protected string GetConnectionString(string strServerName, string strUsername, string strPassword, string strDatabase)
        {
            string strResult = "";
            strResult += "Data Source=" + strServerName;
            strResult += ";Initial Catalog=" + strDatabase;
            strResult += ";User ID=" + strUsername;
            strResult += ";Password=" + strPassword;
            strResult += ";";

            return strResult;
        }

        protected string DecryptConnectionString()
        {
            string strResult = "";
            if (mConfig.IsEncryptPassword == null || mConfig.IsEncryptPassword.Equals("") || mConfig.IsEncryptPassword.Equals("0"))
                strResult = GetConnectionString(mConfig.ServerName, mConfig.UserName, mConfig.Password, mConfig.DatabaseName);
            else
            {
                string strDUsername = "", strDPassword = "";
                //strDUsername = clsEncryption.Decrypt(mConfig.Username);
                //strDPassword = clsEncryption.Decrypt(mConfig.Password);
                strResult = GetConnectionString(mConfig.ServerName, strDUsername, strDPassword, mConfig.DatabaseName);
            }

            return strResult;
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
                Logger.Logger.Error(ex);
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
                Logger.Logger.Error(ex);
                return;
            }
        }
    }
}

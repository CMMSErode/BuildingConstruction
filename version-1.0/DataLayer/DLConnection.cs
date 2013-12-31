using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using UtilityLayer;

namespace DataLayer
{
    public class DLConnection
    {
        public SqlConnection con;
        public SqlTransaction tran;

        //string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["connstr"].ToString();
        //string connstr = Common.ObtainConfig("connstr");

        public SqlConnection CreatConnection()
        {

            string connstr = Common.ObtainConfig("connstr");
            if (con == null)
            {
                con = new SqlConnection(connstr);
                con.Open();
            }
            else if(con != null && con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public SqlConnection CloseConnection()
        {
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return con;
        }
        public void BeginTransaction()
        {
            CreatConnection();
            tran = con.BeginTransaction(IsolationLevel.ReadUncommitted);
        }
        public void CommitTransaction()
        {
            tran.Commit();
            //trans.Dispose();
            CloseConnection();
        }
        public void RollbackTransaction()
        {
            tran.Rollback();
            //trans.Dispose();
            CloseConnection();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
//using System.Data.OleDb;
namespace ApnaBank
{
   
    class BuisnessLogic
    {
        SqlCommand cmd;
        SqlConnection  conn;
        public void openConnection()
        {
            string strusers = ConfigurationManager.ConnectionStrings["newcon"].ToString();
            conn = new SqlConnection (strusers);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
        } 
        public void closeConnection()
        {
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }
        public SqlDataReader SelectQuery(string query)
        {
            openConnection();
            cmd = new SqlCommand(query, conn);
            SqlDataReader rec = cmd.ExecuteReader();
            return rec;
        }
        public void NonQuery(String query)
        {
            openConnection();
            cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            closeConnection();
        }
        public DataSet Adapter(string query)
        {
            openConnection();
            cmd = new SqlCommand(query, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            closeConnection();
            return ds;
            /* dissconnected database access*/
        }
    }

}

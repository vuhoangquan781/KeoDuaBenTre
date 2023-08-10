using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication2.DAO
{
    class AccountDAO
    {
        public AccountDAO() { }
        public SqlConnection conn;
        public SqlCommand cmd;

        string strketnoi1 = @"Data Source =localhost;Initial Catalog = QL_KEODUA; Integrated Security = True";
        public SqlConnection ketnoiCN = new SqlConnection(@"Data Source=localhost;Initial Catalog=QL_KEODUA;Integrated Security=True");
        public void Openconnect()
        {

            string ketnoi1 = strketnoi1;

            conn = new SqlConnection(strketnoi1);
            conn.Open();
        }
        public void Closeconnect()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }
        public void query1(string query)
        {
            Openconnect();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            Closeconnect();
        }
        public DataTable returnquery(string query)
        {
            Openconnect();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable tb = new DataTable();
            da.Fill(tb);
            Closeconnect();
            return tb;
        }
        public DataTable taobang(string sql)
        {
            Openconnect();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dt = ds.Tables[0];
            Closeconnect();
            return dt;
        }
    }
}

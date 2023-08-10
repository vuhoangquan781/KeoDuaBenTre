using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DXApplication2.DAO
{
    class DataProvider
    {
        static string provider = @"Data Source=LAPTOP-QDB8TS3B\VUHOANGQUAN07;Initial Catalog=QL_KEODUA;Integrated Security=True";
        SqlConnection connect = new SqlConnection(provider);
        private string sql;

        public DataProvider()
        {

        }

        public DataTable GetData(string sql)
        {
            DataTable rs = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connect);
            adapter.Fill(rs);
            return rs;
        }
        public void Excute(string sql)
        {
            connect.Open();
            SqlCommand command = new SqlCommand(sql, connect);
            command.ExecuteNonQuery();
            connect.Close();
        }
    }
}

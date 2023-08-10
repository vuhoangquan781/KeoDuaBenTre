using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DXApplication2
{
    class ketnoi
    {
        public SqlConnection connsql = new SqlConnection();
        public void connect()
        {
            string ketnoi = @"Data Source=localhost;Initial Catalog=QL_KEODUA;Integrated Security=True";
            connsql.ConnectionString = ketnoi;
            if (connsql.State == ConnectionState.Closed)
            {
                connsql.Open();
            }
            else
            {
                connsql.Close();
            }
        }
    }
}

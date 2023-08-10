using QLKeoDua.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace QLKeoDua.BUS
{
    class NHAPPBUS
    {
        connect dbconnect = new connect();

        public DataTable getdata()
        {
            dbconnect.Openconnect();
            DataTable table = new DataTable();
            table = dbconnect.returnquery("select MANPP as [Mã Nhà Phân Phối], TENNPP as [Tên Nhà Phân Phối], MAKVC as [Mã Khu Vực Con] from NHAPP");
            
            dbconnect.Closeconnect();
            return table;
        }
        public void InsertNHAPP(NHAPP nhapp)
        {
            string insert = "insert into NHAPP(MANPP,TENNPP,MAKVC) values(";
            insert += "N'" + nhapp.manpp + "',";
            insert += "N'" + nhapp.tennpp + "',";
            insert += "N'" + nhapp.makvc + "')";

            dbconnect.query1(insert);

        }
        public void DeleteNHAPP(string manpp)
        {
            string delete = "delete from NHAPP where MANPP='" + manpp + "'";
            dbconnect.query1(delete);
        }
        public void UpdateNHAPP(NHAPP nhapp, string manpp)
        {
            string update = "update NHAPP set ";

            update += "TENNPP=N'" + nhapp.tennpp + "',";
            update += "MAKVC=N'" + nhapp.makvc + "'";
            update += "where MANPP='" + manpp + "'";
            dbconnect.query1(update);
        }
    }
}

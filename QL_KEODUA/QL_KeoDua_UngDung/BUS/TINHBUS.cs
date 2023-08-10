using QLKeoDua.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKeoDua.BUS
{
    class TINHBUS
    {
        connect dbconnect = new connect();
        public DataTable getdata()
        {
            dbconnect.Openconnect();
            DataTable table = new DataTable();
            table = dbconnect.returnquery("select MAKVC as [Mã Khu Vực Con], TENKVC as [Tên Khu Vực Con], MAKV as [Mã Khu Vực] from TINH");

            dbconnect.Closeconnect();
            return table;
        }
        public void InsertTINH(TINH tinh)
        {
            string insert = "insert into TINH(MAKVC,TENKVC,MAKV) values(";
            insert += "N'" + tinh.makvc + "',";
            insert += "N'" + tinh.tenkvc + "',";
            insert += "N'" + tinh.makv + "')";

            dbconnect.query1(insert);

        }
        public void DeleteTINH(string makvc)
        {
            string delete = "delete from TINH where MAKVC='" + makvc + "'";
            dbconnect.query1(delete);
        }
        public void UpdateTINH(TINH tinh, string makvc)
        {
            string update = "update TINH set ";

            update += "TENKVC=N'" + tinh.tenkvc + "',";
            update += "MAKV=N'" + tinh.makv + "'";
            update += "where MAKVC='" + makvc + "'";
            dbconnect.query1(update);
        }
    }
}

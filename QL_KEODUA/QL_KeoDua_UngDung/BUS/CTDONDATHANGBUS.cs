using QLKeoDua.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.BUS
{
    class CTDONDATHANGBUS
    {
        connect dbconnect = new connect();

        public DataTable getdata()
        {
            dbconnect.Openconnect();
            DataTable table = new DataTable();
            table = dbconnect.returnquery("select MADDH as [Mã đơn đặt hàng], MASP as [Mã khách], SOLUONG as [Số lượng] from CTDONDATHANG");
            dbconnect.Closeconnect();
            return table;
        }

        public void InsertCTDDH(CTDONDATHANG ctdh)
        {
            string insert = "insert into CTDONDATHANG(MADDH,MASP,SOLUONG) values(";
            insert += "N'" + ctdh.MADDH1 + "',";
            insert += "N'" + ctdh.MASP1 + "',";
            insert += "" + ctdh.SOLUONG1 + ")";

            dbconnect.query1(insert);

        }

        public void DeleteCTDDH(string maddh)
        {
            string delete = "delete from CTDONDATHANG where MADDH='" + maddh + "'";
            dbconnect.query1(delete);
        }

        public void UpdateCTDDH(CTDONDATHANG ctdh, string maddh)
        {
            string update = "update CTDONDATHANG set ";

            update += "MASP=N'" + ctdh.MASP1 + "',";
            update += "SOLUONG=" + ctdh.SOLUONG1 + "";
            update += "where MADDH='" + maddh + "'";
            dbconnect.query1(update);
        }
    }
}

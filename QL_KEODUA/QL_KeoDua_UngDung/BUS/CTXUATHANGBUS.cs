using QLKeoDua.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.BUS
{
    class CTXUATHANGBUS
    {
        connect dbconnect = new connect();
        public DataTable getdata()
        {
            dbconnect.Openconnect();
            DataTable table = new DataTable();
            table = dbconnect.returnquery("select MAXH as [Mã xuất hàng], MASP as [Mã sản phẩm], SOLUONG as [Số lượng], TRONGLUONG as [Trọng lượng], GIABAN as [Giá bán] from CTXUATHANG");
            dbconnect.Closeconnect();
            return table;
        }

        public void InsertCTXUATHANG(CTXUATHANG ctxh)
        {
            string insert = "insert into CTXUATHANG(MAXH,MASP,SOLUONG,TRONGLUONG,GIABAN) values(";
            insert += "N'" + ctxh.MAXH1 + "',";
            insert += "N'" + ctxh.MASP1 + "',";
            insert += "" + ctxh.SOLUONG1 + ",";
            insert += "" + ctxh.TRONGLUONG1 + ",";
            insert += "" + ctxh.GIABAN1 + ")";

            dbconnect.query1(insert);

        }
        public void DeleteCTXUATHANG(string maxh, string masp)
        {
            string delete = "delete from CTXUATHANG where MAXH=N'" + maxh + "' and MASP=N'"+masp+"'";
            dbconnect.query1(delete);
        }
        public void UpdateCTXUATHANG(CTXUATHANG ctxh, string maxh, string masp)
        {
            string update = "update CTXUATHANG set ";

            update += "SOLUONG=N'" + ctxh.SOLUONG1 + "',";
            update += "TRONGLUONG='" + ctxh.TRONGLUONG1 + "',";
            update += "GIABAN=" + ctxh.GIABAN1 + "";
            update += "where MAXH=N'" + maxh + "' and MASP=N'"+masp+"'";
            dbconnect.query1(update);
        }
    }
}

using QLKeoDua.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.BUS
{
    class XUATHANGBUS
    {
        connect dbconnect = new connect();

        public DataTable getdata()
        {
            dbconnect.Openconnect();
            DataTable table = new DataTable();
            table = dbconnect.returnquery("select MAXH as [Mã xuất hàng], MANV as [Mã nhân viên], NGAY as [Ngày], DOANHTHU as [Doanh thu] from XUATHANG");
            dbconnect.Closeconnect();
            return table;
        }

        public void InsertXUATHANG(XUATHANG xh)
        {
            string insert = "insert into XUATHANG(MAXH,MANV,NGAY,DOANHTHU) values(";
            insert += "N'" + xh.MAXH1 + "',";
            insert += "N'" + xh.MANV1 + "',";
            insert += "'" + xh.NGAY1 + "',";
            insert += "" + xh.DOANHTHU1 + ")";

            dbconnect.query1(insert);

        }
        public void DeleteXUATHANG(string maxh)
        {
            string delete = "delete from XUATHANG where MAXH='" + maxh + "'";
            dbconnect.query1(delete);
        }
        public void UpdateXUATHANG(XUATHANG xh, string maxh)
        {
            string update = "update XUATHANG set ";

            update += "MANV=N'" + xh.MANV1 + "',";
            update += "NGAY='" + xh.NGAY1 + "',";
            update += "DOANHTHU=" + xh.DOANHTHU1 + "";
            update += "where MAXH='" + maxh + "'";
            dbconnect.query1(update);
        }
        public void SelectMaSP(XUATHANG xh)
        {
            string select = "select GIABAN from SANPHAM";
            dbconnect.query1(select);
        }
    }
}

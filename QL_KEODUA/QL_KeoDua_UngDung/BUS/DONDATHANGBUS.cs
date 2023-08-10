using QLKeoDua.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.BUS
{
    class DONDATHANGBUS
    {
        connect dbconnect = new connect();

        public DataTable getdata()
        {
            dbconnect.Openconnect();
            DataTable table = new DataTable();
            table = dbconnect.returnquery("select MADDH as [Mã đơn đặt hàng], MAKHACH as [Mã khách], MANPP as [Mã nhà phân phối], NGAY as [Ngày], SOTIENHD as [Số tiền hóa đơn], NPP6PT as [Giảm giá], SOTHANHTOAN as [Số thanh toán] from DONDATHANG");
            dbconnect.Closeconnect();
            return table;
        }

        public void InsertDDH(DONDATHANG dh)
        {
            string insert = "insert into DONDATHANG(MADDH,MAKHACH,MANPP,NGAY,SOTIENHD,NPP6PT,SOTHANHTOAN) values(";
            insert += "N'" + dh.MADDH1 + "',";
            insert += "N'" + dh.MAKHACH1 + "',";
            insert += "N'" + dh.MANPP1 + "',";
            insert += "'" + dh.NGAY1 + "',";
            insert += "" + dh.SOTIENHD1 + ",";
            insert += "" + dh.NPP6PT1 + ",";
            insert += "" + dh.SOTHANHTOAN1 + ")";

            dbconnect.query1(insert);

        }
        public void DeleteDDH(string maddh)
        {
            string delete = "delete from DONDATHANG where MADDH='" + maddh + "'";
            dbconnect.query1(delete);
        }
        public void UpdateDDH(DONDATHANG dh, string maddh)
        {
            string update = "update DONDATHANG set ";

            update += "MAKHACH=N'" + dh.MAKHACH1 + "',";
            update += "MANPP=N'" + dh.MANPP1 + "',";
            update += "NGAY='" + dh.NGAY1 + "',";
            update += "SOTIENHD=" + dh.SOTIENHD1 + ",";
            update += "NPP6PT=" + dh.NPP6PT1 + ",";
            update += "SOTHANHTOAN=" + dh.SOTHANHTOAN1 + "";
            update += "where MADDH='" + maddh + "'";
            dbconnect.query1(update);
        }
    }
}

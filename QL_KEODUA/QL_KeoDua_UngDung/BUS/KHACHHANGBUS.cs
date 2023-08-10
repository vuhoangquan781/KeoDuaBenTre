using QLKeoDua.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKeoDua.BUS
{
    class KHACHHANGBUS
    {
        connect dbconnect = new connect();

        public DataTable getdata()
        {
            dbconnect.Openconnect();
            DataTable table = new DataTable();
            table = dbconnect.returnquery("select MAKHACH as [Mã khách hàng], TENKHACH as [Tên khách hàng], GIOITINH as [Giới tính], NGAYSINH as [Ngày sinh], NGHENGHIEP as [Nghề nghiệp], SDT as [Số điện thoại] from KHACHHANG");
            dbconnect.Closeconnect();
            return table;
        }

        public void InsertKHACHHANG(KHACHHANG khachhang)
        {
            string insert = "insert into KHACHHANG(MAKHACH,TENKHACH,GIOITINH,NGAYSINH,NGHENGHIEP,SDT) values(";
            insert += "N'" + khachhang.makhach + "',";
            insert += "N'" + khachhang.tenkhach + "',";
            insert += "N'" + khachhang.gioitinh + "',";
            insert += "N'" + khachhang.ngaysinh + "',";
            insert += "N'" + khachhang.nghenghiep + "',";
            insert += "N'" + khachhang.sdt + "')";

            dbconnect.query1(insert);

        }
        public void DeleteKHACHHANG(string makh)
        {
            string delete = "delete from KHACHHANG where MAKHACH='" + makh + "'";
            dbconnect.query1(delete);
        }
        public void UpdateKHACHHANG(KHACHHANG khachhang, string makh)
        {
            string update = "update KHACHHANG set ";

            update += "TENKHACH=N'" + khachhang.tenkhach + "',";
            update += "GIOITINH='" + khachhang.gioitinh + "', ";
            update += "NGAYSINH=N'" + khachhang.ngaysinh + "', ";
            update += "NGHENGHIEP='" + khachhang.nghenghiep + "', ";
            update += "SDT=N'" + khachhang.sdt + "' ";

            update += "where MAKHACH='" + makh + "'";
            dbconnect.query1(update);
        }
    }
}

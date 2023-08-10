using QLKeoDua.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.BUS
{
    class NHANVIENBUS
    {
        connect dbconnect = new connect();

        public DataTable getdata()
        {
            dbconnect.Openconnect();
            DataTable table = new DataTable();
            table = dbconnect.returnquery("select MANV as [Mã nhân viên], TENNV as [Tên nhân viên], GIOITINH as [Giới tính], DIACHI as [Địa chỉ], MACN as [Mã chi nhánh] from NHANVIEN");
            dbconnect.Closeconnect();
            return table;
        }

        public void InsertNV(NHANVIEN nv)
        {
            string insert = "insert into NHANVIEN(MANV,TENNV,GIOITINH,DIACHI,MACN) values(";
            insert += "N'" + nv.MANV1 + "',";
            insert += "N'" + nv.TENV1 + "',";
            insert += "N'" + nv.GIOITINH1 + "',";
            insert += "N'" + nv.DIACHI1 + "',";
            insert += "N'" + nv.MACN1 + "')";

            dbconnect.query1(insert);

        }
        public void DeleteNV(string manv)
        {
            string delete = "delete from NHANVIEN where MANV='" + manv + "'";
            dbconnect.query1(delete);
        }
        public void UpdateNV(NHANVIEN nv, string manv)
        {
            string update = "update NHANVIEN set ";

            update += "TENNV=N'" + nv.TENV1 + "',";
            update += "GIOITINH=N'" + nv.GIOITINH1 + "',";
            update += "DIACHI=N'" + nv.DIACHI1 + "',";
            update += "MACN=N'" + nv.MACN1 + "'";
            update += "where MANV='" + manv + "'";
            dbconnect.query1(update);
        }
    }
}

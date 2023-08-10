using QLKeoDua.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.BUS
{
    class CAPQUYENBUS
    {
        connect dbconnect = new connect();
        public DataTable getdata()
        {
            dbconnect.Openconnect();
            DataTable table = new DataTable();
            table = dbconnect.returnquery("select TenDangNhap as [Tên Đăng Nhập], MatKhau as [Mật Khẩu], TenNV as [Tên Nhân Viên], SDT as [Số Điện Thoại], EMAIL as [Email], ChucVu as [Chức Vụ], Quyen as [Quyền] from ACCOUNT");
            dbconnect.Closeconnect();
            return table;
        }

        public void InsertCQ(CAPQUYEN cq)
        {
            string insert = "insert into ACCOUNT(TenDangNhap,MatKhau,TenNV,SDT,EMAIL,ChucVu,Quyen) values(";
            insert += "'" + cq.TenDangNhap1 + "',";
            insert += "'" + cq.MatKhau1 + "',";
            insert += "N'" + cq.TenNV1 + "',";
            insert += "'" + cq.SDT1 + "',";
            insert += "'" + cq.Email1 + "',";
            insert += "N'" + cq.ChucVu1 + "',";
            insert += "" + cq.Quyen1 + ")";

            dbconnect.query1(insert);

        }
        public void DeleteCQ(string tdn)
        {
            string delete = "delete from ACCOUNT where TenDangNhap='" + tdn + "'";
            dbconnect.query1(delete);
        }
        public void UpdateCQ(CAPQUYEN cq, string tdn)
        {
            string update = "update ACCOUNT set ";

            update += "MatKhau=N'" + cq.MatKhau1 + "',";
            update += "TenNV=N'" + cq.TenNV1 + "',";
            update += "SDT='" + cq.SDT1 + "',";
            update += "EMAIL='" + cq.Email1 + "',";
            update += "ChucVu=N'" + cq.ChucVu1 + "',";
            update += "Quyen=" + cq.Quyen1 + "";
            update += "where TenDangNhap='" + tdn + "'";
            dbconnect.query1(update);
        }
        //public DataTable LoadCapQuyen()
        //{
        //    string sqlString = @"select TenDangNhap,MatKhau,SDT,EMAIL,ChucVu from ACCOUNT ";
        //    return cn.returnquery(sqlString);
        //}
        //public DataTable LoadCCB()
        //{
        //    string sql = @"select ChucVu from Account";
        //    return cn.returnquery(sql);
        //}
        //public DataTable GetList()
        //{
        //    return LoadCapQuyen();
        //}
        //public DataTable GetCCB()
        //{
        //    return LoadCCB();
        //}
    }
}

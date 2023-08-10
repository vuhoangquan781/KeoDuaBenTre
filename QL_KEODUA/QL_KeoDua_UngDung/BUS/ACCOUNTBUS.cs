using QLKeoDua.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.BUS
{
    class ACCOUNTBUS
    {
        connect cn = new connect();
        public DataTable getdata()
        {
            cn.Openconnect();
            DataTable table = new DataTable();
            table = cn.returnquery("select TenDangNhap as [Tên Đăng Nhập], MatKhau as [Mật Khẩu],TenNV as [Tên Nhân Viên], SDT as [Số Điện Thoại], EMAIL as [Email], ChucVu as [Chức Vụ] from ACCOUNT");
            cn.Closeconnect();
            return table;
        }
        public void InsertAccount(ACCOUNT account)
        {
            string insert = "insert into ACCOUNT(TenDangNhap,MatKhau,TenNV,SDT,EMAIL,ChucVu) values(";
            insert += "N'" + account.Tendangnhap + "',";
            insert += "N'" + account.Matkhau + "',";
            insert += "N'" + account.Sdt + "',";
            insert += "N'" + account.Chucvu + "')";
            cn.query1(insert);

        }
        public void DeleteAccount(string tdn)
        {
            string delete = "delete from ACCOUNT where TenDangNhap='" + tdn + "'";
            cn.query1(delete);
        }
        public void UpdateAccount(ACCOUNT account, string tdn)
        {
            string update = "update ACCOUNT set ";

            update += "MatKhau=N'" + account.Matkhau + "',";
            update += "SDT='" + account.Sdt + "', ";
            update += "ChuVu=N'" + account.Chucvu + "' ";

            update += "where TenDangNhap='" + tdn + "'";
            cn.query1(update);
        }

        public void Dangky(ACCOUNT account)
        {
            string insert = "insert into ACCOUNT(TenDangNhap,MatKhau,SDT,ChucVu,Quyen) values(";
            insert += "N'" + account.Tendangnhap + "',";
            insert += "N'" + account.Matkhau + "',";
            insert += "N'" + account.Sdt + "',";
            insert += "N'Nhân Viên',";
            insert += "" + int.Parse("1") + ")";
            cn.query1(insert);

        }
    }
}

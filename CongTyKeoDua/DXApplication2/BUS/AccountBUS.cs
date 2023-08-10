using DXApplication2.DAO;
using DXApplication2.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication2.BUS
{
    class AccountBUS
    {
        AccountDAO acc = new AccountDAO();
        public DataTable getdata()
        {
            acc.Openconnect();
            DataTable table = new DataTable();
            table = acc.returnquery("select TenDangNhap as [Tên Đăng Nhập], MatKhau as [Mật Khẩu], SDT as [Số Điện Thoại], ChuVu as [Chức Vụ] from ACCOUNT");
            acc.Closeconnect();
            return table;
        }
        public void InsertAccount(ACCOUNT account)
        {
            string insert = "insert into ACCOUNT(TenDangNhap,MatKhau,SDT,ChucVu) values(";
            insert += "N'" + account.tendangnhap + "',";
            insert += "N'" + account.matkhau + "',";
            insert += "N'" + account.sdt + "',";
            insert += "N'" + account.chucvu + "')";
            acc.query1(insert);

        }
        public void DeleteAccount(string tdn)
        {
            string delete = "delete from ACCOUNT where TenDangNhap='" + tdn + "'";
            acc.query1(delete);
        }
        public void UpdateAccount(ACCOUNT account, string tdn)
        {
            string update = "update ACCOUNT set ";

            update += "MatKhau=N'" + account.matkhau + "',";
            update += "SDT='" + account.sdt + "', ";
            update += "ChuVu=N'" + account.chucvu + "' ";

            update += "where TenDangNhap='" + tdn + "'";
            acc.query1(update);
        }

        public void Dangky(ACCOUNT account)
        {
            string insert = "insert into ACCOUNT(TenDangNhap,MatKhau,SDT,ChucVu,Quyen) values(";
            insert += "N'" + account.tendangnhap + "',";
            insert += "N'" + account.matkhau + "',";
            insert += "N'" + account.sdt + "',";
            insert += "N'Nhân Viên',";
            insert += ""+int.Parse("1")+")";
            acc.query1(insert);

        }
    }
}

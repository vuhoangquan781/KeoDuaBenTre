using QLKeoDua.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.BUS
{
    class DOIMKBUS
    {
        connect cn = new connect();
        public void ChangePassWord(THANHVIEN _tv)
        {
            string sql = string.Format("update ACCOUNT set MatKhau = '{0}' where TenDangNhap = '{1}'", _tv.MatKhau, _tv.TenDangNhap);
            cn.query1(sql);
        }
        public bool CheckExist(string _tdn, string _mkc)
        {
            string sql = string.Format("select* from ACCOUNT where MatKhau = '{0}' and TenDangNhap = '{1}'", _mkc, _tdn);
            if (cn.returnquery(sql).Rows.Count > 0)
                return true;
            return false;
        }
        public void DoiMatKhau(THANHVIEN _tv)
        {
            ChangePassWord(_tv);
        }
        public bool CheckExist1(string _tdn, string _mkc)
        {
            return CheckExist(_tdn, _mkc);

        }
    }
}

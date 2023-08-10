using QLKeoDua.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.BUS
{
    class THANHVIENBUS
    {
        connect cn = new connect();
        THANHVIEN tv = new THANHVIEN();
        public bool login(string _tk, string _mk)
        {
            if (cn.taobang("select* from ACCOUNT where TenDangNhap = '" + _tk + "' and MatKhau = '" + _mk + "'").Rows.Count > 0)
                return true;
            return false;
        }
        public bool DangNhap(string _tk, string _mk)
        {
            if (login(_tk, _mk) == true)
                return true;
            return false;
        }
    }
}

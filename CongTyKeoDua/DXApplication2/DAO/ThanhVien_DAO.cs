using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DXApplication2.DTO;

namespace DXApplication2.DAO
{
    class ThanhVien_DAO:DataProvider
    {
        public bool login(string _tk, string _mk)
        {
            if (GetData("select* from ACCOUNT where TenDangNhap = '" + _tk + "' and MatKhau = '" + _mk + "'").Rows.Count > 0)
                return true;
            return false;
        }


    }
}

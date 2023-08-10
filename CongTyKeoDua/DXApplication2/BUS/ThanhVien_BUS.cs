using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DXApplication2.DAO;
using DXApplication2.DTO;

namespace DXApplication2.BUS
{
    class ThanhVien_BUS
    {
        ThanhVien_DAO tvDao = new ThanhVien_DAO();
        public bool DangNhap(string _tk, string _mk)
        {
            if (tvDao.login(_tk, _mk) == true)
                return true;
            return false;
        }

    }
}

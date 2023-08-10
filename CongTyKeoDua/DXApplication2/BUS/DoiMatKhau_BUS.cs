using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DXApplication2.DAO;
using DXApplication2.DTO;

namespace DXApplication2.BUS
{
    class DoiMatKhau_BUS
    {
        DoiMatKhau_DAO mkDao = new DoiMatKhau_DAO();
        public void DoiMatKhau(ThanhVien_DTO _tv)
        {
            mkDao.ChangePassWord(_tv);
        }
        public bool CheckExist(string _tdn, string _mkc)
        {
            return mkDao.CheckExist(_tdn, _mkc);

        }
    }
}

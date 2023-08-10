using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DXApplication2.DTO;
using System.Data;
using DXApplication2.DTO;

namespace DXApplication2.DAO
{
    class CapQuyen:DataProvider
    {

        public DataTable LoadCapQuyen()
        {
            string sqlString = @"select TenDangNhap,MatKhau,SDT,EMAIL,ChucVu from ACCOUNT ";
            return GetData(sqlString);     
        }
        public DataTable LoadCCB()
        {
            string sql = @"select ChucVu from Account";
            return GetData(sql);
        }
    }
}

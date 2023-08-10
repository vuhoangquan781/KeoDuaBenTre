using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DXApplication2.DTO;
using DXApplication2.DAO;
using System.Data;

namespace DXApplication2.BUS
{
    class CapQuyen_BUS
    {
        CapQuyen CQ = new CapQuyen();
        public DataTable GetList()
        {
            return CQ.LoadCapQuyen();
        }
        public DataTable GetCCB()
        {
            return CQ.LoadCCB();
        }
    }
}

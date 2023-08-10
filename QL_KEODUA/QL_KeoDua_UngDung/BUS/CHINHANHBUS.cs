using QLKeoDua.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.BUS
{
    class CHINHANHBUS
    {
        connect dbconnect = new connect();

        public DataTable getdata()
        {
            dbconnect.Openconnect();
            DataTable table = new DataTable();
            table = dbconnect.returnquery("select MACN as [Mã chi nhánh], TENCN as [Tên chi nhánh] from CHINHANH");
            dbconnect.Closeconnect();
            return table;
        }

        public void InsertCHINHANH(CHINHANH cn)
        {
            string insert = "insert into CHINHANH(MACN,TENCN) values(";
            insert += "N'" + cn.MACN1 + "',";
            insert += "N'" + cn.TENCN1 + "')";

            dbconnect.query1(insert);

        }
        public void DeleteCHINHANH(string macn)
        {
            string delete = "delete from CHINHANH where MACN='" + macn + "'";
            dbconnect.query1(delete);
        }
        public void UpdateCHINHANH(CHINHANH cn, string macn)
        {
            string update = "update CHINHANH set ";

            update += "TENCN=N'" + cn.TENCN1 + "'";
            update += "where MACN='" + macn + "'";
            dbconnect.query1(update);
        }
    }
}

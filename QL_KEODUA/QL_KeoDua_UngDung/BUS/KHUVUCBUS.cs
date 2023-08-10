using QLKeoDua.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QLKeoDua.BUS
{
    class KHUVUCBUS
    {
        connect dbconnect = new connect();

        public DataTable getdata()
        {
            dbconnect.Openconnect();
            DataTable table = new DataTable();
            table = dbconnect.returnquery("select MAKV as [Mã Khu Vực], TENKV as [Tên Khu Vực] from KHUVUC");
            dbconnect.Closeconnect();
            return table;
        }
        public void InsertKHUVUC(KHUVUC khuvuc)
        {
            string insert = "insert into KHUVUC(MAKV,TENKV) values(";
            insert += "N'" + khuvuc.makv + "',";
            insert += "N'" + khuvuc.tenkv + "')";

            dbconnect.query1(insert);

        }
        public void DeleteKHUVUC(string makv)
        {
            string delete = "delete from KHUVUC where MAKV='" + makv + "'";
            dbconnect.query1(delete);
        }
        public void UpdateKHUVUC(KHUVUC khuvuc, string makv)
        {
            string update = "update KHUVUC set ";

            update += "TENKV=N'" + khuvuc.tenkv + "'";

            update += "where MAKV='" + makv + "'";
            dbconnect.query1(update);
        }
    }
}

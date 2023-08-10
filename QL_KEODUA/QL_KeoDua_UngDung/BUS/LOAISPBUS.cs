using QLKeoDua.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKeoDua.BUS
{
    class LOAISPBUS
    {
        connect dbconnect = new connect();
        public DataTable getdata()
        {
            dbconnect.Openconnect();
            DataTable table = new DataTable();
            table = dbconnect.returnquery("select MALOAISP as [Mã Loại Sản Phẩm], TENLOAISP as [Tên Loại Sản Phẩm] from LOAISP");

            dbconnect.Closeconnect();
            return table;
        }
        public void InsertLSP(LOAISP lsp)
        {
            string insert = "insert into LOAISP(MALOAISP,TENLOAISP) values(";
            insert += "N'" + lsp.MALOAISP1 + "',";
            insert += "N'" + lsp.TENLOAISP1 + "')";

            dbconnect.query1(insert);

        }
        public void DeleteLSP(string malsp)
        {
            string delete = "delete from LOAISP where MALOAISP='" + malsp + "'";
            dbconnect.query1(delete);
        }
        public void UpdateLSP(LOAISP lsp, string malsp)
        {
            string update = "update LOAISP set ";

            update += "TENLOAISP=N'" + lsp.TENLOAISP1 + "'";
            update += "where MALOAISP='" + malsp + "'";
            dbconnect.query1(update);
        }
    }
}

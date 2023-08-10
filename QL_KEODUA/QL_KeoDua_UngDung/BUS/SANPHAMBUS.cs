using QLKeoDua.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QLKeoDua.BUS
{
    class SANPHAMBUS
    {
        connect dbconnect = new connect();
        public DataTable getdata()
        {
            dbconnect.Openconnect();
            DataTable table = new DataTable();
            table = dbconnect.returnquery("select MASP as [Mã Sản Phẩm], TENSP as [Tên Sản Phẩm], MALOAISP as [Mã Loại Sản Phẩm], TRONGLUONG as [Trọng Lượng],QUYCACH as [Quy Cách],KHUYENMAI as [Khuyến Mãi],GIABAN as [Giá Bán] from SANPHAM");

            dbconnect.Closeconnect();
            return table;
        }
        public void InsertSP(SANPHAM sp)
        {
            string insert = "insert into SANPHAM(MASP,TENSP,MALOAISP,TRONGLUONG,QUYCACH,KHUYENMAI,GIABAN) values(";
            insert += "N'" + sp.MASP1 + "',";
            insert += "N'" + sp.TENSP1 + "',";
            insert += "N'" + sp.MALOAISP1 + "',";
            insert += "N'" + sp.TRONGLUONG1 + "',";
            insert += "N'" + sp.QUYCACH1 + "',";
            insert += "N'" + sp.KHUYENMAI1 + "',";
            insert += "N'" + sp.GIABAN1 + "')";

            dbconnect.query1(insert);

        }
        public void DeleteSP(string masp)
        {
            string delete = "delete from SANPHAM where MASP='" + masp + "'";
            dbconnect.query1(delete);
        }
        public void UpdateSP(SANPHAM sp, string masp)
        {
            string update = "update SANPHAM set ";

            update += "TENSP=N'" + sp.TENSP1 + "',";
            update += "MALOAISP=N'" + sp.MALOAISP1 + "',";
            update += "TRONGLUONG=N'" + sp.TRONGLUONG1 + "',";
            update += "QUYCACH=N'" + sp.QUYCACH1 + "',";
            update += "KHUYENMAI=N'" + sp.KHUYENMAI1 + "',";
            update += "GIABAN=N'" + sp.GIABAN1 + "'";
            update += "where MASP='" + masp + "'";
            dbconnect.query1(update);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEBKEODUA.Models;

namespace WEBKEODUA.Models
{
    public class GioHang
    {
        QL_KEODUA_WEBEntities4 db = new QL_KEODUA_WEBEntities4();
        public string iMaSP { set; get; }
        public string sTenSP { set; get; }
        public string sAnh { set; get; }
        public int dDonGia { set; get; }
        public int iSoLuong { set; get; }
        public double dThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }

        public GioHang(string MaSP)
        {
            iMaSP = MaSP;
            SANPHAM sp = db.SANPHAMs.Single(s => s.MASP == iMaSP);
            sTenSP = sp.TENSP;
            sAnh = sp.CTSANPHAM.ANH;
            dDonGia = int.Parse(sp.GIABAN.ToString());
            iSoLuong = 1;

        }
    }
}
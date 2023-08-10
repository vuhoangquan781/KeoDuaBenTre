using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBKEODUA.Models;
namespace WEBKEODUA.Controllers
{
    public class GioHangController : Controller
    {
        // GET: Cart
        QL_KEODUA_WEBEntities4 db = new QL_KEODUA_WEBEntities4();
        public ActionResult Index()
        {
            return View();
        }
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
        // add thêm vào giỏ hàng
        public ActionResult ThemGioHang(string ms, string strURL)
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang SanPham = lstGioHang.Find(sp => sp.iMaSP == ms);
            if (SanPham == null)
            {
                SanPham = new GioHang(ms);
                lstGioHang.Add(SanPham);
                return Redirect(strURL);
            }
            else
            {
                SanPham.iSoLuong++;
                return Redirect(strURL);
            }
        }
        private int TongSoLuong()
        {
            int tsl = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;

            if (lstGioHang != null)
            {
                tsl = lstGioHang.Sum(sp => sp.iSoLuong);
            }
            return tsl;
        }

        private double TongThanhTien()
        {
            double ttt = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;

            if (lstGioHang != null)
            {
                ttt += lstGioHang.Sum(sp => sp.dThanhTien);
            }
            return ttt;
        }
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "GioHang");
            }
            List<GioHang> lstGioHang = LayGioHang();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongThanhTien = TongThanhTien();
            return View(lstGioHang);
        }

        public ActionResult GioHangPartial()
        {
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongThanhTien = TongThanhTien();
            return PartialView();
        }

        public ActionResult XoaGioHang(string MaSP)
        {
            List<GioHang> lstGioHang = LayGioHang();

            GioHang sp = lstGioHang.Single(s => s.iMaSP == MaSP);

            if (sp != null)
            {
                lstGioHang.RemoveAll(s => s.iMaSP == MaSP);
                return RedirectToAction("GioHang", "GioHang");
            }
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "GioHang");
            }
            return RedirectToAction("GioHang", "GioHang");
        }

        public ActionResult XoaGioHang_All()
        {
            List<GioHang> lstGioHang = LayGioHang();
            lstGioHang.Clear();
            return RedirectToAction("Index", "GioHang");
        }

        public ActionResult CapNhatGioHang(string MaSP, FormCollection f)
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sp = lstGioHang.Single(s => s.iMaSP == MaSP);
            if (sp != null)
            {
                sp.iSoLuong = int.Parse(f["txtSoLuong"].ToString());

            }
            return RedirectToAction("GioHang", "GioHang");
        }
        public ActionResult DatHang()
        {
            if (Session["tk"] == null || Session["tk"].ToString() == "")
            {
                return RedirectToAction("Login", "Home");
            }
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("SanPhamParital", "SanPham");
            }

            List<GioHang> lstGioHang = LayGioHang();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongThanhTien = TongThanhTien();

            return View(lstGioHang);
        }

        [HttpPost]
        public ActionResult DatHang(FormCollection f)
        {
            
            DONHANG ddh = new DONHANG();
            KHACHHANG kh = (KHACHHANG)Session["tk"];
            List<GioHang> gh = LayGioHang();

            ddh.MAKHACH = kh.MAKHACH;
            ddh.NGAYBAN = DateTime.Now;

            ddh.THANHTOAN = 0;
            
            db.DONHANGs.Add(ddh);
            db.SubmitChanges();

            foreach (var item in gh)
            {
                CTDONHANG ctdh = new CTDONHANG();
                ctdh.MAHD = ddh.MAHD;
                ctdh.MASP = item.iMaSP;
                ctdh.SOLUONG = item.iSoLuong;
                ctdh.DONGIA = item.dDonGia;
                db.CTDONHANGs.Add(ctdh);
            }
            db.SubmitChanges();
            Session["GioHang"] = null;

            return RedirectToAction("XacNhanDonHang", "GioHang");
        }

        public ActionResult XacNhanDonHang()
        {
            return View();

        }
    }
}
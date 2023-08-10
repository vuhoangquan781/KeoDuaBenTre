using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBKEODUA.Models;
namespace WEBKEODUA.Controllers
{
    public class LoaiSPController : Controller
    {
        // GET: LoaiSP

        QL_KEODUA_WEBEntities4 db = new QL_KEODUA_WEBEntities4();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoaiSPPartial()
        {
            var ListChuDe = db.LOAISPs.Take(10).OrderBy(cd => cd.TENLOAISP).ToList();
            return PartialView(ListChuDe);
        }

        public ActionResult LoaiSanPham(string mahg)
        {
            var lstLT = db.SANPHAMs.OrderBy(s => s.TENSP).Where(s => s.MALOAISP == mahg).ToList();
            if (lstLT.Count == 0)
            {
                ViewBag.Sach = "Hãng này tạm hết hàng !";
            }
            return View(lstLT);
        }
    }
}
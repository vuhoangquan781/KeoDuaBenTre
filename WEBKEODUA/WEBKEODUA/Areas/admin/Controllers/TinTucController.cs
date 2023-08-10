using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBKEODUA.Models;

namespace WEBKEODUA.Areas.admin.Controllers
{
    public class TinTucController : Controller
    {
        // GET: admin/TinTuc
        private QL_KEODUA_WEBEntities4 db = new QL_KEODUA_WEBEntities4();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoaiTTPartial()
        {
            var ListChuDe = db.THELOAITINs.Take(10).OrderBy(cd => cd.TENLOAI).ToList();
            return PartialView(ListChuDe);
        }

        public ActionResult LoaiTT(string malt)
        {
            var lstLT = db.TINTUCs.OrderBy(s => s.TIEUDETIN).Where(s => s.MALOAI == malt).ToList();
            if (lstLT.Count == 0)
            {
                ViewBag.Sach = "Hãng này tạm hết hàng !";
            }
            return View(lstLT);
        }
    }
}
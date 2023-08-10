using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using WEBKEODUA.Models;

namespace WEBKEODUA.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        QL_KEODUA_WEBEntities4 objModel = new QL_KEODUA_WEBEntities4();
        public ActionResult Index()
        {
            var list = objModel.CTSANPHAMs.ToList();
            return View(list);
        }

        public ActionResult ProductDetail(string Id)
        {
            SANPHAM product = objModel.SANPHAMs.Single(s => s.MASP == Id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult SanPhamPartial()
        {

            var ListSP = objModel.SANPHAMs.OrderBy(s => s.TENSP).ToList();
            return View(ListSP);
        }

        public ActionResult ProductType(string masp)
        {
            var ListProduct = objModel.SANPHAMs.Where(s => s.MALOAISP == masp).OrderBy(s => s.GIABAN).ToList();
            if (ListProduct.Count == 0)
            {
                ViewBag.Product = "Không có sản phẩm nào";
            }
            return View(ListProduct);
        }

        
    }
}
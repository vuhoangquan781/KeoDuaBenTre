using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WEBKEODUA.Models;

namespace WEBKEODUA.Areas.admin.Controllers
{
    public class SPController : Controller
    {
        private QL_KEODUA_WEBEntities4 db = new QL_KEODUA_WEBEntities4();

        // GET: admin/SP
        public ActionResult Index()
        {
            var sANPHAMs = db.SANPHAMs.Include(s => s.CTSANPHAM).Include(s => s.LOAISP);
            return View(sANPHAMs.ToList());
        }

        // GET: admin/SP/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }

        // GET: admin/SP/Create
        public ActionResult Create()
        {
            ViewBag.MASP = new SelectList(db.CTSANPHAMs, "MASP", "ANH");
            ViewBag.MALOAISP = new SelectList(db.LOAISPs, "MALOAISP", "TENLOAISP");
            return View();
        }

        // POST: admin/SP/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MASP,TENSP,MALOAISP,TRONGLUONG,QUYCACH,KHUYENMAI,GIABAN")] SANPHAM sANPHAM)
        {
            if (ModelState.IsValid)
            {
                db.SANPHAMs.Add(sANPHAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MASP = new SelectList(db.CTSANPHAMs, "MASP", "ANH", sANPHAM.MASP);
            ViewBag.MALOAISP = new SelectList(db.LOAISPs, "MALOAISP", "TENLOAISP", sANPHAM.MALOAISP);
            return View(sANPHAM);
        }

        // GET: admin/SP/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            ViewBag.MASP = new SelectList(db.CTSANPHAMs, "MASP", "ANH", sANPHAM.MASP);
            ViewBag.MALOAISP = new SelectList(db.LOAISPs, "MALOAISP", "TENLOAISP", sANPHAM.MALOAISP);
            return View(sANPHAM);
        }

        // POST: admin/SP/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MASP,TENSP,MALOAISP,TRONGLUONG,QUYCACH,KHUYENMAI,GIABAN")] SANPHAM sANPHAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sANPHAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MASP = new SelectList(db.CTSANPHAMs, "MASP", "ANH", sANPHAM.MASP);
            ViewBag.MALOAISP = new SelectList(db.LOAISPs, "MALOAISP", "TENLOAISP", sANPHAM.MALOAISP);
            return View(sANPHAM);
        }

        // GET: admin/SP/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }

        // POST: admin/SP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            db.SANPHAMs.Remove(sANPHAM);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

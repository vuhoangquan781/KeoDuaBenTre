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
    public class LSPController : Controller
    {
        private QL_KEODUA_WEBEntities4 db = new QL_KEODUA_WEBEntities4();

        // GET: admin/LSP
        public ActionResult Index()
        {
            return View(db.LOAISPs.ToList());
        }

        // GET: admin/LSP/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAISP lOAISP = db.LOAISPs.Find(id);
            if (lOAISP == null)
            {
                return HttpNotFound();
            }
            return View(lOAISP);
        }

        // GET: admin/LSP/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/LSP/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MALOAISP,TENLOAISP")] LOAISP lOAISP)
        {
            if (ModelState.IsValid)
            {
                db.LOAISPs.Add(lOAISP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lOAISP);
        }

        // GET: admin/LSP/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAISP lOAISP = db.LOAISPs.Find(id);
            if (lOAISP == null)
            {
                return HttpNotFound();
            }
            return View(lOAISP);
        }

        // POST: admin/LSP/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MALOAISP,TENLOAISP")] LOAISP lOAISP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOAISP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lOAISP);
        }

        // GET: admin/LSP/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAISP lOAISP = db.LOAISPs.Find(id);
            if (lOAISP == null)
            {
                return HttpNotFound();
            }
            return View(lOAISP);
        }

        // POST: admin/LSP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LOAISP lOAISP = db.LOAISPs.Find(id);
            db.LOAISPs.Remove(lOAISP);
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

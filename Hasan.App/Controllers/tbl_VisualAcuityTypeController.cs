using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hasan.App.Models;

namespace Hasan.App.Controllers
{
    public class tbl_VisualAcuityTypeController : Controller
    {
        private HasanHoutoneEntities db = new HasanHoutoneEntities();

        // GET: tbl_VisualAcuityType
        public ActionResult Index()
        {
            return View(db.tbl_VisualAcuityType.ToList());
        }

        // GET: tbl_VisualAcuityType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_VisualAcuityType tbl_VisualAcuityType = db.tbl_VisualAcuityType.Find(id);
            if (tbl_VisualAcuityType == null)
            {
                return HttpNotFound();
            }
            return View(tbl_VisualAcuityType);
        }

        // GET: tbl_VisualAcuityType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_VisualAcuityType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] tbl_VisualAcuityType tbl_VisualAcuityType)
        {
            if (ModelState.IsValid)
            {
                db.tbl_VisualAcuityType.Add(tbl_VisualAcuityType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_VisualAcuityType);
        }

        // GET: tbl_VisualAcuityType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_VisualAcuityType tbl_VisualAcuityType = db.tbl_VisualAcuityType.Find(id);
            if (tbl_VisualAcuityType == null)
            {
                return HttpNotFound();
            }
            return View(tbl_VisualAcuityType);
        }

        // POST: tbl_VisualAcuityType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] tbl_VisualAcuityType tbl_VisualAcuityType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_VisualAcuityType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_VisualAcuityType);
        }

        // GET: tbl_VisualAcuityType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_VisualAcuityType tbl_VisualAcuityType = db.tbl_VisualAcuityType.Find(id);
            if (tbl_VisualAcuityType == null)
            {
                return HttpNotFound();
            }
            return View(tbl_VisualAcuityType);
        }

        // POST: tbl_VisualAcuityType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_VisualAcuityType tbl_VisualAcuityType = db.tbl_VisualAcuityType.Find(id);
            db.tbl_VisualAcuityType.Remove(tbl_VisualAcuityType);
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

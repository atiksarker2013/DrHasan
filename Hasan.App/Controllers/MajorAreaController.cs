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
    public class MajorAreaController : Controller
    {
        private HasanHoutoneEntities db = new HasanHoutoneEntities();

        // GET: MajorArea
        public ActionResult Index()
        {
            return View(db.tbl_MajorArea.ToList());
        }

        // GET: MajorArea/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MajorArea tbl_MajorArea = db.tbl_MajorArea.Find(id);
            if (tbl_MajorArea == null)
            {
                return HttpNotFound();
            }
            return View(tbl_MajorArea);
        }

        // GET: MajorArea/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MajorArea/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] tbl_MajorArea tbl_MajorArea)
        {
            if (ModelState.IsValid)
            {
                db.tbl_MajorArea.Add(tbl_MajorArea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_MajorArea);
        }

        // GET: MajorArea/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MajorArea tbl_MajorArea = db.tbl_MajorArea.Find(id);
            if (tbl_MajorArea == null)
            {
                return HttpNotFound();
            }
            return View(tbl_MajorArea);
        }

        // POST: MajorArea/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] tbl_MajorArea tbl_MajorArea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_MajorArea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_MajorArea);
        }

        // GET: MajorArea/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MajorArea tbl_MajorArea = db.tbl_MajorArea.Find(id);
            if (tbl_MajorArea == null)
            {
                return HttpNotFound();
            }
            return View(tbl_MajorArea);
        }

        // POST: MajorArea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_MajorArea tbl_MajorArea = db.tbl_MajorArea.Find(id);
            db.tbl_MajorArea.Remove(tbl_MajorArea);
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

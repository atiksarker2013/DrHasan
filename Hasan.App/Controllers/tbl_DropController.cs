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
    public class tbl_DropController : Controller
    {
        private HasanHoutoneEntities db = new HasanHoutoneEntities();

        // GET: tbl_Drop
        public ActionResult Index()
        {
            return View(db.tbl_Drop.ToList());
        }

        // GET: tbl_Drop/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Drop tbl_Drop = db.tbl_Drop.Find(id);
            if (tbl_Drop == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Drop);
        }

        // GET: tbl_Drop/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_Drop/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] tbl_Drop tbl_Drop)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Drop.Add(tbl_Drop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Drop);
        }

        // GET: tbl_Drop/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Drop tbl_Drop = db.tbl_Drop.Find(id);
            if (tbl_Drop == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Drop);
        }

        // POST: tbl_Drop/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] tbl_Drop tbl_Drop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Drop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Drop);
        }

        // GET: tbl_Drop/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Drop tbl_Drop = db.tbl_Drop.Find(id);
            if (tbl_Drop == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Drop);
        }

        // POST: tbl_Drop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Drop tbl_Drop = db.tbl_Drop.Find(id);
            db.tbl_Drop.Remove(tbl_Drop);
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

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
    public class tbl_InvestigationController : Controller
    {
        private HasanHoutoneEntities db = new HasanHoutoneEntities();

        // GET: tbl_Investigation
        public ActionResult Index()
        {
            return View(db.tbl_Investigation.ToList());
        }

        // GET: tbl_Investigation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Investigation tbl_Investigation = db.tbl_Investigation.Find(id);
            if (tbl_Investigation == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Investigation);
        }

        // GET: tbl_Investigation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_Investigation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] tbl_Investigation tbl_Investigation)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Investigation.Add(tbl_Investigation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Investigation);
        }

        // GET: tbl_Investigation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Investigation tbl_Investigation = db.tbl_Investigation.Find(id);
            if (tbl_Investigation == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Investigation);
        }

        // POST: tbl_Investigation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] tbl_Investigation tbl_Investigation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Investigation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Investigation);
        }

        // GET: tbl_Investigation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Investigation tbl_Investigation = db.tbl_Investigation.Find(id);
            if (tbl_Investigation == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Investigation);
        }

        // POST: tbl_Investigation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Investigation tbl_Investigation = db.tbl_Investigation.Find(id);
            db.tbl_Investigation.Remove(tbl_Investigation);
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

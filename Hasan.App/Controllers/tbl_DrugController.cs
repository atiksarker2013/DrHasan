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
    public class tbl_DrugController : Controller
    {
        private HasanHoutoneEntities db = new HasanHoutoneEntities();

        // GET: tbl_Drug
        public ActionResult Index()
        {
            return View(db.tbl_Drug.ToList());
        }

        // GET: tbl_Drug/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Drug tbl_Drug = db.tbl_Drug.Find(id);
            if (tbl_Drug == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Drug);
        }

        // GET: tbl_Drug/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_Drug/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] tbl_Drug tbl_Drug)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Drug.Add(tbl_Drug);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Drug);
        }

        // GET: tbl_Drug/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Drug tbl_Drug = db.tbl_Drug.Find(id);
            if (tbl_Drug == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Drug);
        }

        // POST: tbl_Drug/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] tbl_Drug tbl_Drug)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Drug).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Drug);
        }

        // GET: tbl_Drug/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Drug tbl_Drug = db.tbl_Drug.Find(id);
            if (tbl_Drug == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Drug);
        }

        // POST: tbl_Drug/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Drug tbl_Drug = db.tbl_Drug.Find(id);
            db.tbl_Drug.Remove(tbl_Drug);
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

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
    public class tbl_PatientController : Controller
    {
        private HasanHoutoneEntities db = new HasanHoutoneEntities();

        // GET: tbl_Patient
        public ActionResult Index()
        {
            return View(db.tbl_Patient.ToList());
        }

        // GET: tbl_Patient/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Patient tbl_Patient = db.tbl_Patient.Find(id);
            if (tbl_Patient == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Patient);
        }

        // GET: tbl_Patient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_Patient/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,ChiefComplains,Age,Sex,Mrno")] tbl_Patient tbl_Patient)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Patient.Add(tbl_Patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Patient);
        }

        // GET: tbl_Patient/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Patient tbl_Patient = db.tbl_Patient.Find(id);
            if (tbl_Patient == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Patient);
        }

        // POST: tbl_Patient/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,ChiefComplains,Age,Sex,Mrno")] tbl_Patient tbl_Patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Patient);
        }

        // GET: tbl_Patient/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Patient tbl_Patient = db.tbl_Patient.Find(id);
            if (tbl_Patient == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Patient);
        }

        // POST: tbl_Patient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Patient tbl_Patient = db.tbl_Patient.Find(id);
            db.tbl_Patient.Remove(tbl_Patient);
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

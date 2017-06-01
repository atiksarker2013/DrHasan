using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hasan.App.Models;
using Hasan.App.Gateway;

namespace Hasan.App.Controllers
{
    public class tbl_RxController : Controller
    {


        private HasanHoutoneEntities db = new HasanHoutoneEntities();
        PrescriptionManager manage = new PrescriptionManager();


        public ActionResult PrintPrescriptionFromIndex(int? id)
        {
            if (GlobalClass.SystemSession)
            {
                int rxid = 0;
                rxid = id ?? 0;
                //id = Convert.ToInt32(GlobalClass.RxId);
                ViewBag.mess = "Prescription";
                Prescription model = new Prescription();
                model = manage.FillMainPrescription(rxid);
                return View(model);

            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }
        }

        // GET: tbl_Rx
        public ActionResult Index()
        {
            var tbl_Rx = db.tbl_Rx.Include(t => t.tbl_MajorArea).Include(t => t.tbl_Patient);
            return View(tbl_Rx.ToList());
        }

        // GET: tbl_Rx/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Rx tbl_Rx = db.tbl_Rx.Find(id);
            if (tbl_Rx == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Rx);
        }

        // GET: tbl_Rx/Create
        public ActionResult Create()
        {
            ViewBag.MajorAreaId = new SelectList(db.tbl_MajorArea, "Id", "Name");
            ViewBag.PatientId = new SelectList(db.tbl_Patient, "Id", "Name");
            return View();
        }

        // POST: tbl_Rx/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MajorAreaId,Rx,PatientId,NextVisit,EntryDate")] tbl_Rx tbl_Rx)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Rx.Add(tbl_Rx);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MajorAreaId = new SelectList(db.tbl_MajorArea, "Id", "Name", tbl_Rx.MajorAreaId);
            ViewBag.PatientId = new SelectList(db.tbl_Patient, "Id", "Name", tbl_Rx.PatientId);
            return View(tbl_Rx);
        }

        // GET: tbl_Rx/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Rx tbl_Rx = db.tbl_Rx.Find(id);
            if (tbl_Rx == null)
            {
                return HttpNotFound();
            }
            ViewBag.MajorAreaId = new SelectList(db.tbl_MajorArea, "Id", "Name", tbl_Rx.MajorAreaId);
            ViewBag.PatientId = new SelectList(db.tbl_Patient, "Id", "Name", tbl_Rx.PatientId);
            return View(tbl_Rx);
        }

        // POST: tbl_Rx/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MajorAreaId,Rx,PatientId,NextVisit,EntryDate")] tbl_Rx tbl_Rx)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Rx).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MajorAreaId = new SelectList(db.tbl_MajorArea, "Id", "Name", tbl_Rx.MajorAreaId);
            ViewBag.PatientId = new SelectList(db.tbl_Patient, "Id", "Name", tbl_Rx.PatientId);
            return View(tbl_Rx);
        }

        // GET: tbl_Rx/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Rx tbl_Rx = db.tbl_Rx.Find(id);
            if (tbl_Rx == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Rx);
        }

        // POST: tbl_Rx/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Rx tbl_Rx = db.tbl_Rx.Find(id);
            db.tbl_Rx.Remove(tbl_Rx);
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

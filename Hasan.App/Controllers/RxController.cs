using Hasan.App.Gateway;
using Hasan.App.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hasan.App.Controllers
{
    public class RxController : Controller
    {
        HasanHoutoneEntities db = new HasanHoutoneEntities();
        PrescriptionManager manage = new PrescriptionManager();
        public ActionResult Create()
        {
            Prescription model = new Prescription();
            model.RxDrugList = new List<RxDrug>();
            model.RxDropList = new List<RxDrop>();
            model.RxInvestigationList = new List<RxInvestigation>();
            var MajorAreaList = (from x in db.tbl_MajorArea
                                 select x).OrderBy(m => m.Name);
            ViewBag.MajorAreaId = new SelectList(MajorAreaList.ToList(), "Id", "Name");


            var VisualAcuityLeftEyeTypeList = (from x in db.tbl_VisualAcuityType
                                 select x).OrderBy(m => m.Name);
            ViewBag.VisualAcuityLeftEyeType = new SelectList(VisualAcuityLeftEyeTypeList.ToList(), "Id", "Name");


            var VisualAcuityRightEyeTypeList = (from x in db.tbl_VisualAcuityType
                                               select x).OrderBy(m => m.Name);
            ViewBag.VisualAcuityRightEyeType = new SelectList(VisualAcuityRightEyeTypeList.ToList(), "Id", "Name");


            return View(model);
        }

        [HttpPost]
       
        public ActionResult Create(Prescription model)
        {
            if (GlobalClass.SystemSession)
            {
                ViewBag.mess = "Customer Configuration";
                if (ModelState.IsValid)
                {

                    DataReturn data = manage.SaveMainData(model);
                    ViewBag.mess = data.mess;
                    if (data.flag == 1)
                    {
                        GlobalClass.RxId = data.Pkey.ToString();

                        return RedirectToAction("PrintPrescriptionFromIndex", "tbl_Rx", new { id = data.Pkey});
                       // return RedirectToAction("PrintPrescriptionFromIndex");

                    }
                      
                }

                var MajorAreaList = (from x in db.tbl_MajorArea
                                     select x).OrderBy(m => m.Name);
                ViewBag.MajorAreaId = new SelectList(MajorAreaList.ToList(), "Id", "Name");


                var VisualAcuityLeftEyeTypeList = (from x in db.tbl_VisualAcuityType
                                                   select x).OrderBy(m => m.Name);
                ViewBag.VisualAcuityLeftEyeType = new SelectList(VisualAcuityLeftEyeTypeList.ToList(), "Id", "Name");


                var VisualAcuityRightEyeTypeList = (from x in db.tbl_VisualAcuityType
                                                    select x).OrderBy(m => m.Name);
                ViewBag.VisualAcuityRightEyeType = new SelectList(VisualAcuityRightEyeTypeList.ToList(), "Id", "Name");

                return View(model);
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }
        }


        public ActionResult PrintPrescription()
        {
            if (GlobalClass.SystemSession)
            {
                int id = 0;
                id = Convert.ToInt32(GlobalClass.RxId);
                ViewBag.mess = "Prescription";
                Prescription model = new Prescription();
                model = manage.FillMainPrescription(id);
                return View(model);

            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }
        }


        public ActionResult PrintPrescriptionFromIndex(int? id)
        {
            if (GlobalClass.SystemSession)
            {
                int rxid = 0;
                rxid = id??0;
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

        // GET: Rx
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AddDrug(Prescription model)
        {
            if (model.DrugId!=null)
            {
                if (GlobalClass.DragList!=null && GlobalClass.DragList.Count>0)
                {
                    model.RxDrugList = GlobalClass.DragList;
                }
               

                RxDrug obj = new RxDrug();
                obj.DrugId = model.DrugId ?? 0;
                obj.DrugName = model.DrugName;
                obj.Instruction = model.DrugNote;
                model.RxDrugList.Add(obj);

                GlobalClass.DragList = new List<RxDrug>();
                GlobalClass.DragList = model.RxDrugList;
            }
          

            return PartialView("_PartialPrescribeDrug", model);
        }

        public ActionResult RemoveDrug(Prescription model, FormCollection collection)
        {
            string RemoveDrugId = Convert.ToString(collection["RemoveDrugId"]);
            int rowIndex = int.Parse(collection.Get("RemoveDrugId"));
            model.RxDrugList.RemoveAt(rowIndex);

            var itemToRemove = GlobalClass.DragList.SingleOrDefault(r => r.DrugId == model.DrugId && r.DrugName == model.DrugName && r.Instruction == model.DrugNote);
            if (itemToRemove != null)
                GlobalClass.DragList.Remove(itemToRemove);
           
            ModelState.Clear();
            return PartialView("_PartialPrescribeDrug", model);
        }

        public ActionResult AddDrop(Prescription model)
        {
            if (model.DropId!=null)
            {
                if (GlobalClass.DropList != null && GlobalClass.DropList.Count > 0)
                {
                    model.RxDropList = GlobalClass.DropList;
                }

                RxDrop obj = new RxDrop();
                obj.DropId = model.DropId ?? 0;
                obj.DropName = model.DropName;
                obj.Instruction = model.DropNote;
                model.RxDropList.Add(obj);

                GlobalClass.DropList = new List<RxDrop>();
                GlobalClass.DropList = model.RxDropList;
            }
            

            return PartialView("_PartialPrescribeDrop", model);

        }

        public ActionResult RemoveDrop(Prescription model, FormCollection collection)
        {
            string RemoveDrugId = Convert.ToString(collection["RemoveDropId"]);
            int rowIndex = int.Parse(collection.Get("RemoveDropId"));
            model.RxDropList.RemoveAt(rowIndex);

            var itemToRemove = GlobalClass.DropList.SingleOrDefault(r => r.DropId == model.DropId && r.DropName == model.DropName && r.Instruction == model.DropNote);
            if (itemToRemove != null)
                GlobalClass.DropList.Remove(itemToRemove);

            ModelState.Clear();
            return PartialView("_PartialPrescribeDrop", model);
        }


        public ActionResult AddInvestigation(Prescription model)
        {
            if (model.InvestigationId!=null)
            {
                if (GlobalClass.InvestigationList != null && GlobalClass.InvestigationList.Count > 0)
                {
                    model.RxInvestigationList = GlobalClass.InvestigationList;
                }


                RxInvestigation obj = new RxInvestigation();
                obj.InvestigationId = model.InvestigationId ?? 0;
                obj.InvestigationName = model.InvestigationName;
                obj.Instruction = model.InvestigationNote;
                model.RxInvestigationList.Add(obj);

                GlobalClass.InvestigationList = new List<RxInvestigation>();
                GlobalClass.InvestigationList = model.RxInvestigationList;
            }
            

            return PartialView("_PartialPrescribeInvestigation", model);

        }

        public ActionResult RemoveInvestigation(Prescription model, FormCollection collection)
        {
            string RemoveDrugId = Convert.ToString(collection["RemoveInvestigationId"]);
            int rowIndex = int.Parse(collection.Get("RemoveInvestigationId"));
            model.RxInvestigationList.RemoveAt(rowIndex);

            var itemToRemove = GlobalClass.InvestigationList.SingleOrDefault(r => r.InvestigationId == model.InvestigationId && r.InvestigationName == model.InvestigationName && r.Instruction == model.InvestigationNote);
            if (itemToRemove != null)
                GlobalClass.InvestigationList.Remove(itemToRemove);

            ModelState.Clear();
            return PartialView("_PartialPrescribeInvestigation", model);
        }

    }
}
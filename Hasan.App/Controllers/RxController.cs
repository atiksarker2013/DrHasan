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

        public ActionResult Create()
        {
            Prescription model = new Prescription();
            model.RxDrugList = new List<RxDrug>();
            model.RxDropList = new List<RxDrop>();
            return View(model);
            
        }

        // GET: Rx
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AddDrug(Prescription model)
        {
            RxDrug obj = new RxDrug();
            obj.Id = model.DrugId??0;
            obj.DrugName = model.DrugName;
            obj.Instruction = model.DrugNote;
            model.RxDrugList.Add(obj);
            return PartialView("_PartialPrescribeDrug", model);
        }

        public ActionResult RemoveDrug(Prescription model, FormCollection collection)
        {
            int rowIndex = int.Parse(collection.Get("refRowIndex"));
            model.RxDrugList.RemoveAt(rowIndex - 1);
            ModelState.Clear();
            return PartialView("_PartialPrescribeDrug", model);
        }

        public ActionResult AddDrop(Prescription model)
        {
            RxDrop obj = new RxDrop();
            obj.Id = model.DrugId ?? 0;
            obj.DropName = model.DropName;
            obj.Instruction = model.DropNote;
            model.RxDropList.Add(obj);
            return PartialView("_PartialDropPrescribe", model);

        }

        public ActionResult RemoveDrop(Prescription model, FormCollection collection)
        {
            int rowIndex = int.Parse(collection.Get("refRowIndex"));
            model.RxDropList.RemoveAt(rowIndex - 1);
            ModelState.Clear();
            return PartialView("_PartialDropPrescribe", model);
        }

    }
}
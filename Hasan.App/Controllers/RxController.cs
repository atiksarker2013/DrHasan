using Hasan.App.Models;
using System;
using System.Collections.Generic;
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
    }
}
using Hasan.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hasan.App.Controllers
{
    public class DropdownUtilityController : Controller
    {

        private HasanHoutoneEntities db = new HasanHoutoneEntities();
        // GET: DropdownUtility
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPatientInfo(string query, int Mrno)
        {
            var users = (from u in db.tbl_Patient

                         where u.Mrno.ToUpper().Contains(query.ToUpper())  
                       
                         orderby u.Name
                         select new
                         {
                             label = u.Mrno,
                             value = u.Id,
                             Id = u.Id,
                             Name = u.Name,
                             Address = u.Address,
                             ChiefComplains = u.ChiefComplains,
                             Age = u.Age,
                             Sex = u.Sex,
                             Mrno = u.Mrno,
                             PatientId = u.Id,

                         }).ToList();
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDrug(string query)
        {
            var users = (from u in db.tbl_Drug

                         where u.Name.ToUpper().Contains(query.ToUpper())

                         orderby u.Name
                         select new
                         {
                             label = u.Name,
                             value = u.Id,
                             Name = u.Name 
                         }).ToList();
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDrop(string query)
        {
            var users = (from u in db.tbl_Drop

                         where u.Name.ToUpper().Contains(query.ToUpper())

                         orderby u.Name
                         select new
                         {
                             label = u.Name,
                             value = u.Id,
                             Name = u.Name
                         }).ToList();
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetInvestigation(string query)
        {
            var users = (from u in db.tbl_Investigation

                         where u.Name.ToUpper().Contains(query.ToUpper())

                         orderby u.Name
                         select new
                         {
                             label = u.Name,
                             value = u.Id,
                             Name = u.Name
                         }).ToList();
            return Json(users, JsonRequestBehavior.AllowGet);
        }
    }
}
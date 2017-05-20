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
            return View();
        }

        // GET: Rx
        public ActionResult Index()
        {
            return View();
        }
    }
}
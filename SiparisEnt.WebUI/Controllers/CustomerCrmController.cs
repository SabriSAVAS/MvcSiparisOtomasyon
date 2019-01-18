using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiparisEnt.WebUI.Controllers
{
    public class CustomerCrmController : Controller
    {
        // GET: CustomerCrm
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }
        public ActionResult List()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }

    }
}
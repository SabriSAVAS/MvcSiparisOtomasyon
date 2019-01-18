using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiparisEnt.WebUI.Controllers
{
    public class OtherController : Controller
    {
        // GET: Other
        public ActionResult Forbidden403()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
    }
}
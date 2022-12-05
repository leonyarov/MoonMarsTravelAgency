using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoonMarsTravelAgency.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            ViewBag.time = DateTime.Now;
            return View();
        }

        public ActionResult Redirect()
        {
            TempData["name"] = "Leon";
            return RedirectToAction("../Home/Index");
         
        }
    }
}
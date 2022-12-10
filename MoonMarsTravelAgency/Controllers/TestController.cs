using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoonMarsTravelAgency.Models;


namespace MoonMarsTravelAgency.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            //ViewBag.moons = new Moons().getMoons();
            ViewBag.moons = new MoonContext().Moon;
            ViewBag.time = DateTime.Now;
            return View();
        }

        public ActionResult Mars()
        {
            ViewBag.mars = new MarsContext().Mars;
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
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
            var moons = new MoonContext().Moon;
            var filterMoons = from m in moons 
                              orderby m.Crater descending
                              select m;
            ViewBag.moons = filterMoons;
            ViewBag.time = DateTime.Now;
            return View();
        }

        public ActionResult Mars()
        {
            ViewBag.mars = new MarsContext().Mars;
            ViewBag.time = DateTime.Now;
            return View();
        }

        public ActionResult Register()
        {
            
            return View();
         
        }
    }
}
using MoonMarsTravelAgency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoonMarsTravelAgency.Controllers
{
    public class HomeController : Controller
    {

        MoonMarsContext db = new MoonMarsContext();
        public ActionResult Index()
        {
            ViewBag.moon = db.Moon;
            ViewBag.mars = db.Mars;

            return View();
        }
   

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
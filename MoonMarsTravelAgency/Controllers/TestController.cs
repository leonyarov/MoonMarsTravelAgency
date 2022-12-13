using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;
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


        [ValidateAntiForgeryToken]
        public ActionResult CreateUser(Users u)
        {
            using (var db = new UserContext())
            {

                if (ModelState.IsValid)
                {
                    if (db.Users.Find(u.ID) != null)
                    {
                        ViewBag.error = "User Exist!";
                        return View("Error");
                    }
                    
                    db.Users.Add(u);
                    db.SaveChanges();
                    return View("Register");

                }

                //TODO: Error message;

            }
            return RedirectToAction("Index");

        }
    



    public ActionResult Register(Users u)
        {

            return View(new Users());
        }
    }
}

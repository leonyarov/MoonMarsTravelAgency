using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
            //var moons = new MoonMarsContext().Moon;
            //var filterMoons = from m in moons
            //    orderby m.Crater descending
            //    select m;
            //ViewBag.moons = filterMoons;
            //ViewBag.time = DateTime.Now;
            return View();
        }

        public ActionResult Mars()
        {
            ViewBag.mars = new MoonMarsContext().Mars;
            ViewBag.time = DateTime.Now;
            return View();
        }


        //public ActionResult CreateUser(Users u)
        //{
        //    using (var db = new UserContext())
        //    {

        //        if (ModelState.IsValid)
        //        {
        //            if (db.Users.Find(u.ID) != null)
        //            {
        //                ViewBag.error = "User Exist!";
        //                return View("Error");
        //            }
        //            else
        //            {
        //                db.Users.Add(u);
        //                db.SaveChanges();
        //                return View("Register");
        //            }
        //        }

        //        //TODO: Error message;

        //    }

        //    return RedirectToAction("Index", "Home");

        //}



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "ID,Name,Last_Name,Username,Password")] Users u)

        {
            using (var db = new MoonMarsContext())
            {

                if (ModelState.IsValid)
                {
                    if (db.Users.Find(u.ID) != null)
                    {
                        ViewBag.error = "User Exist!";
                        return RedirectToAction("ErrorResult","Test");
                    }
                    else
                    {
                        db.Users.Add(u);
                        db.SaveChanges();
                        return RedirectToAction("Index","Home");
                    }
                }

                //TODO: Error message;

            }

            return View(u);

        }

        public ActionResult ErrorResult()
        {

            //TODO: message the user about the error 
            return RedirectToAction("Register", "Test");
        }
    }
}

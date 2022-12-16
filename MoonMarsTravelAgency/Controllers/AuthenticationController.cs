using MoonMarsTravelAgency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MoonMarsTravelAgency.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication

        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Login([Bind(Include = "loginID,loginPassword")] FormCollection form)
        {
            var id = Convert.ToInt32(form["loginID"]);
            var pass = form["loginPassword"];

            var db = new MoonMarsContext();
            var user = db.Users.Find(id);
            if (user == null)
                return RedirectToAction("index");

            if (user.Password.Equals(pass))
            {
                if (db.Admins.Find(id) != null)
                    Session["Admin"] = true;

                Session["Username"] = user.Username;
                Session["ID"] = user.ID;

            }
            else
                return RedirectToAction("index");

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "registerID,registerPassword,registerfName, registerName, registerUsername")] FormCollection form)
        {
            var id = Convert.ToInt32(form["registerID"]);
            var pass = form["registerPassword"];

            var db = new MoonMarsContext();
            var user = db.Users.Find(id);
            if (user != null)
                return RedirectToAction("index");

            var newUser = new Users()
            {
                ID = id,
                Password = pass,
                Last_Name = form["registerfName"],
                Name = form["registerName"],
                Username = form["registerUsername"]
            };

            db.Users.Add(newUser);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}

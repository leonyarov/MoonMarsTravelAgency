using MoonMarsTravelAgency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PayPal.Api;
using Newtonsoft.Json;
using Payment = MoonMarsTravelAgency.Models.Payment;

namespace MoonMarsTravelAgency.Controllers
{
    public class PaymentController : Controller
    {

        private MoonMarsContext db = new MoonMarsContext();

        // GET: Payment
        public ActionResult CheckOut(FormCollection collection)
        {
            var s = Session["Schedule"] as Schedule;

            if (s == null)
                return RedirectToAction("Index", "Home");
            var seats = int.Parse(collection["seats"]);
            var twoWay = collection["two-way"];
            var totalPrice = seats * (twoWay == null ? 1 : 2) * s.Price;

            Session["total"] = totalPrice;

            //TODO: Redirect to payment with credit card
            return View("CheckOut");
        }
   
        public ActionResult Pay( FormCollection collection)
        {
            var payment = new Payment()
            {
                CreditCard = collection["CreditCard"],
                CCV = collection["CCV"],
                Name = collection["Name"],
                ID = collection["ID"]
            };
            var RemCard = collection["remember-card"] !=null;

            if (RemCard && ModelState.IsValid)
            {
                    db.Payment.Add(payment);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");//TODO : redirect to confirm page
                
            }
            else
                return RedirectToAction("Index", "Home");

            return View();



        }

        public ActionResult Success(FormCollection payment)
        {
            
            return RedirectToAction("Index","Home");
        }


        public ActionResult Buy() { return RedirectToAction("Buy","Ticket"); }
        //public ActionResult Checkout(FormCollection collection)
        //{
        //    return View();
        //}
    }
}
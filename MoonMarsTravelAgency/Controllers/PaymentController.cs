using MoonMarsTravelAgency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoonMarsTravelAgency.Controllers
{
    public class PaymentController : Controller
    {

        private MoonMarsContext db = new MoonMarsContext();

        // GET: Payment
        public ActionResult CheckOut(int? seats, bool? twoWay)
        {
            var s = Session["Schedule"] as Schedule;

            if (s == null)
                return RedirectToAction("Index", "Home");

            var totalPrice = (seats ?? 1) * (twoWay == null || twoWay == false ? 1 : 2) * s.Price;

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


            //Pay with credit card

        }


        public ActionResult Buy() { return RedirectToAction("Buy","Ticket"); }
        //public ActionResult Checkout(FormCollection collection)
        //{
        //    return View();
        //}
    }
}
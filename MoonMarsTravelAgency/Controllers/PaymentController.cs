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
        // GET: Payment
        public ActionResult CheckOut(int? seats, bool? twoWay)
        {
            var s = Session["Schedule"] as Schedule;

            if (s == null)
                return RedirectToAction("Home", "Index");

            var totalPrice = (seats ?? 1) * (twoWay == null || twoWay == false ? 1 : 2) * s.Price;

            Session["total"] = totalPrice;

            //TODO: Redirect to payment with credit card
            return View("CheckOut");
        }

        public ActionResult Pay()
        {
            //Pay with credit card
            return View();
        }
    }
}
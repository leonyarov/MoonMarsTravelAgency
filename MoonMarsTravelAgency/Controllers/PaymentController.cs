using MoonMarsTravelAgency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using PayPal.Api;
using Newtonsoft.Json;
using System.Net;
using Payment = MoonMarsTravelAgency.Models.Payment;
using System.IO;
using System.Text;
using System.Web.Configuration;
using System.Net.Http.Headers;
using System.Net.Http;

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
            var id = payment["id"];
            var email = payment["email"];
            var status = payment["status"];
            if (id == null)
                return View();

            //Get access token:
            var accessRequest = WebRequest.Create("https://api-m.sandbox.paypal.com/v1/oauth2/token");
            accessRequest.Method = WebRequestMethods.Http.Post;
            accessRequest.Headers["Accept"] = "application/json";
            accessRequest.Headers["Accept-Language"] = "en_US";
            var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes($"Ac0YJITFFVYhM6MKktXPoxratBCRGBmIliUUdFIgYUVQSuJFugdbMmKpjovai1QMqldGIn0c9Z_DjSUH:EK1cOtIZsxze3aEXzy5FUGDk3ps3UnruqMJtRZUf3QfxelOWc969Y-xlF0p12BazFua9OtqU51qjE3HN"));
            accessRequest.Headers["Authorization"] = $"Basic {base64authorization}";
            accessRequest.ContentType = "application/x-www-form-urlencoded";
            
            //confirm purchase and add to user ticket
            var order = WebRequest.Create($"https://api.sandbox.paypal.com/v2/checkout/orders/{id}");
            order.Method = WebRequestMethods.Http.Get;
            order.Headers["Content-Type"] = "application/json";
            order.Headers["Authorization"] = "Bearer ";

            using (var response = (HttpWebResponse)order.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var data = reader.ReadToEnd();

            }

            return RedirectToAction("Index","Home");
        }


        public ActionResult Buy() { return RedirectToAction("Buy","Ticket"); }
        //public ActionResult Checkout(FormCollection collection)
        //{
        //    return View();
        //}
    }
}
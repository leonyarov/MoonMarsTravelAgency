using MoonMarsTravelAgency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Text;
using System.Web.Configuration;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Web.Helpers;
using Transaction = MoonMarsTravelAgency.Models.Transaction;
using Microsoft.Ajax.Utilities;

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
   

        public ActionResult Success(FormCollection payment)
        {
            //Get data from post
            var id = payment["id"];
            var email = payment["email"];
            var status = payment["status"];
            var steats = int.Parse(payment["seats"]);

            if (id == null)
                return View();

            //Get access token
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api-m.sandbox.paypal.com/v1/oauth2/token");

            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Accept-Language", "en_US");
            request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes("Ac0YJITFFVYhM6MKktXPoxratBCRGBmIliUUdFIgYUVQSuJFugdbMmKpjovai1QMqldGIn0c9Z_DjSUH:EK1cOtIZsxze3aEXzy5FUGDk3ps3UnruqMJtRZUf3QfxelOWc969Y-xlF0p12BazFua9OtqU51qjE3HN")));
            request.Content = new StringContent("grant_type=client_credentials");
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

            HttpResponseMessage response = client.SendAsync(request).Result;
            response.EnsureSuccessStatusCode();
            string responseBody = response.Content.ReadAsStringAsync().Result;
            string bearer = JObject.Parse(responseBody)["access_token"].ToString();
            
            
            //Recieve transaction from PAYPAL
            var order = WebRequest.Create($"https://api.sandbox.paypal.com/v2/checkout/orders/{id}");
            order.Method = WebRequestMethods.Http.Get;
            order.ContentType = "application/json";
            order.Headers["Authorization"] = $"Bearer {bearer}";

            try
            {
                using (var r = (HttpWebResponse)order.GetResponse())
                using (var s = r.GetResponseStream())
                using (var reader = new StreamReader(s))
                {
                    var data = reader.ReadToEnd();
                    if (data == null)
                        return View();
                    var parsed = JObject.Parse(data);
                    var name = parsed["payment_source"]["paypal"]["name"]["given_name"].ToString().ToLower();
                    var surname = parsed["payment_source"]["paypal"]["name"]["surname"].ToString().ToLower();
                    //[JSON].payment_source.paypal.name.given_name
                    //[JSON].payment_source.paypal.name.surname
                    var db = new MoonMarsContext();

                    //add transaction to DB
                    db.Transaction.Add(new Transaction()
                    {
                        Id = id,
                        name =name ,
                        surname = surname,
                        Status = status
                    });

                    //find the user by name
                    var user = db.Users.First(x => x.Name ==  name &&
                    x.Last_Name == surname) ?? null;
                    //user not found
                    if (user == null) return View();

                    var schedule = Session["Schedule"] as Schedule;
                    var max = db.Tickets.Where(x => x.Flight_ID == schedule.ID && x.User_ID == user.ID)?.ToList()?.Max(x => x.Seat_ID);
                    if (max == null)
                        max = 0;
                    for (int i = 1; i <= steats; i++)
                        db.Tickets.Add( new Tickets()
                        {
                         Flight_ID = schedule.ID,
                         User_ID = user.ID,
                         Seat_ID = max + i,
                        });

                    db.SaveChanges();

                }
            }
            catch (Exception e) { };
            return RedirectToAction("Index","Home");
        }


        public ActionResult Buy() { return RedirectToAction("Buy","Ticket"); }
        //public ActionResult Checkout(FormCollection collection)
        //{
        //    return View();
        //}
    }
}
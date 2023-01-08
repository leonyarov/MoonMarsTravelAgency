using MoonMarsTravelAgency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoonMarsTravelAgency.Controllers
{

    public class TicketController : Controller
    {
        private MoonMarsContext db = new MoonMarsContext();
        // GET: Ticket
        public ActionResult Buy()
        {
            var s = Session["Schedule"] as Schedule;
            var max = db.Tickets.Where(x => x.Flight_ID == s.ID).Max(x => x.Seat_ID) ?? 0;
            ViewBag.max = s.Seats - max;

            return View();

        }

        // GET: Ticket/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ticket/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ticket/Create
        [HttpPost]
        //public ActionResult Create([Bind(Include = "CreditCard,CCV,Name,ID,Amount")] Payment payment)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Payment.Add(payment);
        //        db.SaveChanges();
        //        return RedirectToAction("CheckOut");
        //    }
        //    return View();
        //}

        // GET: Ticket/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ticket/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ticket/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ticket/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Payment(FormCollection collection)
        {
           
            return View();
        }



    }
}

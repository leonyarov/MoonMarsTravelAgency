using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoonMarsTravelAgency.Models;

namespace MoonMarsTravelAgency.Controllers
{
    public class SchedulesController : Controller
    {
        private MoonMarsContext db = new MoonMarsContext();

        // GET: Schedules
        public ActionResult Index()
        {
            return View(db.Schedule.ToList());
        }


        [HttpPost]
        public ActionResult Search(FormCollection form)
        {
            var search = db.Schedule.ToList();
            var goDate = DateTime.Parse(form["Departure"]);
            var returnDate = DateTime.Parse(form["Return"]);
            var from1 = form["moon"];
            var to = form["mars"];
           // var pass = int.Parse(form["Passengers"] ?? "0");

       
            var MyResult = search.Where(x =>  x.From == from1 &&
                                              x.To == to &&
                                              x.ArrivalDate < returnDate &&
                                              x.ScheduleDate > goDate).ToList();
           

            return View("Index", MyResult);
        }

        // GET: Schedules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedule.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // GET: Schedules/Create
        public ActionResult Create()
        {
            ViewBag.mars = db.Mars;
            ViewBag.moon = db.Moon;
            return View();
        }

        // POST: Schedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Price,ScheduleID,ScheduleDate,ArrivalDate,Seats,From,To")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                db.Schedule.Add(schedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(schedule);
        }

        // GET: Schedules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedule.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // POST: Schedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Price,ScheduleID,ScheduleDate,ArrivalDate,Seats,From,To")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schedule).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(schedule);
        }

        // GET: Schedules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedule.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Schedule schedule = db.Schedule.Find(id);
            db.Schedule.Remove(schedule);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Book(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var schedule = db.Schedule.Find(id);
            Session["Schedule"] = schedule;
            if (schedule == null)
            {
                return HttpNotFound();
            }

            return RedirectToAction("Buy", "Ticket", schedule);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

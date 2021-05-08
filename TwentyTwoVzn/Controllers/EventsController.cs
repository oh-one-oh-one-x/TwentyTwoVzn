using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TwentyTwoVzn.Models;
using Microsoft.AspNet.Identity;
using System.Text;
using System.IO;

namespace TwentyTwoVzn.Controllers
{
    public class EventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Events
        public ActionResult Index()
        {
            return View(db.Events.ToList());
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            var userid = User.Identity.GetUserId();    
            ViewBag.BusID = new SelectList(db.Businesses.Where(x => x.UserId == userid).ToList(), "BusID", "BusName");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventID,EventName,EventDate,Host,EventFee,EventCapacity,EventStatus,Location,BusID")] Event @event)
        {
            if (ModelState.IsValid)
            {
                @event.EventStatus = "Upcoming";
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BusinessID = new SelectList(db.Businesses, "BusID", "BusName");
            return View(@event);
        }

        public ActionResult Past()
        {
            return View(db.Events.Where(x => x.EventDate <= DateTime.Now && x.EventStatus == "Full Capacity").ToList());
        }

        public ActionResult Upcoming()
        {
            return View(db.Events.Where(x => x.EventDate >= DateTime.Now && x.EventStatus == "Upcoming").ToList());
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventID,EventName,EventDate,Host,EventFee,EventCapacity,EventStatus,Location,BusinessID")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]

        public ActionResult Reserve(int EventID)
        {
            var reserve = new Reserve { EventID = EventID, ReserveDate = DateTime.Now};
            var cap = db.Events.Where(x => x.EventID == EventID).FirstOrDefault();
            if (cap.EventCapacity > 0 && cap.EventDate >= DateTime.Now)
            {
               
                cap.EventCapacity -= reserve.NumAttendees;
                if(cap.EventCapacity == 0)
                {
                    cap.EventStatus = "Full Capacity";
                }
            }
            db.Events.Add(cap);
            db.Reserves.Add(reserve);
            db.SaveChanges();
            var userE = User.Identity.Name.ToString();
            Email email = new Email();
            email.To = userE;
            email.Subject = "Event Reservation Successful";
            email.Body = ConvertPartialViewToString(PartialView("_Email", reserve));
            email.Sendmail();
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", reserve.EventID);
            return RedirectToAction("Index", "Home");
        }
        protected string ConvertPartialViewToString(PartialViewResult partialView)
        {
            using (var sw = new StringWriter())
            {
                partialView.View = ViewEngines.Engines
                  .FindPartialView(ControllerContext, partialView.ViewName).View;

                var vc = new ViewContext(
                  ControllerContext, partialView.View, partialView.ViewData, partialView.TempData, sw);
                partialView.View.Render(vc, sw);

                var partialViewString = sw.GetStringBuilder().ToString();

                return partialViewString;
            }
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

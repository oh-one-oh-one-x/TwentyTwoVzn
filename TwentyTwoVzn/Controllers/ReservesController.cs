﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TwentyTwoVzn.Models;

namespace TwentyTwoVzn.Controllers
{
    public class ReservesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reserves
        public ActionResult Index()
        {
            var reserves = db.Reserves.Include(r => r.Event);
            return View(reserves.ToList());
        }

        // GET: Reserves/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserve reserve = db.Reserves.Find(id);
            if (reserve == null)
            {
                return HttpNotFound();
            }
            return View(reserve);
        }

        // GET: Reserves/Create
        public ActionResult Create()
        {
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName");
            return View();
        }

        // POST: Reserves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReserveID,NumAttendees,ReserveDate,EventID,UserId")] Reserve reserve)
        {
            if (ModelState.IsValid)
            {
                db.Reserves.Add(reserve);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", reserve.EventID);
            return View(reserve);
        }

        // GET: Reserves/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserve reserve = db.Reserves.Find(id);
            if (reserve == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", reserve.EventID);
            return View(reserve);
        }

        // POST: Reserves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReserveID,NumAttendees,ReserveDate,EventID,UserId")] Reserve reserve)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reserve).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", reserve.EventID);
            return View(reserve);
        }

        // GET: Reserves/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserve reserve = db.Reserves.Find(id);
            if (reserve == null)
            {
                return HttpNotFound();
            }
            return View(reserve);
        }

        // POST: Reserves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reserve reserve = db.Reserves.Find(id);
            db.Reserves.Remove(reserve);
            db.SaveChanges();
            return RedirectToAction("Index");
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

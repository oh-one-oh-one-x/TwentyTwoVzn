using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using TwentyTwoVzn.Models;
using Microsoft.AspNet.Identity;
using System.IO;

namespace TwentyTwoVzn.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
       
        public ActionResult Index()
        {
            if (User.IsInRole("Business"))
            {
                return RedirectToAction("Index","Businesses");
            }
            return View();
        }

        //[Authorize]
        public ActionResult Service(int id)
        {
            string userid = User.Identity.GetUserId();
            var user = db.Users.Find(userid);
            ViewBag.address = user.Address;
            ViewBag.TypeName = db.ServiceTypes.Find(id).TypeName;
            ViewBag.id = id;
            return View(db.Services.Where(x => x.TypeID == id).ToList());
        }
        [HttpGet]
        public ActionResult  serviceApi(int id)
        {
            return Json(new { services = db.Services.Where(x => x.TypeID == id).ToList() }, JsonRequestBehavior.AllowGet);
                }

        public ActionResult Items(int id)
        {
            ViewBag.ServiceName = db.Services.Find(id).ServiceName;
            return View(db.Items.Where(x => x.ServiceID == id).ToList());
        }

        public ActionResult Reserve(int EventId)
        {
            ViewBag.max = 0;
           var currentnumberOfReservations = db.Reserves.Where(x => x.EventID == EventId).Select(x => x.NumAttendees).ToList().Sum();
            var cap = db.Events.Find(EventId);
            int maximum = (cap.EventCapacity - currentnumberOfReservations);
            if ( maximum<= 4)
            {
                ViewBag.max = maximum;
            }
            return View(new Reserve { EventID = EventId, Event = db.Events.Find(EventId) });

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reserve([Bind(Include = "ReserveID,NumAttendees,ReserveDate,EventID,UserId")] Reserve reserve)
        {
            if (ModelState.IsValid)
            {
                var currentnumberOfReservations = db.Reserves.Where(x => x.EventID == reserve.EventID).Select(x => x.NumAttendees).ToList().Sum();
                var cap = db.Events.Find(reserve.EventID);
                if (cap.EventCapacity > currentnumberOfReservations && cap.EventDate >= DateTime.Now)
                {

                    reserve.ReserveDate = DateTime.Now;
                    reserve.UserId = User.Identity.GetUserId();
                    db.Entry(cap).State = EntityState.Modified;
                    db.Reserves.Add(reserve);
                    db.SaveChanges();
                    var userE = User.Identity.Name.ToString();
                    Email email = new Email();
                    email.To = userE;
                    email.Subject = "Event Reservation Successful";
                    email.Body = ConvertPartialViewToString(PartialView("_Email", reserve));
                    email.Sendmail();
                    //try { email.Sendmail(); }
                    //catch
                    //{
                       
                    //}
                    return View("Success");
                    cap.EventCapacity -= reserve.NumAttendees;
                    if (cap.EventCapacity == 0)
                    {
                        cap.EventStatus = "Full Capacity";
                    }
                }
               
            }
          
            return View(reserve);
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
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Events()
        {
            return View(db.Events.Where(x => x.EventDate >= DateTime.Now && x.EventStatus == "Upcoming").ToList());
            
        }
    }
}
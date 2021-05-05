using System;
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
    public class ServicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Services
        public ActionResult Index()
        {
            var services = db.Services.Include(x => x.Business);
            return View(services.ToList());
        }

        // GET: Services/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            //ViewBag.Service = id.Value;
            //var comments = db.Reviews.Where(x => x.ServiceID.Equals(id.Value)).ToList();
            //ViewBag.Comments = comments;

            //var ratings = db.Reviews.Where(x => x.Service.Equals(id.Value)).ToList();

            //if(ratings.Count() > 0 )
            //{
            //    var ratingSum = ratings.Sum(x => x.Rating);
            //    ViewBag.RatingSum = ratingSum;
            //    var ratingCount = ratings.Count();
            //    ViewBag.RatingCount = ratingCount;
            //}
            //else
            //{
            //    ViewBag.RatingSum = 0;
            //    ViewBag.RatingCount = 0;
            //}

            return View(service);
        }

        // GET: Services/Create
        public ActionResult Create(int? businessId)
        {
            if (businessId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            ViewBag.TypeID = new SelectList(db.ServiceTypes, "TypeID", "TypeName");
            ViewBag.BusinessID = (int)businessId;
            return View();
        }

        // POST: Services/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServiceID,ServiceName,ServiceDetails,ServiceImage,ServiceLocation,TypeID,ReviewID,BusinessID")] Service service, HttpPostedFileBase Upload)
        {
            if (ModelState.IsValid)
            {
                if(Upload != null && Upload.ContentLength > 0)
                {
                    int fileLength = Upload.ContentLength;
                    byte[] imageBytes = new byte[fileLength];
                    Upload.InputStream.Read(imageBytes, 0, fileLength);
                    service.ServiceImage = imageBytes;
                    db.Services.Add(service);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }
            ViewBag.TypeID = new SelectList(db.ServiceTypes, "TypeID", "TypeName");
            ViewBag.BusinessID = new SelectList(db.Businesses, "BusinessID", "BusName", service.ServiceID);
            return View(service);
        }

        // GET: Services/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            ViewBag.TypeID = new SelectList(db.ServiceTypes, "TypeID", "TypeName");
            ViewBag.BusinessID = new SelectList(db.Businesses, "BusinessID", "BusName");
            return View(service);
        }

        // POST: Services/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServiceID,ServiceName,ServiceDetails,ServiceImage,ServiceLocation,TypeID,ReviewID,BusinessID")] Service service)
        {
            if (ModelState.IsValid)
            {
                db.Entry(service).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ServiceTypeID = new SelectList(db.ServiceTypes, "TypeID", "TypeName");
            ViewBag.BusinessID = new SelectList(db.Businesses, "BusinessID", "BusName");
            return View(service);
        }

        // GET: Services/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Service service = db.Services.Find(id);
            db.Services.Remove(service);
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

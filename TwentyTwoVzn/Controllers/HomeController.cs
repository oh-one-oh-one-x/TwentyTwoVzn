using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using TwentyTwoVzn.Models;
using Microsoft.AspNet.Identity;

namespace TwentyTwoVzn.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        //[Authorize]
        public ActionResult Index()
        {
            //if(User.IsInRole("Manager"))
            //{
            //    return RedirectToAction("Manager");
            //}
            return View();
        }

        public ActionResult Service(int id)
        {

            ViewBag.TypeName = db.ServiceTypes.Find(id).TypeName;
            return View(db.Services.Where(x => x.TypeID == id).ToList());
        }

        public ActionResult Items(int id)
        {
            ViewBag.ServiceName = db.Services.Find(id).ServiceName;
            return View(db.Items.Where(x => x.ServiceID == id).ToList());
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HouseholdBudget.Models;
using Microsoft.AspNet.Identity;

namespace HouseholdBudget.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        public ActionResult Index()
        {

            return View();

        }

        public ActionResult Transaction()
        {
            return PartialView("_IndexPartial");
        }


        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Budget Application";

            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Page.";

            return View();
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
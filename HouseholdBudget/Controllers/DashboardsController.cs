using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HouseholdBudget.Models;

namespace HouseholdBudget.Controllers
{
    public class DashboardsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Dashboards
        [Authorize]
        public ActionResult Index()
        {

            var model = new DashboardViewModel();
            model.accounts = db.Account.ToList();  // limit access to only the logged in user
            model.budgetItems = db.BudgetItems.ToList();
            model.transactions = db.Transaction.ToList();

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

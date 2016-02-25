using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HouseholdBudget.Models;

namespace HouseholdBudget.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        public ActionResult Index()
        {
            var household = (from Household in db.Household select Household);
            var householdDashboard = household.ToList();

            var account = (from Account in db.Account orderby Account.AccountName descending select Account);
            var accountDashboard = account.ToList();

            var transaction = (from Transaction in db.Transaction orderby Transaction.TransactionDate ascending select Transaction);
            var transactionDashboard = transaction.ToList();

            var budgetItems = (from BudgetItems in db.BudgetItems orderby BudgetItems.CategoryName ascending select BudgetItems);
            var budgetDashboard = household.ToList();

            return View();
        }

        
        

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Household Budgeting Application";
            
           

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
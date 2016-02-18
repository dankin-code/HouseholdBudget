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
    public class BudgetItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BudgetItems
        [Authorize]
        public ActionResult Index()
        {
            return View(db.BudgetItems.ToList());
        }

        // GET: BudgetItems/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BudgetItems budgetItems = db.BudgetItems.Find(id);
            if (budgetItems == null)
            {
                return HttpNotFound();
            }
            return View(budgetItems);
        }

        // GET: BudgetItems/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.BudgetId = new SelectList(db.Budget, "Id", "BudgetName");
            ViewBag.CategoryName = new SelectList(db.Category, "Id", "CategoryName");
            return View();
        }

        // POST: BudgetItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,Amount,CategoryName,BudgetId")] BudgetItems budgetItems)
        {
            if (ModelState.IsValid)
            {
                budgetItems.BudgetId = db.Budget.FirstOrDefault(u => u.Id == budgetItems.BudgetId).Id;                
                db.BudgetItems.Add(budgetItems);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(budgetItems);
        }

        // GET: BudgetItems/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BudgetItems budgetItems = db.BudgetItems.Find(id);
            if (budgetItems == null)
            {
                return HttpNotFound();
            }
            ViewBag.BudgetId = new SelectList(db.Budget, "Id", "BudgetName");
            ViewBag.CategoryName = new SelectList(db.Category, "Id", "CategoryName");

            return View(budgetItems);
        }

        // POST: BudgetItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,Amount,CategoryName,BudgetId")] BudgetItems budgetItems)
        {
            if (ModelState.IsValid)
            {
                db.Entry(budgetItems).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BudgetId = new SelectList(db.Budget, "Id", "BudgetName");
            ViewBag.CategoryName = new SelectList(db.Category, "Id", "CategoryName");

            return View(budgetItems);
        }

        // GET: BudgetItems/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BudgetItems budgetItems = db.BudgetItems.Find(id);
            if (budgetItems == null)
            {
                return HttpNotFound();
            }
            return View(budgetItems);
        }

        // POST: BudgetItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            BudgetItems budgetItems = db.BudgetItems.Find(id);
            db.BudgetItems.Remove(budgetItems);
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

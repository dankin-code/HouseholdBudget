using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult> Index()
        {
            return View(await db.BudgetItems.ToListAsync());
        }

        // GET: BudgetItems/Details/5
        [Authorize]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BudgetItems budgetItems = await db.BudgetItems.FindAsync(id);
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
            return View();
        }

        // POST: BudgetItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> Create([Bind(Include = "Id,Amount,CategoryName,BudgetId")] BudgetItems budgetItems)
        {
            if (ModelState.IsValid)
            {
                

                db.BudgetItems.Add(budgetItems);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(budgetItems);
        }

        // GET: BudgetItems/Edit/5
        [Authorize]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BudgetItems budgetItems = await db.BudgetItems.FindAsync(id);
            if (budgetItems == null)
            {
                return HttpNotFound();
            }
            return View(budgetItems);
        }

        // POST: BudgetItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Amount,CategoryName,BudgetId")] BudgetItems budgetItems)
        {
            if (ModelState.IsValid)
            {
                db.Entry(budgetItems).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(budgetItems);
        }

        // GET: BudgetItems/Delete/5
        [Authorize]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BudgetItems budgetItems = await db.BudgetItems.FindAsync(id);
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
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BudgetItems budgetItems = await db.BudgetItems.FindAsync(id);
            db.BudgetItems.Remove(budgetItems);
            await db.SaveChangesAsync();
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

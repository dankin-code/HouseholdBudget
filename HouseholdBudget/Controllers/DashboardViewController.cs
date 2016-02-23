using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HouseholdBudget.Models;

namespace HouseholdBudget.Controllers
{
    public class DashboardViewController : Controller
    {
        // GET: DashboardView
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        // GET: DashboardView/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DashboardView/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: DashboardView/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: DashboardView/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DashboardView/Edit/5
        [HttpPost]
        [Authorize]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}

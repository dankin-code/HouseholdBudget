using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Mail;
using HouseholdBudget.Models;
using System.Text;
using System.Net.Mime;


namespace HouseholdBudget.Controllers
{
    public class InvitationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Invitations
        [Authorize]
        public ActionResult Index()
        {
            var invitation = db.Invitation.Include(i => i.Household);
            return View(invitation.ToList());
        }

        // GET: Invitations/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invitation invitation = db.Invitation.Find(id);
            if (invitation == null)
            {
                return HttpNotFound();
            }
            return View(invitation);
        }

        // GET: Invitations/Create
        [Authorize]
        public ActionResult Create()
        {
            //ViewBag.HouseholdId = new SelectList(db.Household, "Id", "HouseholdName");
            //ViewBag.JoinCode = Guid.NewGuid();
            return View();
        }

        // POST: Invitations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,ToEmail,JoinCode,HouseholdId")] Invitation invitation)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var joinCode = Guid.NewGuid();
                    invitation.JoinCode = joinCode;
                    invitation.HouseholdId = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name).HouseholdId;
                    MailMessage myMessage = new MailMessage();
                    myMessage.To.Add(new MailAddress(invitation.ToEmail, "To"));
                    myMessage.From = new MailAddress(User.Identity.Name, "From");
                    myMessage.Subject = "Please join my budget app";

                    var callbackUrl = Url.Action("Join", "Households", new { JoinCode = invitation.JoinCode }, protocol: Request.Url.Scheme);

                    StringBuilder str = new StringBuilder();
                    str.Append(@"<p>");
                    str.Append(User.Identity.Name);
                    str.Append(" I would like to invite you to join my household. Please click the link and </p><p><a href='");
                    str.Append(callbackUrl);
                    str.Append("'>Join</a></p>");

                    myMessage.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(str.ToString(), null, MediaTypeNames.Text.Html));

                    // Init SmtpClient and send
                    SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
                    System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("dkinai", "qwerty1$");
                    smtpClient.Credentials = credentials;

                    smtpClient.Send(myMessage);

                    db.Invitation.Add(invitation);
                    db.SaveChanges();
                    return RedirectToAction("Index","Household");


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }

            ViewBag.HouseholdId = new SelectList(db.Household, "Id", "HouseholdName", invitation.HouseholdId);
            return View(invitation);
        }

        // GET: Invitations/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invitation invitation = db.Invitation.Find(id);
            if (invitation == null)
            {
                return HttpNotFound();
            }
            ViewBag.HouseholdId = new SelectList(db.Household, "Id", "HouseholdName", invitation.HouseholdId);
            return View(invitation);
        }

        // POST: Invitations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,ToEmail,JoinCode,HouseholdId")] Invitation invitation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invitation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HouseholdId = new SelectList(db.Household, "Id", "HouseholdName", invitation.HouseholdId);
            return View(invitation);
        }

        // GET: Invitations/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invitation invitation = db.Invitation.Find(id);
            if (invitation == null)
            {
                return HttpNotFound();
            }
            return View(invitation);
        }

        // POST: Invitations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Invitation invitation = db.Invitation.Find(id);
            db.Invitation.Remove(invitation);
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

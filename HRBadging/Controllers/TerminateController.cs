using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRBadging.Data;
using HRBadging.Models.Badging;

namespace HRBadging.Controllers
{
    public class TerminateController : Controller
    {
        private BadgingContext db = new BadgingContext();

        // GET: Terminate
        public ActionResult Index()
        {
            var terminates = db.Terminates.Include(t => t.Badge);
            return View(terminates.ToList());
        }

        // GET: Terminate/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terminate terminate = db.Terminates.Find(id);
            if (terminate == null)
            {
                return HttpNotFound();
            }
            return View(terminate);
        }

        // GET: Terminate/Create
        public ActionResult Create()
        {
            ViewBag.BadgeId = new SelectList(db.Badges, "BadgeId");
            return View();
        }

        // POST: Terminate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UpId,DateJobTermination,BadgeTerminationDate,BadgeReturned")] Terminate terminate)
        {
            if (ModelState.IsValid)
            {
                db.Terminates.Add(terminate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BadgeId = new SelectList(db.Badges, "BadgeId",  terminate.BadgeId);
            return View(terminate);
        }

        // GET: Terminate/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terminate terminate = db.Terminates.Find(id);
            if (terminate == null)
            {
                return HttpNotFound();
            }
            ViewBag.BadgeId = new SelectList(db.Badges, "BadgeId", terminate.BadgeId);

            return View(terminate);
        }

        // POST: Terminate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UpId,BadgeId,DateJobTermination,BadgeTerminationDate,BadgeReturned")] Terminate terminate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(terminate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BadgeId = new SelectList(db.Badges, "BadgeId", terminate.BadgeId);
            return View(terminate);
        }

        // GET: Terminate/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terminate terminate = db.Terminates.Find(id);
            if (terminate == null)
            {
                return HttpNotFound();
            }
            return View(terminate);
        }

        // POST: Terminate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Terminate terminate = db.Terminates.Find(id);
            db.Terminates.Remove(terminate);
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

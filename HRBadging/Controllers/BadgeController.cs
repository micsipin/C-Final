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
    public class BadgeController : Controller
    {
        private BadgingContext db = new BadgingContext();

        // GET: Badge
        public ActionResult Index()
        {
            return View(db.Badges.ToList());
        }

        // GET: Badge/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Badge badge = db.Badges.Find(id);
            if (badge == null)
            {
                return HttpNotFound();
            }
            return View(badge);
        }

        // GET: Badge/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Badge/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BadgeId,BadgeExp,HasCustomSeal,CustomSealExp,SITA,EmployeeId")] Badge badge)
        {
            if (ModelState.IsValid)
            {
                db.Badges.Add(badge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(badge);
        }

        // GET: Badge/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Badge badge = db.Badges.Find(id);
            if (badge == null)
            {
                return HttpNotFound();
            }
            return View(badge);
        }

        // POST: Badge/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BadgeId,BadgeExp,HasCustomSeal,CustomSealExp,SITA,EmployeeId")] Badge badge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(badge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(badge);
        }

        // GET: Badge/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Badge badge = db.Badges.Find(id);
            if (badge == null)
            {
                return HttpNotFound();
            }
            return View(badge);
        }

        // POST: Badge/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Badge badge = db.Badges.Find(id);
            db.Badges.Remove(badge);
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

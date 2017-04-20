using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LiveJournal.Models;

namespace LiveJournal.Controllers
{
    public class JournalUsersController : Controller
    {
        private JournalDbContext db = new JournalDbContext();

        // GET: JournalUsers
        public ActionResult Index()
        {
            return View(db.JournalUsers.ToList());
        }

        // GET: JournalUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JournalUser journalUser = db.JournalUsers.Find(id);
            if (journalUser == null)
            {
                return HttpNotFound();
            }
            return View(journalUser);
        }

        // GET: JournalUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JournalUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Handle,ProfilePic")] JournalUser journalUser)
        {
            if (ModelState.IsValid)
            {
                db.JournalUsers.Add(journalUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(journalUser);
        }

        // GET: JournalUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JournalUser journalUser = db.JournalUsers.Find(id);
            if (journalUser == null)
            {
                return HttpNotFound();
            }
            return View(journalUser);
        }

        // POST: JournalUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Handle,ProfilePic")] JournalUser journalUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(journalUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(journalUser);
        }

        // GET: JournalUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JournalUser journalUser = db.JournalUsers.Find(id);
            if (journalUser == null)
            {
                return HttpNotFound();
            }
            return View(journalUser);
        }

        // POST: JournalUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JournalUser journalUser = db.JournalUsers.Find(id);
            db.JournalUsers.Remove(journalUser);
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

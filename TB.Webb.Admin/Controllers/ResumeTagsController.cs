using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TB.Webb.Admin.Models;

namespace TB.Webb.Admin.Controllers
{
    public class ResumeTagsController : Controller
    {
        private Entities db = new Entities();

        // GET: ResumeTags
        public ActionResult Index()
        {
            return View(db.ResumeTag.ToList());
        }

        // GET: ResumeTags/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResumeTag resumeTag = db.ResumeTag.Find(id);
            if (resumeTag == null)
            {
                return HttpNotFound();
            }
            return View(resumeTag);
        }

        // GET: ResumeTags/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResumeTags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tag")] ResumeTag resumeTag)
        {
            if (ModelState.IsValid)
            {
                db.ResumeTag.Add(resumeTag);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resumeTag);
        }

        // GET: ResumeTags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResumeTag resumeTag = db.ResumeTag.Find(id);
            if (resumeTag == null)
            {
                return HttpNotFound();
            }
            return View(resumeTag);
        }

        // POST: ResumeTags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tag")] ResumeTag resumeTag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resumeTag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resumeTag);
        }

        // GET: ResumeTags/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResumeTag resumeTag = db.ResumeTag.Find(id);
            if (resumeTag == null)
            {
                return HttpNotFound();
            }
            return View(resumeTag);
        }

        // POST: ResumeTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResumeTag resumeTag = db.ResumeTag.Find(id);
            db.ResumeTag.Remove(resumeTag);
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

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
    public class ResumeSectionsController : Controller
    {
        private Entities db = new Entities();

        // GET: ResumeSections
        public ActionResult Index()
        {
            var resumeSection = db.ResumeSection.Include(r => r.Resume);
            return View(resumeSection.ToList());
        }

        // GET: ResumeSections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResumeSection resumeSection = db.ResumeSection.Find(id);
            if (resumeSection == null)
            {
                return HttpNotFound();
            }
            return View(resumeSection);
        }

        // GET: ResumeSections/Create
        public ActionResult Create()
        {
            ViewBag.ResumeId = new SelectList(db.Resume, "Id", "ResumeHeader");
            return View();
        }

        // POST: ResumeSections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ResumeId,ContentHeader, Sorter")] ResumeSection resumeSection)
        {
            if (ModelState.IsValid)
            {
                db.ResumeSection.Add(resumeSection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ResumeId = new SelectList(db.Resume, "Id", "ResumeHeader", resumeSection.ResumeId);
            return View(resumeSection);
        }

        // GET: ResumeSections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResumeSection resumeSection = db.ResumeSection.Find(id);
            if (resumeSection == null)
            {
                return HttpNotFound();
            }
            ViewBag.ResumeId = new SelectList(db.Resume, "Id", "ResumeHeader", resumeSection.ResumeId);
            return View(resumeSection);
        }

        // POST: ResumeSections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ResumeId,ContentHeader, Sorter")] ResumeSection resumeSection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resumeSection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ResumeId = new SelectList(db.Resume, "Id", "ResumeHeader", resumeSection.ResumeId);
            return View(resumeSection);
        }

        // GET: ResumeSections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResumeSection resumeSection = db.ResumeSection.Find(id);
            if (resumeSection == null)
            {
                return HttpNotFound();
            }
            return View(resumeSection);
        }

        // POST: ResumeSections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResumeSection resumeSection = db.ResumeSection.Find(id);
            db.ResumeSection.Remove(resumeSection);
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

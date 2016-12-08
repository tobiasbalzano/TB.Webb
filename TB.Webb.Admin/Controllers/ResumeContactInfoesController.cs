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
    public class ResumeContactInfoesController : Controller
    {
        private Entities db = new Entities();

        // GET: ResumeContactInfoes
        public ActionResult Index()
        {
            return View(db.ResumeContactInfo.ToList());
        }

        // GET: ResumeContactInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResumeContactInfo resumeContactInfo = db.ResumeContactInfo.Find(id);
            if (resumeContactInfo == null)
            {
                return HttpNotFound();
            }
            return View(resumeContactInfo);
        }

        // GET: ResumeContactInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResumeContactInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Photo,Name,Email,Address,Phone,Phone2,Phone3,WebPage,Github,LinkedIn,ExternalLink1,ExternalLink2,ExternalLink3")] ResumeContactInfo resumeContactInfo)
        {
            if (ModelState.IsValid)
            {
                db.ResumeContactInfo.Add(resumeContactInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resumeContactInfo);
        }

        // GET: ResumeContactInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResumeContactInfo resumeContactInfo = db.ResumeContactInfo.Find(id);
            if (resumeContactInfo == null)
            {
                return HttpNotFound();
            }
            return View(resumeContactInfo);
        }

        // POST: ResumeContactInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Photo,Name,Email,Address,Phone,Phone2,Phone3,WebPage,Github,LinkedIn,ExternalLink1,ExternalLink2,ExternalLink3")] ResumeContactInfo resumeContactInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resumeContactInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resumeContactInfo);
        }

        // GET: ResumeContactInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResumeContactInfo resumeContactInfo = db.ResumeContactInfo.Find(id);
            if (resumeContactInfo == null)
            {
                return HttpNotFound();
            }
            return View(resumeContactInfo);
        }

        // POST: ResumeContactInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResumeContactInfo resumeContactInfo = db.ResumeContactInfo.Find(id);
            db.ResumeContactInfo.Remove(resumeContactInfo);
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

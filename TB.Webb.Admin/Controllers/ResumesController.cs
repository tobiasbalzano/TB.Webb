﻿using System;
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
    public class ResumesController : Controller
    {
        private Entities db = new Entities();

        // GET: Resumes
        public ActionResult Index()
        {
            var resume = db.Resume.Include(r => r.ResumeContactInfo1);
            return View(resume.ToList());
        }

        // GET: Resumes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resume resume = db.Resume.Find(id);
            if (resume == null)
            {
                return HttpNotFound();
            }
            return View(resume);
        }

        // GET: Resumes/Create
        public ActionResult Create()
        {
            ViewBag.ResumeContactInfoId = new SelectList(db.ResumeContactInfo, "Id", "Id");
            return View();
        }

        // POST: Resumes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ResumeHeader,ResumeContactInfoId")] Resume resume)
        {
            if (ModelState.IsValid)
            {
                db.Resume.Add(resume);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ResumeContactInfoId = new SelectList(db.ResumeContactInfo, "Id", "Id", resume.ResumeContactInfoId);
            return View(resume);
        }

        // GET: Resumes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resume resume = db.Resume.Find(id);
            if (resume == null)
            {
                return HttpNotFound();
            }
            ViewBag.ResumeContactInfoId = new SelectList(db.ResumeContactInfo, "Id", "Id", resume.ResumeContactInfoId);
            return View(resume);
        }

        // POST: Resumes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ResumeHeader,ResumeContactInfoId")] Resume resume)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resume).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ResumeContactInfoId = new SelectList(db.ResumeContactInfo, "Id", "Id", resume.ResumeContactInfoId);
            return View(resume);
        }

        // GET: Resumes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resume resume = db.Resume.Find(id);
            if (resume == null)
            {
                return HttpNotFound();
            }
            return View(resume);
        }

        // POST: Resumes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resume resume = db.Resume.Find(id);
            db.Resume.Remove(resume);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TB.Webb.Admin.Models;
using TB.Webb.Admin.Models.LogicalModels;
using TB.Webb.Admin.Models.ViewModels;

namespace TB.Webb.Admin.Controllers
{
    public class ResumeEntriesController : Controller
    {
        private Entities db = new Entities();

        // GET: ResumeEntries
        public ActionResult Index()
        {
            var resumeEntry = db.ResumeEntry.Include(r => r.ResumeSection);
            return View(resumeEntry.ToList());
        }

        public ActionResult SortByDate()
        {
            var resumeEntries = db.ResumeEntry.OrderBy(o => o.EndDate);
            int sorting = 1000;
            foreach (var entry in resumeEntries)
            {
                db.Entry(entry).Entity.Sorter = sorting++;
                db.Entry(entry).State = EntityState.Modified;

            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: ResumeEntries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResumeEntry resumeEntry = db.ResumeEntry.Find(id);
            if (resumeEntry == null)
            {
                return HttpNotFound();
            }
            return View(resumeEntry);
        }

        // GET: ResumeEntries/Create
        public ActionResult Create()
        {
            ViewBag.ResumeSectionId = new SelectList(db.ResumeSection, "Id", "ContentHeader");
            var alltags = db.ResumeTag.ToList();
            ViewBag.SelectedTags = alltags.Select(o => new SelectListItem
            {
                Text = o.Tag,
                Value = o.Id.ToString()
            });
            return View();
        }

        // POST: ResumeEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResumeSectionId, Entry, SelectedTags")] ResumeEntryVm resumeEntry, int resumeSectionId)
        {
            if (ModelState.IsValid)
            {
                if (resumeEntry.Entry.StartDate == resumeEntry.Entry.EndDate)
                {
                    resumeEntry.Entry.StartDate = null;
                    resumeEntry.Entry.EndDate = null;
                }
                if (resumeEntry.Entry.CurrentPosition)
                    resumeEntry.Entry.EndDate = new DateTime();
                resumeEntry.Entry.ResumeSectionId = resumeSectionId;
                resumeEntry.Entry.ResumeSection = db.ResumeSection.Find(resumeSectionId);
                foreach (var ti in resumeEntry.SelectedTags)
                {
                    resumeEntry.Entry.ResumeTag.Add(db.ResumeTag.Find(ti));
                }
                db.ResumeEntry.Add(resumeEntry.Entry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ResumeSectionId = new SelectList(db.ResumeSection, "Id", "ContentHeader", resumeEntry.Entry.ResumeSectionId);
            return View(resumeEntry);
        }

        // GET: ResumeEntries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ResumeEntryVm Vm = new ResumeEntryVm
            {
                Entry = db.ResumeEntry.Include(o => o.ResumeTag).Single(r => r.Id == id)
            };
            if (Vm.Entry == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            var alltags = db.ResumeTag.ToList();
            Vm.Tags = alltags.Select(o => new SelectListItem
            {
                Text = o.Tag,
                Value = o.Id.ToString()
            });

            ViewBag.ResumeSectionId = new SelectList(db.ResumeSection, "Id", "ContentHeader", Vm.Entry.ResumeSectionId);
            //resumeEntry.ResumeTag = (from o in db.ResumeTag where o.ResumeEntry == resumeEntry select o).ToList();
            return View(Vm);
        }

        // POST: ResumeEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResumeSectionId, Entry, SelectedTags")] ResumeEntryVm resumeEntry, int resumeSectionId)
        {
            var item = db.ResumeEntry.Find(resumeEntry.Entry.Id);
            item.Role = resumeEntry.Entry.Role;
            item.Establishment = resumeEntry.Entry.Establishment;
            item.Additional = resumeEntry.Entry.Additional;
            item.Description = resumeEntry.Entry.Description;
            item.StartDate = resumeEntry.Entry.StartDate;
            item.EndDate = resumeEntry.Entry.EndDate;
            item.CurrentPosition = resumeEntry.Entry.CurrentPosition;
            item.ResumeSectionId = resumeSectionId;
            item.Sorter = resumeEntry.Entry.Sorter;
            item.ResumeTag.Clear();
            foreach (var ti in resumeEntry.SelectedTags)
            {
                if (!item.ResumeTag.Any(t => t.Id == ti))
                    item.ResumeTag.Add(db.ResumeTag.Find(ti));
            }


            db.Entry(item).State = EntityState.Modified;
            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ResumeSectionId = new SelectList(db.ResumeSection, "Id", "ContentHeader", resumeEntry.Entry.ResumeSectionId);
            return View(resumeEntry);
        }

        // GET: ResumeEntries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResumeEntry resumeEntry = db.ResumeEntry.Find(id);
            if (resumeEntry == null)
            {
                return HttpNotFound();
            }
            return View(resumeEntry);
        }

        // POST: ResumeEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResumeEntry resumeEntry = db.ResumeEntry.Find(id);
            db.ResumeEntry.Remove(resumeEntry);
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

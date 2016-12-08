using System;
using System.Collections.Generic;
using System.Linq;
using TB.Webb.Models;

namespace TB.Webb.DataAccess
{
    public class ResumeInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ResumeContext>
    {
        protected override void Seed(ResumeContext context)
        {

            Resume seedres = new Resume()
            {
                ResumeHeader = "Tobias Balzano, CV",
                ResumeSections = new List<ResumeSection>(),
                ResumeContactInfo = new ResumeContactInfo()
            };
            ResumeContactInfo ResumeContactInfo = new ResumeContactInfo
            {
                Address = "Addressvägen 1",
                Email = "e@mail.com",
                Name = "Förnamn Efternamn",
                Phone = "Phone",
                ExternalLink1 = "http://www.youtube.com",
                Github = "github.com/tobiasbalzano",
                Photo = "/images/portraits/t_b_lrg.jpg",
                WebPage = "http://www.tobiasbalzano.se",

            };

            seedres.ResumeContactInfo = ResumeContactInfo;


            ResumeSection work = new ResumeSection
            {
                ContentHeader = "Work",
                Entries = new List<ResumeEntry>(),
                Resume = seedres
            };

            ResumeSection edu = new ResumeSection
            {
                ContentHeader = "Education",
                Entries = new List<ResumeEntry>(),
                Resume = seedres
            };

            seedres.ResumeSections.Add(work);
            seedres.ResumeSections.Add(edu);




            ResumeEntry adfahrer = new ResumeEntry()
            {
                ResumeSection = work,
                Role = "Programmer",
                Establishment = "Adfahrer Ab",
                Additional = "Part time",
                CurrentPosition = true,
                StartDate = DateTime.Now.AddYears(-2).AddMonths(-3).AddDays(-27),
                EndDate = DateTime.Now,
                Description = "Programmerare på adfahrer",
                Tags = new List<ResumeTag>(),
                Sorter = 1005
            };


            ResumeEntry fritiden = new ResumeEntry()
            {
                ResumeSection = work,
                Role = "Programmer",
                Establishment = "Fritiden",
                Additional = "Part time",
                CurrentPosition = true,
                StartDate = DateTime.Now.AddYears(-2).AddMonths(-3).AddDays(-27),
                EndDate = DateTime.Now,
                Description = "Programmerare på Fritiden",
                Tags = new List<ResumeTag>(),
                Sorter = 1001
            };


            ResumeEntry teknikh = new ResumeEntry()
            {
                ResumeSection = edu,
                Role = "Programmer .net",
                Establishment = "Tekniklhögskolan",
                Additional = "Part time",
                CurrentPosition = false,
                StartDate = DateTime.Now.AddYears(-2).AddMonths(-3).AddDays(-27),
                EndDate = DateTime.Now,
                Description = "Utbildning",
                Tags = new List<ResumeTag>(),
                Sorter = 1000
            };

            ResumeTag tagone = new ResumeTag()
            {
                Tag = "C#",
                ResumeEntries = new List<ResumeEntry>()

            };

            ResumeTag tagtwo = new ResumeTag()
            {
                Tag = "Asp .Net",
                ResumeEntries = new List<ResumeEntry>()
            };
            tagone.ResumeEntries.Add(adfahrer);
            tagone.ResumeEntries.Add(fritiden);
            tagone.ResumeEntries.Add(teknikh);

            tagtwo.ResumeEntries.Add(adfahrer);
            tagtwo.ResumeEntries.Add(fritiden);
            tagtwo.ResumeEntries.Add(teknikh);

            adfahrer.Tags.Add(tagone);
            adfahrer.Tags.Add(tagtwo);
            fritiden.Tags.Add(tagone);
            fritiden.Tags.Add(tagtwo);
            teknikh.Tags.Add(tagone);
            teknikh.Tags.Add(tagtwo);

            seedres.ResumeSections.First(o => o.ContentHeader == "Work").Entries.Add(adfahrer);
            seedres.ResumeSections.First(o => o.ContentHeader == "Work").Entries.Add(fritiden);
            seedres.ResumeSections.First(o => o.ContentHeader == "Education").Entries.Add(teknikh);

            context.Resumes.Add(seedres);
            context.SaveChanges();
        }
    }
}


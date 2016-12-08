using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TB.Webb.Models;

namespace TB.Webb.DataAccess
{
    public class ResumeEntryRepository : Repository
    {
        public List<ResumeEntry> ReadResumeEntries(int sectionId)
        {
            var resultSet = from o in DbContext.ResumeEntries where o.ResumeSectionId == sectionId select o;
            return resultSet.ToList();
        }

        public ResumeEntry ReadResumeEntry(int id)
        {
            var resultSet = from o in DbContext.ResumeEntries where o.Id == id select o;
            return resultSet.Single();
        }

        public ResumeEntry CreateResumeEntry(ResumeEntry inputEntry)
        {
            using (var context = DbContext)
            {
                context.Entry(inputEntry).State = EntityState.Added;
                context.SaveChanges();
                return context.Entry(inputEntry).Entity;
            }
        }

        public ResumeEntry UpdateResumeEntry(ResumeEntry inputEntry)
        {
            using (var context = DbContext)
            {
                context.Entry(inputEntry).State = EntityState.Modified;
                context.SaveChanges();
                return context.Entry(inputEntry).Entity;
            }
        }

        public bool DeleteResumeEntry(int id)
        {
            using (var context = DbContext)
            {
                var entry = from o in context.ResumeEntries where o.Id == id select o;
                context.Entry(entry.Single()).State = EntityState.Deleted;
                return context.SaveChanges() > 0;
            }
        }
    }
}

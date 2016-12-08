using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TB.Webb.Models;

namespace TB.Webb.DataAccess
{
    public class ResumeSectionRepository : Repository
    {

        public List<ResumeSection> ReadResumeSections(int resumeId)
        {
            var resultSet = from o in DbContext.ResumeSections where o.ResumeId == resumeId select o;
            return resultSet.ToList();
        }

        public ResumeSection ReadResumeSection(int id)
        {
            var resultSet = from o in DbContext.ResumeSections where o.Id == id select o;
            return resultSet.Single();
        }

        public ResumeSection CreateResumeSection(ResumeSection inputSection)
        {
            using (var context = DbContext)
            {
                context.Entry(inputSection).State = EntityState.Added;
                context.SaveChanges();
                return context.Entry(inputSection).Entity;
            }
        }

        public ResumeSection UpdateResumeSection(ResumeSection inputSection)
        {
            using (var context = DbContext)
            {
                context.Entry(inputSection).State = EntityState.Modified;
                context.SaveChanges();
                return context.Entry(inputSection).Entity;
            }
        }

        public bool DeleteResumeSection(int id)
        {
            using (var context = DbContext)
            {
                var entry = from o in context.ResumeSections where o.Id == id select o;
                context.Entry(entry.Single()).State = EntityState.Deleted;
                return context.SaveChanges() > 0;
            }
        }
    }
}
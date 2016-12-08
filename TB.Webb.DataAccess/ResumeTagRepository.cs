using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TB.Webb.Models;

namespace TB.Webb.DataAccess
{
    public class ResumeTagRepository : Repository
    {
        public List<ResumeTag> GetTags()
        {
            var resultSet = from o in DbContext.ResumeTags select o;
            return resultSet.ToList();
        }

        public ResumeTag GetTag(int id)
        {
            var resultSet = from o in DbContext.ResumeTags where o.Id == id select o;
            return resultSet.Single();
        }

        public ResumeTag CreateTag(ResumeTag tag)
        {
            using (var context = DbContext)
            {
                context.Entry(tag).State = EntityState.Added;
                context.SaveChanges();
                return context.Entry(tag).Entity;
            }
        }

        public ResumeTag UpdateTag(ResumeTag tag)
        {
            using (var context = DbContext)
            {
                context.Entry(tag).State = EntityState.Modified;
                context.SaveChanges();
                return context.Entry(tag).Entity;
            }
        }

        public bool DeleteTag(int id)
        {
            using (var context = DbContext)
            {
                var entry = from o in context.ResumeTags where o.Id == id select o;
                context.Entry(entry.Single()).State = EntityState.Deleted;
                return context.SaveChanges() > 0;
            }
        }
    }
}
using System.Data.Entity;
using System.Linq;
using TB.Webb.Models;

namespace TB.Webb.DataAccess
{
    public class ResumeRepository : Repository
    {

        public Resume ReadResume(int id)
        {
            var resultSet = from o in DbContext.Resumes where o.Id == id select o;
            
            return resultSet.Single();
        }

        public Resume CreateResume(Resume inputResume)
        {
            using (var context = DbContext)
            {
                context.Entry(inputResume).State = inputResume.Id == 0 ? EntityState.Added : EntityState.Modified;
                context.SaveChanges();
                return context.Entry(inputResume).Entity;
            }
        }

        public Resume UpdateResume(Resume inputResume)
        {
            using (var context = DbContext)
            {
                context.Entry(inputResume).State = EntityState.Modified;
                context.SaveChanges();
                return context.Entry(inputResume).Entity;
            }
        }

        public bool DeleteResume(int id)
        {
            using (var context = DbContext)
            {
                var entry = from o in context.Resumes where o.Id == id select o;
                context.Entry(entry).State = EntityState.Deleted;
                return context.SaveChanges() > 0;
            }
        }
    }
}
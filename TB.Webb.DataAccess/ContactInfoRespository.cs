using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TB.Webb.Models;

namespace TB.Webb.DataAccess
{
    public class ContactInfoRespository : Repository
    {
        public ResumeContactInfo ReadContactInfo(int Id)
        {
            var resultSet = from o in DbContext.ResumeContactInfos where o.Id == Id select o;
            return resultSet.Single();
        }

        public ResumeContactInfo CreateContactInfo(ResumeContactInfo inputInfo)
        {
            using (var context = DbContext)
            {
                context.Entry(inputInfo).State = EntityState.Added;
                context.SaveChanges();
                return context.Entry(inputInfo).Entity;
            }
        }

        public ResumeContactInfo UpdateContactInfo(ResumeContactInfo inputInfo)
        {
            using (var context = DbContext)
            {
                context.Entry(inputInfo).State = EntityState.Modified;
                context.SaveChanges();
                return context.Entry(inputInfo).Entity;
            }
        }

        public bool DeleteContactInfo(int id)
        {
            using (var context = DbContext)
            {
                var resultSet = from o in context.ResumeContactInfos where o.Id == id select o;
                context.Entry(resultSet.Single()).State = EntityState.Deleted;

                return context.SaveChanges() > 0;
            }
        }
    }
}

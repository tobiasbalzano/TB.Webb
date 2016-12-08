using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TB.Webb.DataAccess;
using TB.Webb.Models;

namespace TB.Webb.Logic
{
    public class ResumeEntryService
    {
        ResumeEntryRepository repo = new ResumeEntryRepository();

        public List<ResumeEntry> GetResumeEntries(int sectionId)
        {
            return repo.ReadResumeEntries(sectionId);
        }

        public ResumeEntry GetResumeEntry(int id)
        {
            return repo.ReadResumeEntry(id);
        }

        public ResumeEntry PostResumeEntry(ResumeEntry inpuEntry)
        {
            return repo.CreateResumeEntry(inpuEntry);
        }

        public ResumeEntry PutResumeEntry(ResumeEntry inputEntry)
        {
            return repo.UpdateResumeEntry(inputEntry);
        }

        public bool DeleteResumeEntry(int id)
        {
            return repo.DeleteResumeEntry(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TB.Webb.DataAccess;
using TB.Webb.Models;

namespace TB.Webb.Logic
{
    public class ResumeSectionService
    {
        ResumeSectionRepository repo = new ResumeSectionRepository();

        public List<ResumeSection> GetResumeSections(int resumeId)
        {
            return repo.ReadResumeSections(resumeId);
        }

        public ResumeSection GetResumeSection(int id)
        {
            return repo.ReadResumeSection(id);
        }

        public ResumeSection PostResumeSection(ResumeSection inpuSection)
        {
            return repo.CreateResumeSection(inpuSection);
        }

        public ResumeSection PutResumeSection(ResumeSection inputSection)
        {
            return repo.UpdateResumeSection(inputSection);
        }

        public bool DeleteResumeSection(int id)
        {
            return repo.DeleteResumeSection(id);
        }
    }
}

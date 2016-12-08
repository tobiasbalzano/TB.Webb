using System.Collections.Generic;
using TB.Webb.DataAccess;
using TB.Webb.Models;

namespace TB.Webb.Logic
{
    public class ResumeTagService
    {
        ResumeTagRepository repo = new ResumeTagRepository();

        public List<ResumeTag> GetResumeTags()
        {
            return repo.GetTags();
        }

        public ResumeTag GetResumeTag(int id)
        {
            return repo.GetTag(id);
        }

        public ResumeTag PostResumeTag(ResumeTag inputTag)
        {
            return repo.CreateTag(inputTag);
        }

        public ResumeTag PutResumeTag(ResumeTag inputTag)
        {
            return repo.UpdateTag(inputTag);
        }

        public bool DeleteResumeTag(int id)
        {
            return repo.DeleteTag(id);
        }
    }
}
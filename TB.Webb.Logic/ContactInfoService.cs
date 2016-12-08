using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TB.Webb.DataAccess;
using TB.Webb.Models;

namespace TB.Webb.Logic
{
    public class ContactInfoService
    {
        ContactInfoRespository repo = new ContactInfoRespository();

        public ResumeContactInfo GetContactInfo(int resumeId)
        {
            return repo.ReadContactInfo(resumeId);
        }

        public ResumeContactInfo PostContactInfo(ResumeContactInfo inputInfo)
        {
            return repo.CreateContactInfo(inputInfo);
        }

        public ResumeContactInfo PutContactInfo(ResumeContactInfo inputInfo)
        {
            return repo.UpdateContactInfo(inputInfo);
        }

        public bool DeleteContactInfo(int id)
        {
            return repo.DeleteContactInfo(id);
        }
    }
}

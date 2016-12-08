using TB.Webb.DataAccess;
using TB.Webb.Models;

namespace TB.Webb.Logic
{
    public class ResumeService
    {
        ResumeRepository Repo => new ResumeRepository();

        public Resume GetResume(int id)
        { 
            var resume = Repo.ReadResume(id);

            return Repo.ReadResume(id);
        }

        public Resume PostResume(Resume inputResume)
        {
            return Repo.CreateResume(inputResume);
        }

        public Resume PutResume(Resume inputResume)
        {
            return Repo.UpdateResume(inputResume);
        }

        public bool DeleteResume(int id)
        {
            return Repo.DeleteResume(id);
        }
    }
}

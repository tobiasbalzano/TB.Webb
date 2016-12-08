namespace TB.Webb.DataAccess
{
    public abstract class Repository
    {
        public ResumeContext DbContext => new ResumeContext();
    }
}

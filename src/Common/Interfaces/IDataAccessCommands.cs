using Common.Entities;

namespace Common.Interfaces
{
    public interface IDataAccessCommands
    {
        void CreateEmployer(Employer employer);
        void CreateJobSeeker(JobSeeker jobSeeker);
        void InsertJobAd(JobAd jobAd);
        void RemoveJobSeeker(int Id);
        void RemoveJobAd(int Id);
        void RemoveEmployer(int Id);        
    }
}
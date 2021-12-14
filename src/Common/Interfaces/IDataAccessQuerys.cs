using Common.Entities;
using System.Collections.Generic;


namespace Common.Interfaces
{
    public interface IDataAccessQuerys
    {
        List<Employer> GetAllEmployers();
        List<JobSeeker> GetAllJobSeekers();
        JobAd GetJobAd(int id);
        List<License> GetLicenses();
        List<JobAd> GetJobAds();
        List<Sector> GetSectors();
    }
}

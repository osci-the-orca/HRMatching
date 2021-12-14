using Common.Entities;
namespace Domain
{
    public class CheckLicense
    {
        JobAd jobAd { get; set; }
        JobSeeker jobSeeker { get; set; }
        public int CompareLicense(JobSeeker jobSeeker, JobAd jobAd)
        {
            int points = 0;
            if (jobAd.RequireLicense.License_Type == jobSeeker.HasLicense.License_Type)
            {
                points = 10;
            }
            return points;
        }
    }
}
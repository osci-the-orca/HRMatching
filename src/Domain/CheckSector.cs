using Common.Entities;

namespace Domain
{
    public class CheckSector
    {
        JobAd jobAd { get; set; }
        JobSeeker jobSeeker { get; set; }
        public int CompareSector(JobSeeker jobSeeker, JobAd jobAd)
        {
            int points = 0;
            if (jobSeeker.InSector.Sector_Type == jobAd.InSector.Sector_Type)
            {
                points = 1000;
            }
            return points;
        }
    }
}
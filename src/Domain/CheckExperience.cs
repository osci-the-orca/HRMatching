using Common.Entities;
namespace Domain
{
    public class CheckExperience
    {
        JobAd jobAd { get; set; }
        JobSeeker jobSeeker { get; set; }

        public int CompareExperience(JobSeeker jobSeeker, JobAd jobAd)
        {
            int points = 0;
            if (jobSeeker.YearsOfExperience >= jobAd.YearsOfExperience)
            {
                points = 10;
                if (jobSeeker.YearsOfExperience >= jobAd.YearsOfExperience)
                {
                    points += ((jobSeeker.YearsOfExperience - jobAd.YearsOfExperience) * 2);
                }
            }
            return points;
        }
    }

}
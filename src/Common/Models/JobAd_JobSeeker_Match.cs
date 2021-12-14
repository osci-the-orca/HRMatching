using Common.Entities;

namespace Common.Models
{
    public class JobAd_JobSeeker_Match
    {
        public JobAd jobAd { get; set; }
        public JobSeeker jobSeeker { get; set; }
        public int MatchRating { get; set; }
        public int MaxRating { get; set; }

        public JobAd_JobSeeker_Match()
        {
        }

        public JobAd_JobSeeker_Match(JobAd jobAd, JobSeeker jobSeeker, int matchRating, int maxRating)
        {
            this.jobAd = jobAd;
            this.jobSeeker = jobSeeker;
            this.MatchRating = matchRating;
            this.MaxRating = maxRating;
        }
    }
}
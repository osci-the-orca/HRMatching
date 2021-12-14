using Common.Entities;
using System.Collections.Generic;
using Common.Models;
namespace Common.Interfaces
{
    public interface ICalculator
    {
        List<JobAd_JobSeeker_Match> MatchThisJobAd(int numberOfMatches, List<JobSeeker> jobSeekers, JobAd jobAd);
    }
}
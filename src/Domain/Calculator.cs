using System.Collections.Generic;
using System.Linq;
using Common.Interfaces;
using Common.Entities;
using Common.Models;
namespace Domain
{
    public class Calculator : ICalculator
    {
        private readonly IDataAccessCommands _dataAccessCommands;

        private readonly IDataAccessQuerys _dataAccessQuerys;
        private CheckExperience _checkExperience;
        private CheckSector _checkSector;
        private CheckLicense _checkLicense;
        public Calculator(IDataAccessCommands dataAccessCommands, IDataAccessQuerys dataAccessQuerys, CheckExperience checkExperience, CheckSector checkSector, CheckLicense checkLicense)
        {
            _dataAccessCommands = dataAccessCommands;
            _dataAccessQuerys = dataAccessQuerys;
            _checkLicense = checkLicense;
            _checkSector = checkSector;
            _checkExperience = checkExperience;
        }
        public List<JobAd_JobSeeker_Match> MatchThisJobAd(int numberOfMatches, List<JobSeeker> jobSeekers, JobAd jobAd)
        {
            List<JobAd_JobSeeker_Match> selectedJobMatches = new();
            JobAd_JobSeeker_Match jobAd_JobSeeker_Match = new();
            foreach (JobSeeker jobSeeker in jobSeekers)
            {
                jobAd_JobSeeker_Match = new();
                jobAd_JobSeeker_Match.jobSeeker = jobSeeker;
                jobAd_JobSeeker_Match.jobAd = jobAd;
                int sectorScore = _checkSector.CompareSector(jobSeeker, jobAd);
                int licenseScore = _checkLicense.CompareLicense(jobSeeker, jobAd);
                int experienceScore = _checkExperience.CompareExperience(jobSeeker, jobAd);
                jobAd_JobSeeker_Match.MatchRating = sectorScore + licenseScore + experienceScore;
                if (jobAd_JobSeeker_Match.MatchRating > 1)
                {
                    selectedJobMatches.Add(jobAd_JobSeeker_Match);
                }

            }
            selectedJobMatches = selectedJobMatches.OrderByDescending(x => x.MatchRating).ToList();
            if (selectedJobMatches.Count > numberOfMatches)
            {
                selectedJobMatches.RemoveRange(numberOfMatches, selectedJobMatches.Count - numberOfMatches);
            }
            return selectedJobMatches;
        }
    }
}
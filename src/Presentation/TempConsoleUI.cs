using Domain;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using Common.Entities;
using Common.Models;
using System.Diagnostics;
namespace Presentation
{
    public class TempConsoleUI
    {
        public void CarlRun()
        {
            //för testning av Infrastruktur
            DataAccessCommands dataAccessCommands = new();
            DataAccessQuerys dataAccessQuerys = new();
            Console.WriteLine("Carl run körs");
            Debug.WriteLine("Carl run körs");
        }

        public void FransRun()
        {
            Console.WriteLine("Frans run körs");
            Debug.WriteLine("Frans run körs");
  
            var a = new CheckExperience();
            var b = new CheckSector();
            var c = new CheckLicense();

            Calculator calculator = new(new DataAccessCommands(), new DataAccessQuerys(), a, b, c);
            DataAccessQuerys DataBaseQuerys = new();
            List<JobAd> jobAds = DataBaseQuerys.GetJobAds();
            List<JobSeeker> jobSeekers = DataBaseQuerys.GetAllJobSeekers();
            List<JobAd_JobSeeker_Match> test = calculator.MatchThisJobAd(4, jobSeekers, jobAds.FirstOrDefault());

            Console.WriteLine("-------------------------------------------------------------");
            int place = 0;
            int totalNumsOfResult = 0;
            //För ett job
            foreach (JobAd_JobSeeker_Match newItem in test)
            {
                totalNumsOfResult = test.Count();
                place++;
                Console.WriteLine($"{newItem.jobSeeker.FirstName} {newItem.jobSeeker.LastName} fick placering {place} av {totalNumsOfResult}\n mot följande job {newItem.jobAd.JobAdEmployer} {newItem.MatchRating}");
            }
        }
    }
}
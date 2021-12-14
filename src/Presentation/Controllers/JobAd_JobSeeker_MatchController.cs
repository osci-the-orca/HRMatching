using Common.Entities;
using Common.Interfaces;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class JobAd_JobSeeker_MatchController : Controller
    {
        private JobAd_JobSeeker_MatchViewModel jobAd_JobSeeker_MatchViewModel;       
        private readonly IDataAccessQuerys _dataAccessQuerys;
        private readonly ICalculator _calculator;

        public JobAd_JobSeeker_MatchController(IDataAccessQuerys dataAccessQuerys, ICalculator calculator)
        {
            _dataAccessQuerys = dataAccessQuerys;
            _calculator = calculator;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult ShowJobSeekersMatchingJobAd(int Id)
        {           

            jobAd_JobSeeker_MatchViewModel = new JobAd_JobSeeker_MatchViewModel();

            List <JobSeeker>jobSeekers = _dataAccessQuerys.GetAllJobSeekers();

            JobAd jobAd = _dataAccessQuerys.GetJobAd(Id);

            jobAd_JobSeeker_MatchViewModel.ListOfJobSeekers = _calculator.MatchThisJobAd(4, jobSeekers, jobAd).Select(x => x.jobSeeker).ToList();

            jobAd_JobSeeker_MatchViewModel.JobAd = jobAd; 
           
            return View("ShowJobSeekersMatchingJobAd", jobAd_JobSeeker_MatchViewModel);
        }      
    }
}


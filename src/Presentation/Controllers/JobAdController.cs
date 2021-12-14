using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Entities;
using Presentation.ViewModels;
using Common.Interfaces;

namespace Presentation.Controllers
{
    public class JobAdController : Controller
    {
        private JobAdViewModel jobAdViewModel;
        private readonly IDataAccessCommands _dataAccessCommands;
        private readonly IDataAccessQuerys _dataAccessQuerys;
        
        public JobAdController(IDataAccessCommands dataAccessCommands, IDataAccessQuerys dataAccessQuerys)
        {
            _dataAccessCommands = dataAccessCommands;
            _dataAccessQuerys = dataAccessQuerys;
        }

        public IActionResult ListJobAds()
        {
            jobAdViewModel = new JobAdViewModel();
            
            jobAdViewModel.ListOfJobAds = _dataAccessQuerys.GetJobAds();

            jobAdViewModel.ListOfSectors = _dataAccessQuerys.GetSectors();
            jobAdViewModel.ListOfLicenses = _dataAccessQuerys.GetLicenses();
            jobAdViewModel.ListOfEmployers = _dataAccessQuerys.GetAllEmployers();
            
            return View("JobAdView", jobAdViewModel);
        }

        public IActionResult CreateJobAd(JobAdViewModel newJobAdViewModel)
        {
            jobAdViewModel = new JobAdViewModel();
            JobAd jobAd = new JobAd();

            jobAd.JobAdEmployer.Id = newJobAdViewModel.JobAdEmployer.Id;
            jobAd.Location = newJobAdViewModel.Location;
            jobAd.InSector.Id = newJobAdViewModel.InSector.Id;
            jobAd.RequireLicense.Id = newJobAdViewModel.RequireLicense.Id;
            jobAd.YearsOfExperience = newJobAdViewModel.YearsOfExperience;

            _dataAccessCommands.InsertJobAd(jobAd);
            ListJobAds();

            return View("JobAdView", jobAdViewModel);          
        }

        public IActionResult RemoveJobAd(int id)
        {
            jobAdViewModel = new JobAdViewModel();

            _dataAccessCommands.RemoveJobAd(id);
           
            ListJobAds();
            
            return View("JobAdView", jobAdViewModel);
        }
    }
}

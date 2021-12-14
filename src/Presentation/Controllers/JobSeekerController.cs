using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure;
using Domain;
using Common.Entities;
using Common.Interfaces;
using Presentation.ViewModels;

namespace Presentation.Controllers
{
    public class JobSeekerController : Controller
    {
        private JobSeekerViewModel jobSeekerViewModel;
        private readonly IDataAccessCommands _dataAccessCommands;
        private readonly IDataAccessQuerys _dataAccessQuerys;

        public JobSeekerController(IDataAccessCommands dataAccessCommands, IDataAccessQuerys dataAccessQuerys)
        {
            _dataAccessCommands = dataAccessCommands;
            _dataAccessQuerys = dataAccessQuerys;
        }

        public IActionResult ListJobSeekers()
        {
            jobSeekerViewModel = new JobSeekerViewModel();
            jobSeekerViewModel.ListOfJobSeekers = _dataAccessQuerys.GetAllJobSeekers();

            jobSeekerViewModel.ListOfSectors = _dataAccessQuerys.GetSectors();
            jobSeekerViewModel.ListOfLicenses = _dataAccessQuerys.GetLicenses();

            return View("JobSeekerView", jobSeekerViewModel);
        }

        public IActionResult CreateJobSeeker(JobSeekerViewModel newJobSeekerModel)
        {
            jobSeekerViewModel = new JobSeekerViewModel();
            JobSeeker jobSeeker = new JobSeeker();

            jobSeeker.FirstName = newJobSeekerModel.NewFirstName;
            jobSeeker.LastName = newJobSeekerModel.NewLastName;
            jobSeeker.YearBorn = newJobSeekerModel.YearBorn;
            jobSeeker.StreetAdress = newJobSeekerModel.StreetAdress;
            jobSeeker.PhoneNumber = newJobSeekerModel.NewPhoneNumber;
            jobSeeker.Email = newJobSeekerModel.NewEmailAdress;
            jobSeeker.Location = newJobSeekerModel.Location;
            jobSeeker.InSector.Id = newJobSeekerModel.InSector.Id;
            jobSeeker.HasLicense.Id = newJobSeekerModel.HasLicense.Id;
            jobSeeker.YearsOfExperience = newJobSeekerModel.YearsOfExperience;

            _dataAccessCommands.CreateJobSeeker(jobSeeker);

            ListJobSeekers();

            return View("JobSeekerView", jobSeekerViewModel);
        }

        public IActionResult RemoveJobSeeker(int Id)
        {
            jobSeekerViewModel = new JobSeekerViewModel();
            _dataAccessCommands.RemoveJobSeeker(Id);
            //jobSeekerViewModel.ListOfJobSeekers = _dataAccessQuerys.GetAllJobSeekers();
            return ListJobSeekers();

            //return View("JobSeekerView", jobSeekerViewModel);
        }
    }
}

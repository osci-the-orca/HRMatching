using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure;
using Presentation.ViewModels;
using Common.Interfaces;
using Common.Entities;

namespace Presentation.Controllers
{
    public class EmployerController : Controller
    {
        private EmployerViewModel employerViewModel;
        private readonly IDataAccessCommands _dataAccessCommands;
        private readonly IDataAccessQuerys _dataAccessQuerys;

        public EmployerController(IDataAccessCommands dataAccessCommands, IDataAccessQuerys dataAccessQuerys)
        {
            _dataAccessCommands = dataAccessCommands;
            _dataAccessQuerys = dataAccessQuerys;
        }

        public IActionResult ListEmployers()
        {
            employerViewModel = new EmployerViewModel();
            employerViewModel.ListOfEmployers = _dataAccessQuerys.GetAllEmployers();
           
            return View("EmployerView", employerViewModel);
        }

        public IActionResult CreateEmployer(EmployerViewModel newEmployerModel)
        {
            employerViewModel = new EmployerViewModel();

            Employer employer = new Employer();
            employer.Name = newEmployerModel.NewName;
            
            _dataAccessCommands.CreateEmployer(employer);
            employerViewModel.ListOfEmployers = _dataAccessQuerys.GetAllEmployers();

            return View("EmployerView", employerViewModel);
        }

        public IActionResult RemoveEmployer(int id)
        {
            employerViewModel = new EmployerViewModel();

            _dataAccessCommands.RemoveEmployer(id);

            ListEmployers();

            return View("EmployerView", employerViewModel);
        }
    }
}

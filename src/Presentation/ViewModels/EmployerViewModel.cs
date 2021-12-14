using Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
    public class EmployerViewModel
    {      
        public string NewName { get; set; }

        public List<Employer> ListOfEmployers { get; set; }
    }
}
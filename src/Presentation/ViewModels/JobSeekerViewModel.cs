using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentation.ViewModels
{
    public class JobSeekerViewModel
    { 
        public string NewFirstName { get; set; }
        public string NewLastName { get; set; }
        public DateTime YearBorn { get; set; }
        public string StreetAdress { get; set; }
        public string NewPhoneNumber { get; set; }
        public string NewEmailAdress { get; set; } 
        public string Location { get; set; }
        public Sector InSector { get; set; } = new();
        public License HasLicense { get; set; } = new();
        public int YearsOfExperience { get; set; } 
        
        public List<License> ListOfLicenses { get; set; } = new();
        public List<Sector> ListOfSectors { get; set; } = new();
        public List<JobSeeker> ListOfJobSeekers { get; set; }
    }
}

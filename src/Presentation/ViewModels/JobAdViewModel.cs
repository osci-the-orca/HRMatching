using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Entities;

namespace Presentation.ViewModels
{
    public class JobAdViewModel
    {
        public string Location { get; set; }
        public Employer JobAdEmployer { get; set; } = new();
        public License RequireLicense { get; set; } = new(); 
        public Sector InSector { get; set; } = new(); 
        public int YearsOfExperience { get; set; }
        
        public List<Sector> ListOfSectors { get; set; } = new();
        public List<License> ListOfLicenses { get; set; } = new();
        public List<Employer> ListOfEmployers { get; set; }
        public List<JobAd> ListOfJobAds { get; set; }               
    }
}

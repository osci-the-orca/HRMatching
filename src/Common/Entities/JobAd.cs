using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class JobAd
    {
        public int Id;
        public string Location { get; set; }
        public Employer JobAdEmployer { get; set; } = new();
        public License RequireLicense { get; set; } = new();//(tex k�rkort, food-safety...)
        public Sector InSector { get; set; } = new(); //(Livsmedel, It, transport...)
        public int YearsOfExperience { get; set; }
        public int Employer_Id { get; set; }

        //I version 0.1, s� skall BL kolla HasLicences, FieldOfWork, YearsOfExperience
        
    }
}
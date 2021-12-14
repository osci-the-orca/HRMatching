using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class JobSeeker
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime YearBorn { get; set; }
        public string StreetAdress { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public Sector InSector { get; set; } = new();//(Livsmedel, It, transport...)
        public License HasLicense { get; set; } = new(); //(tex körkort, food-safety...)       
        public int YearsOfExperience { get; set; }

    }
}


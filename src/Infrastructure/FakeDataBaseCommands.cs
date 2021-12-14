using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using Common.Entities;

namespace Infrastructure
{
    public class FakeDataBaseCommands : IDataAccessCommands
    {

        public void CreateEmployer(Employer employer)
        {
            Console.WriteLine("Create Employer");
        }

        public void CreateJobSeeker(JobSeeker jobSeeker)
        {
            Console.WriteLine("Create JobSeeker");
        }

        public void InsertJobAd(JobAd jobAd)
        {
            Console.WriteLine("Create Job ad!");
        }

        public void RemoveJobSeeker(int Id)
        {
            throw new NotImplementedException();
        }

        public void RemoveJobAd(int Id)
        {
            throw new NotImplementedException();
        }

        public void RemoveEmployer(int Id)
        {
            throw new NotImplementedException();
        }
    }
}

using Common.Interfaces;
using System;
using System.Collections.Generic;
using Common.Entities;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class FakeDataBaseQuerysV2 : IDataAccessQuerys
    {

        private License DriversLicense = new License(1, "Drivers License");
        private License ForkliftLicenseA = new License(2, "Forklift License A");
        private License ForkliftLicenseB = new License(3, "Forklift License B");
        private License OSHASafetyCertificate = new License(4, "OSHA Safety Certificate");
        private License CertifiedWelder = new License(5, "Certified Welder");
        private License FoodSaftey = new License(6, "Food Saftey");

        private Sector IT = new Sector(1, "IT");
        private Sector Livsmedel = new Sector(2, "Livsmedel");
        private Sector Welding = new Sector(3, "Welding");

        public List<Employer> GetAllEmployers() // Kanske slänga
        {
            List<Employer> employees = new();
            employees.Add(new Employer { Id = 1, Name = "Business A" });
            employees.Add(new Employer { Id = 2, Name = "Boras AB" });
            employees.Add(new Employer { Id = 3, Name = "Microsoft" });
            employees.Add(new Employer { Id = 4, Name = "Apple" });
            employees.Add(new Employer { Id = 5, Name = "ASDF Inc." });
            employees.Add(new Employer { Id = 6, Name = "Convini" });
            employees.Add(new Employer { Id = 7, Name = "Websocket" });
            employees.Add(new Employer { Id = 8, Name = "HttpsREQ-devs" });
            employees.Add(new Employer { Id = 9, Name = "Alphabet LCC" });

            return employees;
        }

        public List<JobSeeker> GetAllJobSeekers()
        {

            List<JobSeeker> jobSeekersList = new();
            jobSeekersList.Add(new JobSeeker { Id = 1, FirstName = "Olle", LastName = "Knutson", HasLicense = DriversLicense, InSector = Livsmedel, YearsOfExperience = 1 });
            jobSeekersList.Add(new JobSeeker { Id = 2, FirstName = "Adam", LastName = "Knutson", HasLicense = ForkliftLicenseA, InSector = Livsmedel, YearsOfExperience = 0 });
            jobSeekersList.Add(new JobSeeker { Id = 3, FirstName = "Bertin", LastName = "Knutson", HasLicense = ForkliftLicenseA, InSector = Livsmedel, YearsOfExperience = 3 });
            jobSeekersList.Add(new JobSeeker { Id = 4, FirstName = "Cesar", LastName = "Knutson", HasLicense = ForkliftLicenseA, InSector = Livsmedel, YearsOfExperience = 3 });
            jobSeekersList.Add(new JobSeeker { Id = 5, FirstName = "David", LastName = "Knutson", HasLicense = OSHASafetyCertificate, InSector = Welding, YearsOfExperience = 4 });

            jobSeekersList.Add(new JobSeeker { Id = 6, FirstName = "Erik", LastName = "Knutson", HasLicense = OSHASafetyCertificate, InSector = Welding, YearsOfExperience = 2 });
            jobSeekersList.Add(new JobSeeker { Id = 7, FirstName = "Fredrik", LastName = "Knutson", HasLicense = CertifiedWelder, InSector = Welding, YearsOfExperience = 0 });
            jobSeekersList.Add(new JobSeeker { Id = 8, FirstName = "Gustav", LastName = "Knutson", HasLicense = FoodSaftey, InSector = Livsmedel, YearsOfExperience = 0 });
            jobSeekersList.Add(new JobSeeker { Id = 9, FirstName = "Harald", LastName = "Knutson", HasLicense = FoodSaftey, InSector = Livsmedel, YearsOfExperience = 1 });
            jobSeekersList.Add(new JobSeeker { Id = 10, FirstName = "Ivar", LastName = "Knutson", HasLicense = FoodSaftey, InSector = Livsmedel, YearsOfExperience = 1 });

            return jobSeekersList;
        }
        public List<JobAd> GetJobAds()
        {
            List<JobAd> jobAdList = new();

            jobAdList.Add(new JobAd { Id = 1, Location = "Amsterdam", RequireLicense = FoodSaftey, InSector = Livsmedel, YearsOfExperience = 1 });
            jobAdList.Add(new JobAd { Id = 2, Location = "Borås", RequireLicense = ForkliftLicenseA, InSector = Livsmedel, YearsOfExperience = 0 });
            jobAdList.Add(new JobAd { Id = 3, Location = "Chicago", RequireLicense = ForkliftLicenseA, InSector = Livsmedel, YearsOfExperience = 2 });
            jobAdList.Add(new JobAd { Id = 4, Location = "Berlin", RequireLicense = DriversLicense, InSector = Livsmedel, YearsOfExperience = 3 });
            jobAdList.Add(new JobAd { Id = 5, Location = "Stockholm", RequireLicense = OSHASafetyCertificate, InSector = Welding, YearsOfExperience = 4 });

            jobAdList.Add(new JobAd { Id = 6, Location = "Alingsås", RequireLicense = OSHASafetyCertificate, InSector = Welding, YearsOfExperience = 2 });
            jobAdList.Add(new JobAd { Id = 7, Location = "Olso", RequireLicense = CertifiedWelder, InSector = Welding, YearsOfExperience = 0 });
            jobAdList.Add(new JobAd { Id = 8, Location = "Köpenhamn", RequireLicense = FoodSaftey, InSector = Livsmedel, YearsOfExperience = 0 });
            jobAdList.Add(new JobAd { Id = 9, Location = "Madrid", RequireLicense = FoodSaftey, InSector = Livsmedel, YearsOfExperience = 1 });
            jobAdList.Add(new JobAd { Id = 10, Location = "Moskva", RequireLicense = FoodSaftey, InSector = Livsmedel, YearsOfExperience = 3 });

            return jobAdList;
        }


        public List<License> GetLicenses()
        {
            List<License> license = new();
            return license;
        }



        JobAd IDataAccessQuerys.GetJobAd(int id)
        {
            throw new NotImplementedException();
        }

        public List<Sector> GetSectors()
        {
            throw new NotImplementedException();
        }
    }
}


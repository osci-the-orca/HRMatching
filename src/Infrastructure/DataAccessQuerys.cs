using Common.Entities;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace Infrastructure
{

    public class DataAccessQuerys : IDataAccessQuerys
    {
        private readonly string connectionString = "Server=40.85.84.155;Database=OOP_LILA;User=Student37;Password=big-bada-boom!";

        public List<Employer> GetAllEmployers()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Employer>("SELECT * FROM dbo.Employer").ToList(); //eventuellt fixa stored procedures
            }
        }

        public List<JobSeeker> GetAllJobSeekers()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<JobSeeker, Sector, License, JobSeeker>("EXEC Get_JobSeeker2",
                                                    (j, s, l) =>
                                                {
                                                    j.InSector = s;
                                                    j.HasLicense = l;
                                                    return j;
                                                }

                                                ).AsQueryable().ToList();
                //eventuellt fixa stored procedures
            }
        }

        public List<License> GetLicenses()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<License>("SELECT Id, License_Type FROM License").ToList();
            }
        }

        public List<JobAd> GetJobAds() //maybe change listtype to JobAd
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<JobAd, Employer, Sector, License, JobAd>(@"SELECT *, s.Sector_Type, l.License_Type FROM JobAd as j
                                                    JOIN Employer e on e.Id = j.Employer_Id
                                                    JOIN Sector s on s.Id = j.Sector_Id
	                                                JOIN License l on l.Id = j.License_Id",
                                                (j, e, s, l) =>
                                                {
                                                    j.JobAdEmployer = e;
                                                    j.InSector = s;
                                                    j.RequireLicense = l;

                                                    return j;
                                                }).AsQueryable().ToList();
            }
        }

        public List<Sector> GetSectors()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Sector>(@"Select Id, Sector_Type FROM Sector").ToList();
            }
        }

        public JobAd GetJobAd(int Id) //maybe change listtype to JobAd
        {
            using (var connection = new SqlConnection(connectionString))
            {

                return connection.Query<JobAd, Employer, Sector, License, JobAd>($"EXEC Get_JobAd_test @Id = {Id}",
                                                (j, e, s, l) =>
                                                {
                                                    j.JobAdEmployer = e;
                                                    j.InSector = s;
                                                    j.RequireLicense = l;
                                                    return j;
                                                }).AsQueryable().First();
            }
        }
    }
}



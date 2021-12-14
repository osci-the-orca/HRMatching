using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Entities;
using Common.Interfaces;
using Dapper;
using System.Data.SqlClient;

namespace Infrastructure
{
    public class DataAccessCommands : IDataAccessCommands
    {
        private readonly string connectionString = "Server=40.85.84.155;Database=OOP_LILA;User=Student37;Password=big-bada-boom!";
        public void CreateEmployer(Employer employer)
        {
            string sql = "EXEC Create_Employer @Name";

            using (var connection = new SqlConnection(connectionString))
            {
                var CreateEmployer = connection.Execute(sql, new { @Name = employer.Name });
            }
        }

        public void RemoveEmployer(int _employerId)
        {
            string sqlRemoveEmployer = "DELETE FROM dbo.employer WHERE Id = @Id";

            using (var connection = new SqlConnection(connectionString))
            {
                var RemoveEmployer = connection.Execute(sqlRemoveEmployer, new { @Id = _employerId });
            }
        }

        public void CreateJobSeeker(JobSeeker jobSeeker)
        {
            string sql = "EXEC Create_JobSeeker2 @FirstName, @LastName, @YearBorn, @StreetAdress, @PhoneNumber, @Email, @Location, @Sector_id, @License_id, @YearsOfExperience";

            using (var connection = new SqlConnection(connectionString))
            {
                var CreateJobSeeker = connection.Execute(sql, new
                {
                    @FirstName = jobSeeker.FirstName,
                    @LastName = jobSeeker.LastName,
                    @YearBorn = jobSeeker.YearBorn.Date.ToString("yyyy-MM-dd"),
                    @StreetAdress = jobSeeker.StreetAdress,
                    @PhoneNumber = jobSeeker.PhoneNumber,
                    @Email = jobSeeker.Email,
                    @Location = jobSeeker.Location,
                    @Sector_id = jobSeeker.InSector.Id,
                    @License_id = jobSeeker.HasLicense.Id,
                    @YearsOfExperience = jobSeeker.YearsOfExperience,
                });
            }
        }

        public void RemoveJobSeeker(int Id)
        {
            string sqlRemoveJobSeeker = "DELETE FROM dbo.jobSeeker WHERE Id = @Id";

            using (var connection = new SqlConnection(connectionString))
            {
                var RemoveJobSeeker = connection.Execute(sqlRemoveJobSeeker, new { @Id = Id });
            }
        }

        public void InsertJobAd(JobAd jobAd)
        {
            string sql = "EXEC Create_JobAd2 @Location, @Sector_Id, @License_Id, @YearsOfExperience, @Employer_Id";

            using (var connection = new SqlConnection(connectionString))
            {
                var InsertJobAd = connection.Execute(sql, new
                {
                    @Location = jobAd.Location,
                    @Sector_Id = jobAd.InSector.Id,
                    @License_Id = jobAd.RequireLicense.Id,
                    @YearsOfExperience = jobAd.YearsOfExperience,
                    @Employer_Id = jobAd.JobAdEmployer.Id
                });
            }
        }

        public void RemoveJobAd(int Id)
        {
            string sqlRemoveJobAd = "DELETE FROM dbo.JobAd WHERE Id = @Id";

            using (var connection = new SqlConnection(connectionString))
            {
                var RemoveJobAd = connection.Execute(sqlRemoveJobAd, new { @Id = Id });
            }
        }
    }
}
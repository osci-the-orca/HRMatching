using Common.Entities;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
    public class JobAd_JobSeeker_MatchViewModel
    {
        public JobAd JobAd { get; set; }
        
        public List <JobSeeker> ListOfJobSeekers { get; set; }     
    }
}

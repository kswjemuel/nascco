using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoopSystemWebApp.Models
{
    public class SpouseModel
    {
        public int SpouseId { get; set; }

        [Required]
        public string SpouseLastName { get; set; }

        [Required]
        public string SpouseFirstName { get; set; }

        [Required]
        public string SpouseMiddleName { get; set; }

        public string SpouseFullName { get; set; }
        public string SpouseMemberFullName { get; set; }
        

        [Required]
        public DateTime SpouseDateOfBirth { get; set; }

        public string SpouseContactNumber { get; set; }
        public string SpouseOccupation { get; set; }
        public string SpouseEmployer { get; set; }
        public string SpouseEmployerAddress { get; set; }
        public string SpouseEmployerContact { get; set; }
        public decimal? SpouseMonthlyIncome { get; set; }
        public int SpouseEmploymentStatus { get; set; }
        public DateTime? SpouseEmploymentDateStarted { get; set; }
        public DateTime? SpouseEmploymentDateEnded { get; set; }

        [Required]
        public int SpouseMemberId { get; set; }
        public bool SpouseIsEditMode { get; set; }
        public int SpouseCreatedByUserId { get; set; }
        
    }
}
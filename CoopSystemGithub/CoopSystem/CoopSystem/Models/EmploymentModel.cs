using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoopSystemWebApp.Models
{
    public class EmploymentModel
    {
        public int EmploymentId { get; set; }

        [Required]
        public string EmploymentPosition { get; set; }

        [Required]
        public DateTime EmploymentDateHired { get; set; }

        [Required]
        public string EmploymentEmployer { get; set; }

        [Required]
        public string EmploymentEmployerAddress { get; set; }

        [Required]
        public string EmploymentContactNumber { get; set; }

        [Required]
        public string EmploymentMonthlyIncome { get; set; }

        [Required]
        public int EmploymentMemberId { get; set; }

        public string EmploymentMemberName { get; set; }

    }
}
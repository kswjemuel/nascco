using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoopSystemWebApp.Models
{
    public class LoanApplicationModel
    {
        public int LoanApplicationId { get; set; }
        [Required]
        public int LoanApplicationMemberId { get; set; }

        [Required]
        public string LoanApplicationTermsOnPayment{ get; set; }

        [Required]
        public int LoanApplicationLoanTypeId { get; set; }

        public DateTime LoanApplicationDateCreated { get; set; }
        public DateTime LoanApplicationDateFromDate { get; set; }
        public DateTime LoanApplicationDateToDate { get; set; }
    }
}
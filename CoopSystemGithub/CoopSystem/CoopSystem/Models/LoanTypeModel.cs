using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoopSystemWebApp.Models
{
    public class LoanTypeModel
    {
        public int LoanTypeId { get; set; }
        [Required]
        public string LoanTypeDescription { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoopSystemWebApp.Models
{
    public class FeesCategoryModel
    {
        public int FeesCategoryId { get; set; }

        [Required]
        public string FeesCategoryDescription { get; set; }
    }
}
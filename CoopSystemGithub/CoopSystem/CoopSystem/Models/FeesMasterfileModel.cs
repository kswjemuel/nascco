using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoopSystemWebApp.Models
{
    public class FeesMasterfileModel
    {
        public int FeesMasterfileId { get; set; }

        [Required]
        public string FeesMasterfileDescription { get; set; }

        [Required]
        public string FeesMasterfileCategoryId { get; set; }
    }
}
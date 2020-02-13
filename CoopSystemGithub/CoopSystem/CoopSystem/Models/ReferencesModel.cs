using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoopSystemWebApp.Models
{
    public class ReferencesModel
    {
        public int ReferencesId { get; set; }

        [Required]
        public string ReferencesFullName { get; set; }

        [Required]
        public string ReferencesAddress { get; set; }

        [Required]
        public string ReferencesContactNumber { get; set; }

        [Required]
        public string ReferencesRelation { get; set; }

        [Required]
        public int ReferencesMemberId { get; set; }

        public string ReferencesMemberName { get; set; }
    }
}
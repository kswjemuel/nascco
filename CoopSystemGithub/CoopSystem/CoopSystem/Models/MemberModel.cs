using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoopSystemWebApp.Models
{
    public class MemberModel
    {
        public int MemberId { get; set; }
        public string PmesCertificateNumber { get; set; }
        public DateTime DateOfApplication { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string MiddleName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string PlaceOfBirth { get; set; }
        public string Heigth { get; set; }
        public string Weight { get; set; }

        [Required]
        public string Tin { get; set; }

        [Required]
        public string SssNumber { get; set; } 
        public string OthersId { get; set; }

        [Required]
        public string HighestEducation { get; set; }

        [Required]
        public string Course { get; set; }

        [Required]
        public string PresentAddress { get; set; }

        [Required]
        public string AddressStatus { get; set; }
        public string ProvincialAddress { get; set; }

        [Required]
        public string PresentAddressLengthOfTime { get; set; }

        [Required]
        public string ContactNumbers { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public int StatusesId  { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public bool MemberIsEditMode { get; set; }
        public int CreatedByUserId { get; set; }
        
    }
}
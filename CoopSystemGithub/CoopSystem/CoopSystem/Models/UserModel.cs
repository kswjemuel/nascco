using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoopSystemWebApp.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public int UserMemberId { get; set; }        
        public int RolesId { get; set; }
        public int UserStatusesId { get; set; }
        public string FullName { get; set; }
        public string RoleDescription { get; set; }
        public string StatusDescription { get; set; }
        public bool UserIsEditMode { get; set; }
        public int CreatedByUserId { get; set; }
        public String OldPassword { get; set; }

        [Required]
        [Display(Name = "Username")]
        [StringLength(50, ErrorMessage = "Username should be at least 3 characters long.", MinimumLength = 3)]
        public String Username { get; set; }

        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Your password must be at least 8 characters long.", MinimumLength = 8)]
        public String Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm password do not match.")]
        public String ConfirmPassword { get; set; }
    }
}
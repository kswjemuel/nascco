using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoopSystemWebApp.Models
{
    public class ActiveUserAccountViewModel
    {
        public long User_Acccount_Id { get; set; }
        public string User_Full_Name { get; set; }
        public string User_Email { get; set; }
    }
}
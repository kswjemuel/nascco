using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoopSystemWebApp.Models
{
    public class SettingsModel
    {
        public int SettingsId { get; set; }

        [Required]
        public string SettingsDescription { get; set; }

        [Required]
        public decimal SettingsValue { get; set; }
        public int SettingsFeesMasterfileId { get; set; }

        [Required]
        public string SettingsTags { get; set; }
    }
}
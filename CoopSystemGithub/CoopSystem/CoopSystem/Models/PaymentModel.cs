using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoopSystemWebApp.Models
{
    public class PaymentModel
    {
        public int PaymentId { get; set; }

        [Required]
        public int FeesMasterfileId { get; set; }

        [Required]
        public decimal PaymentAmount { get; set; }

        [Required]
        public int PaymentMemberId { get; set; }
        public DateTime PaymentDateCreated { get; set; }
    }
}
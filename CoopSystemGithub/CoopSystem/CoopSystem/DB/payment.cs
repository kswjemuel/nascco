//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoopSystemWebApp.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class payment
    {
        public int id { get; set; }
        public int fees_masterfile_id { get; set; }
        public decimal amount { get; set; }
        public System.DateTime date_created { get; set; }
        public int member_id { get; set; }
    
        public virtual fees_masterfile fees_masterfile { get; set; }
        public virtual member member { get; set; }
    }
}
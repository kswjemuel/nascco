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
    
    public partial class commercial
    {
        public long id { get; set; }
        public string description { get; set; }
        public long option_one_id { get; set; }
        public long option_two_id { get; set; }
        public long option_three_id { get; set; }
        public long status_id { get; set; }
    
        public virtual option option { get; set; }
        public virtual option option1 { get; set; }
        public virtual option option2 { get; set; }
        public virtual status status { get; set; }
    }
}
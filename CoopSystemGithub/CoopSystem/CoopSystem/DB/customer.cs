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
    
    public partial class customer
    {
        public long id { get; set; }
        public string description { get; set; }
        public int id_number { get; set; }
        public int spouse { get; set; }
        public int bio_child { get; set; }
        public int bio_child_over_eighten { get; set; }
        public int bio_child_over_twenty_six { get; set; }
        public int living_parents_in_law_under_seventy_six { get; set; }
        public int living_bio_parents_under_seventy_six { get; set; }
        public int additional_relations { get; set; }
        public long coverage_id { get; set; }
        public System.DateTime date_created { get; set; }
        public long created_by_id { get; set; }
        public Nullable<decimal> amount { get; set; }
    
        public virtual coverage coverage { get; set; }
    }
}

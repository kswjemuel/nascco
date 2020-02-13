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
    
    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            this.members = new HashSet<member>();
            this.spouses = new HashSet<spouse>();
        }
    
        public int id { get; set; }
        public int member_id { get; set; }
        public int roles_id { get; set; }
        public int statuses_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int created_by_user_id { get; set; }
        public System.DateTime date_created { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<member> members { get; set; }
        public virtual member member { get; set; }
        public virtual role role { get; set; }
        public virtual status status { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spouse> spouses { get; set; }
    }
}
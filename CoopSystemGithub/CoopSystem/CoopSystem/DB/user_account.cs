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
    
    public partial class user_account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user_account()
        {
            this.member_info = new HashSet<member_info>();
            this.registered_group = new HashSet<registered_group>();
            this.transactions = new HashSet<transaction>();
        }
    
        public long id { get; set; }
        public string full_name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public long status_id { get; set; }
        public long role_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<member_info> member_info { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<registered_group> registered_group { get; set; }
        public virtual role role { get; set; }
        public virtual status status { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<transaction> transactions { get; set; }
    }
}

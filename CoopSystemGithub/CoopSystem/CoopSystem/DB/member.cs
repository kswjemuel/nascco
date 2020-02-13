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
    
    public partial class member
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public member()
        {
            this.employments = new HashSet<employment>();
            this.loan_application = new HashSet<loan_application>();
            this.payments = new HashSet<payment>();
            this.references = new HashSet<reference>();
            this.users = new HashSet<user>();
            this.spouses = new HashSet<spouse>();
        }
    
        public int id { get; set; }
        public string pmes_certificate_number { get; set; }
        public System.DateTime date_of_application { get; set; }
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string middlename { get; set; }
        public System.DateTime date_of_birth { get; set; }
        public string place_of_birth { get; set; }
        public string height { get; set; }
        public string weight { get; set; }
        public string tin { get; set; }
        public string sss_number { get; set; }
        public string others_id { get; set; }
        public string highest_education { get; set; }
        public string course { get; set; }
        public string present_address { get; set; }
        public string address_status { get; set; }
        public string provincial_address { get; set; }
        public string present_address_lenght_of_time { get; set; }
        public string contact_numbers { get; set; }
        public string email_address { get; set; }
        public int statuses_id { get; set; }
        public int employee_id { get; set; }
        public int created_by_user_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<employment> employments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<loan_application> loan_application { get; set; }
        public virtual status status { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<payment> payments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reference> references { get; set; }
        public virtual user user { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user> users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spouse> spouses { get; set; }
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AspNetFinal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.Attendences = new HashSet<Attendence>();
            this.Awards = new HashSet<Award>();
            this.Leave_App = new HashSet<Leave_App>();
        }
    
        public int id { get; set; }
        public string emp_fullname { get; set; }
        public string emp_fathername { get; set; }
        public Nullable<System.DateTime> emp_dateof_birth { get; set; }
        public Nullable<int> emp_gender_id { get; set; }
        public string emp_phone { get; set; }
        public string emp_address { get; set; }
        public string emp_photo { get; set; }
        public string emp_email { get; set; }
        public string emp_password { get; set; }
        public Nullable<int> emp_dep_id { get; set; }
        public Nullable<int> emp_desig_id { get; set; }
        public Nullable<System.DateTime> emp_date_of_joining { get; set; }
        public Nullable<System.DateTime> emp_exit_date { get; set; }
        public Nullable<bool> emp_work_status { get; set; }
        public Nullable<double> emp_salary { get; set; }
        public string emp_resume { get; set; }
        public string emp_offer_letter { get; set; }
        public string emp_joining_letter { get; set; }
        public string emp_contact_and_argue { get; set; }
        public string emp_ID_proof { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Attendence> Attendences { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Award> Awards { get; set; }
        public virtual Departament Departament { get; set; }
        public virtual Designation Designation { get; set; }
        public virtual Gender Gender { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Leave_App> Leave_App { get; set; }
    }
}

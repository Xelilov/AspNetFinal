﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AspNetFinalEntities : DbContext
    {
        public AspNetFinalEntities()
            : base("name=AspNetFinalEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Attendence> Attendences { get; set; }
        public virtual DbSet<Award> Awards { get; set; }
        public virtual DbSet<Departament> Departaments { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Holiday> Holidays { get; set; }
        public virtual DbSet<Leave_status> Leave_status { get; set; }
        public virtual DbSet<Leave_type> Leave_type { get; set; }
        public virtual DbSet<Notice_Board> Notice_Board { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Leave_App> Leave_App { get; set; }
    }
}

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
    
    public partial class Award
    {
        public int id { get; set; }
        public Nullable<int> award_emp_id { get; set; }
        public string award_name { get; set; }
        public string award_reason { get; set; }
        public Nullable<double> award_cash_price { get; set; }
        public Nullable<System.DateTime> award_date { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}

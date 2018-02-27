using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspNetFinal.Models;

namespace AspNetFinal.Models
{
    
    public class UserViewModel
    {
        public Employee _employee { get; set; }
        public List<Notice_Board> _notice { get; set; }
        public List<Award> _award { get; set; }
        public List<Holiday> _holidays { get; set; }
        public List<Leave_App> _leave_app { get; set; }
        public List<Leave_status> _leave_status { get; set; }
    }
}
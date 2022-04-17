using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KBZPj_Web.Models
{
    public class LeaveRequestViewModel
    {
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Date { get; set; }
        public string LeaveType { get; set; }
        public string Note { get; set; }
        public string UserId { get; set; }
        public bool IsSuccess { get; set; }
    }
}
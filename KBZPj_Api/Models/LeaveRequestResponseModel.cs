using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KBZPj_Api.Models
{
    public class LeaveRequestResponseModel : BaseSubResponseModel
    {
        public List<LeaveRequestModel> lstleave { get; set; }
    }

    public class LeaveRequestModel
    {
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public string LeaveType { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Notes { get; set; }
    }

}
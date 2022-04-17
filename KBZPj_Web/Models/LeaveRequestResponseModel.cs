using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KBZPj_Web.Models
{
    public class LeaveRequestResponseModel
    {
        public string RespCode { get; set; }
        public string RespDesp { get; set; }
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KBZPj_Api.Models
{
    public class EmployeeRequestModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
    }
}
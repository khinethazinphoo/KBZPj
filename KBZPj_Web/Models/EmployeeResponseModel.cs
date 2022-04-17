using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KBZPj_Web.Models
{
    public class EmployeeResponseModel 
    {
        public string RespCode { get; set; }
        public string RespDesp { get; set; }
        public EmployeeModel EmployeeModel { get; set; }
        public List<EmployeeModel> lstEmployee { get; set; }
    }
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsSuccess { get; set; }
        public string UserId { get; set; }
    }
}
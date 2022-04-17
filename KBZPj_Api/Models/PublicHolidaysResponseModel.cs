using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KBZPj_Api.Models
{
    public class PublicHolidaysResponseModel : BaseSubResponseModel
    {
     public List<PublicHolidaysModel> lstModel { get; set; }
    }

    public class PublicHolidaysModel
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public string EmployeeName { get; set; }
        public string LeaveType { get; set; }
        public string FromDate { get; set; }
        public string EndDate { get; set; }
    }
}
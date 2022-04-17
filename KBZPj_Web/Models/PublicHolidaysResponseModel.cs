using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KBZPj_Web.Models
{
    public class PublicHolidaysResponseModel 
    {
        public string RespCode { get; set; }
        public string RespDesp { get; set; }
        public List<PublicHolidaysModel> lstModel { get; set; }
    }

    public class PublicHolidaysModel
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public string LeaveType { get; set; }
        public string EndDate { get; set; }
    }
}
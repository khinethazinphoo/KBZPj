using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KBZPj_Web.Models
{
    public class PublicHolidaysViewModel
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public bool IsSuccess { get; set; }
    }
}
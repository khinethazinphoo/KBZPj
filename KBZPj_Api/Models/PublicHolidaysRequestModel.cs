using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KBZPj_Api.Models
{
    public class PublicHolidaysRequestModel
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
    }
}
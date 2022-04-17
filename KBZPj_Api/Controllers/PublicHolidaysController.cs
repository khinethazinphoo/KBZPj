using KBZPj_Api.BussinessLogic;
using KBZPj_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace KBZPj_Api.Controllers
{
    [RoutePrefix("api")]
    public class PublicHolidaysController : ApiController
    {
        private readonly PublicHolidaysBLService l_PublicHolidaysBLService;
        public PublicHolidaysController()
        {
            l_PublicHolidaysBLService = new PublicHolidaysBLService();
        }

        [HttpPost]
        [Route("SetPublicHolidays")]
        public PublicHolidaysResponseModel SetPublicHolidays(PublicHolidaysRequestModel reqModel)
        {
            PublicHolidaysResponseModel model = new PublicHolidaysResponseModel();

            #region Assign Value 

            string l_UserId = reqModel.UserId;
            string l_Name = reqModel.Name;
            string l_Date = reqModel.Date;

            #endregion

            model = l_PublicHolidaysBLService.SetPublicHolidays(new PublicHolidaysRequestModel { 
                UserId = l_UserId,
                Name = l_Name,
                Date = l_Date
            });

            return model;
        }



        [HttpGet]
        [Route("GetPublicHolidays")]
        public PublicHolidaysResponseModel GetPublicHolidays()
        {
            PublicHolidaysResponseModel model = new PublicHolidaysResponseModel();

            #region Assign Value 

           

            #endregion

            model = l_PublicHolidaysBLService.GetPublicHolidaysAndLeaveRequest();

            return model;
        }
    }
}

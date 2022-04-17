using KBZPj_Api.DataAccess;
using KBZPj_Api.EntityFramework;
using KBZPj_Api.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KBZPj_Api.BussinessLogic
{
    public class PublicHolidaysBLService
    {
        private readonly PublicHolidaysDAService l_PublicHolidaysDAService;
        public PublicHolidaysBLService()
        {
            l_PublicHolidaysDAService = new PublicHolidaysDAService();
        }

        public PublicHolidaysResponseModel SetPublicHolidays(PublicHolidaysRequestModel reqModel)
        {
            PublicHolidaysResponseModel model = new PublicHolidaysResponseModel();

            var item = l_PublicHolidaysDAService.SetPublicHolidays(reqModel);
            if (item)
            {
                var l_Calendar = l_PublicHolidaysDAService.SetCalendar(reqModel);
            }

            model.RespCode = "000";
            model.RespDesp = "Create Successfully!!";
            return model;
        }

        public PublicHolidaysResponseModel GetPublicHolidays()
        {
            PublicHolidaysResponseModel model = new PublicHolidaysResponseModel();
            List<PublicHolidaysModel> lstModel = new List<PublicHolidaysModel>();
            List<tbl_PublicHolidays> lst = l_PublicHolidaysDAService.GetPublicHolidays();
            if (lst != null || lst.Count > 0)
            {
                lstModel = lst.AsEnumerable().Select(dr => dr.Change()).ToList();
                model.lstModel = lstModel;
            }
            model.RespCode = "000";
            model.RespDesp = "Create Successfully!!";

            return model;
        }

        public PublicHolidaysResponseModel GetPublicHolidaysAndLeaveRequest()
        {
            PublicHolidaysResponseModel model = new PublicHolidaysResponseModel();
            List<PublicHolidaysModel> lstModel = new List<PublicHolidaysModel>();
            List<tbl_Calendar> lst = l_PublicHolidaysDAService.GetPublicHolidaysAndLeaveRequest();
            if (lst != null || lst.Count > 0)
            {
                lstModel = lst.AsEnumerable().Select(dr => dr.Change()).ToList();
                model.lstModel = lstModel;
            }
            model.RespCode = "000";
            model.RespDesp = "Create Successfully!!";

            return model;
        }
    }
}
using KBZPj_Api.DataAccess;
using KBZPj_Api.EntityFramework;
using KBZPj_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KBZPj_Api.BussinessLogic
{
    public class LeaveRequestBLService
    {
        private readonly LeaveRequestDAService l_LeaveRequestDAService;
        public LeaveRequestBLService()
        {
            l_LeaveRequestDAService = new LeaveRequestDAService();
        }

        public LeaveRequestResponseModel SetLeaveRequest(LeaveRequestRequestModel reqModel)
        {
            LeaveRequestResponseModel model = new LeaveRequestResponseModel();
            
            var item = l_LeaveRequestDAService.InsertLeaveRequest(reqModel);
            if (item)
            {
                var l_Calendar = l_LeaveRequestDAService.SetCalendar(reqModel);
            }
            model.RespCode = "000";
            model.RespDesp = "Create Successfully!!";
            return model;
        }

        public LeaveRequestResponseModel GetLeaveRequest(LeaveRequestRequestModel reqModel)
        {
            LeaveRequestResponseModel model = new LeaveRequestResponseModel();
            List<LeaveRequestModel> lstModel = new List<LeaveRequestModel>();
            List<tbl_LeaveRequest> lst = new List<tbl_LeaveRequest>();
            if (reqModel.EmployeeName != null && reqModel.Department != null)
            {
                lst = l_LeaveRequestDAService.GetLeaveRequest(reqModel.EmployeeName, reqModel.Department);
            }
            else
            {
                lst = l_LeaveRequestDAService.GetLeaveRequestName(reqModel.EmployeeName, reqModel.Department);
            }
            if (lst != null || lst.Count > 0)
            {
                lstModel = lst.AsEnumerable().Select(dr => dr.Change()).ToList();
                model.lstleave = lstModel;
            }
            model.RespCode = "000";
            model.RespDesp = "Create Successfully!!";

            return model;
        }
    }
}
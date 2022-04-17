using KBZPj_Api.BussinessLogic;
using KBZPj_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KBZPj_Api.Controllers
{
    [RoutePrefix("api")]
    public class LeaveRequestController : ApiController
    {
        private readonly LeaveRequestBLService l_LeaveRequestBLService;
        public LeaveRequestController()
        {
            l_LeaveRequestBLService = new LeaveRequestBLService();
        }

        [HttpPost]
        [Route("SetLeaveRequest")]
        public LeaveRequestResponseModel SetLeaveRequest(LeaveRequestRequestModel reqModel)
        {
            LeaveRequestResponseModel model = new LeaveRequestResponseModel();

            #region Assign Value 
            string l_UserId = reqModel.UserId;
            string l_EmployeeName = reqModel.EmployeeName;
            string l_Department = reqModel.Department;
            string l_Date = reqModel.Date;
            string l_FromDate = reqModel.FromDate;
            string l_ToDate = reqModel.ToDate;
            string l_LeaveType = reqModel.LeaveType;
            string l_Note = reqModel.Note;

            #endregion

            model = l_LeaveRequestBLService.SetLeaveRequest(new LeaveRequestRequestModel
            {
                UserId = l_UserId,
                EmployeeName = l_EmployeeName,
                Department = l_Department,
                Date = l_Date,
                FromDate = l_FromDate,
                ToDate = l_ToDate,
                LeaveType = l_LeaveType,
                Note = l_Note

            });

            return model;
        }

        [HttpPost]
        [Route("GetLeaveRequest")]
        public LeaveRequestResponseModel GetLeaveRequest(LeaveRequestRequestModel reqModel )
        {
            LeaveRequestResponseModel model = new LeaveRequestResponseModel();

            #region Assign Value 
            string l_Name = reqModel.EmployeeName;
            string l_Dept = reqModel.Department;


            #endregion

            model = l_LeaveRequestBLService.GetLeaveRequest(new LeaveRequestRequestModel 
            {
                EmployeeName = l_Name,
                Department = l_Dept
            });

            return model;
        }
    }
}

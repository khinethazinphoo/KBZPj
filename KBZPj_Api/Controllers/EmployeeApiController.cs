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
    public class EmployeeApiController : ApiController
    {
        private readonly EmployeeBLService l_EmployeeBLService;
        public EmployeeApiController()
        {
            l_EmployeeBLService = new EmployeeBLService();
        }

        [HttpPost]
        [Route("SetEmployee")]
        public async Task<EmployeeResponseModel> SetEmployee(EmployeeRequestModel reqModel)
        {
            EmployeeResponseModel model = new EmployeeResponseModel();

            #region Assign Value 

            string l_EmployeeName = reqModel.EmployeeName;
            string l_Age = reqModel.Age;
            string l_Gender = reqModel.Gender;
            string l_Email = reqModel.Email;
            string l_PhoneNumber = reqModel.PhoneNumber;
            string l_UserId = reqModel.UserId;

            #endregion

            model = l_EmployeeBLService.SetEmployee(new EmployeeRequestModel
            {
               EmployeeName = l_EmployeeName,
               Age=  l_Age,
               Gender = l_Gender,
               Email = l_Email,
               PhoneNumber = l_PhoneNumber,
               UserId = l_UserId
            });
        
            return await Task.FromResult(model);
        }

        [HttpPost]
        [Route("GetEmployee")]
        public EmployeeResponseModel GetEmployee(EmployeeRequestModel reqModel)
        {
            EmployeeResponseModel model = new EmployeeResponseModel();

            #region Assign Value 

            string l_UserId = reqModel.UserId;

            #endregion

            model = l_EmployeeBLService.GetEmployee(new EmployeeRequestModel
            {
                UserId = l_UserId
            });

            return model;
        }

        [HttpPost]
        [Route("GetEmployeeForModify")]
        public EmployeeResponseModel GetEmployeeForModify(EmployeeRequestModel reqModel)
        {
            EmployeeResponseModel model = new EmployeeResponseModel();

            #region Assign Value 

            string l_UserId = reqModel.UserId;
            int l_EmployeeId = reqModel.EmployeeId;

            #endregion

            model = l_EmployeeBLService.GetEmployeeForModify(new EmployeeRequestModel
            {
                UserId = l_UserId,
                EmployeeId = l_EmployeeId
            });

            return model;
        }

        [HttpPost]
        [Route("ModifyEmployee")]
        public EmployeeResponseModel ModifyEmployee(EmployeeRequestModel reqModel)
        {
            EmployeeResponseModel model = new EmployeeResponseModel();

            #region Assign Value 

            string l_EmployeeName = reqModel.EmployeeName;
            string l_Age = reqModel.Age;
            string l_Gender = reqModel.Gender;
            string l_Email = reqModel.Email;
            string l_PhoneNumber = reqModel.PhoneNumber;
            string l_UserId = reqModel.UserId;
            int l_EmployeeId = reqModel.EmployeeId;

            #endregion

            model = l_EmployeeBLService.ModifyEmployee(new EmployeeRequestModel
            {
                UserId = l_UserId,
                EmployeeName = l_EmployeeName,
                Age = l_Age,
                Gender = l_Gender,
                Email = l_Email,
                PhoneNumber = l_PhoneNumber,
                EmployeeId = l_EmployeeId
            });

            return model;
        }

    }
}

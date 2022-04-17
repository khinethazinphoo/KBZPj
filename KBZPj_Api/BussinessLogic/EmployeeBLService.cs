using KBZPj_Api.DataAccess;
using KBZPj_Api.EntityFramework;
using KBZPj_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KBZPj_Api.BussinessLogic
{
    public class EmployeeBLService
    {
        private readonly EmployeeDAService l_EmployeeDAService;
        public EmployeeBLService()
        {
            l_EmployeeDAService = new EmployeeDAService();
        }

        public EmployeeResponseModel SetEmployee(EmployeeRequestModel reqModel)
        {
            EmployeeResponseModel model = new EmployeeResponseModel();

            var item = l_EmployeeDAService.InsertEmployee(reqModel);
            model.RespCode = "000";
            model.RespDesp = "Create Successfully!!";
            return model;
        }

        public EmployeeResponseModel GetEmployee(EmployeeRequestModel reqModel)
        {
            EmployeeResponseModel model = new EmployeeResponseModel();
            List<EmployeeModel> lstModel = new List<EmployeeModel>();
            List<tbl_Employee> lst = l_EmployeeDAService.GetEmployee(reqModel.UserId);
            if (lst != null || lst.Count > 0)
            {
                lstModel = lst.AsEnumerable().Select(dr => dr.Change()).ToList();
                model.lstEmployee = lstModel;
            }
            model.RespCode = "000";
            model.RespDesp = "Create Successfully!!";
            return model;
        }


        public EmployeeResponseModel GetEmployeeForModify(EmployeeRequestModel reqModel)
        {
            EmployeeResponseModel model = new EmployeeResponseModel();
           tbl_Employee item = l_EmployeeDAService.GetEmployeeForModify(reqModel.UserId,reqModel.EmployeeId);
            if (item != null)
            {
                model.EmployeeModel = item.Change();
            }
            model.RespCode = "000";
            model.RespDesp = "Create Successfully!!";
            return model;
        }

        public EmployeeResponseModel ModifyEmployee(EmployeeRequestModel reqModel)
        {
            EmployeeResponseModel model = new EmployeeResponseModel();

            var item = l_EmployeeDAService.ModifyEmployee(reqModel);
            model.RespCode = "000";
            model.RespDesp = "Create Successfully!!";
            return model;
        }
    }
}
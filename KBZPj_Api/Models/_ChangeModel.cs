using KBZPj_Api.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KBZPj_Api.Models
{
    public static class _ChangeModel
    {
        public static tbl_Employee Change(this EmployeeRequestModel reqModel)
        {
            tbl_Employee model = new tbl_Employee();
            model.EmployeeName = reqModel.EmployeeName;
            model.Age = reqModel.Age.CheckEntityItem<int>();
            model.Email = reqModel.Email;
            model.PhoneNumber = reqModel.PhoneNumber;
            model.Gender = reqModel.Gender;
            model.CreadedDateTime = DateTime.Now;
            model.UserId = reqModel.UserId;
            return model;
        }

        public static tbl_Employee ModifyChange(this tbl_Employee model ,EmployeeRequestModel reqModel)
        {
            model.EmployeeName = reqModel.EmployeeName;
            model.Age = reqModel.Age.CheckEntityItem<int>();
            model.Email = reqModel.Email;
            model.PhoneNumber = reqModel.PhoneNumber;
            model.Gender = reqModel.Gender;
            model.UpdatedDateTime = DateTime.Now;
            model.UserId = reqModel.UserId;
            return model;
        }

        public static tbl_LeaveRequest Change(this LeaveRequestRequestModel reqModel)
        {
            tbl_LeaveRequest model = new tbl_LeaveRequest();
            model.UserId = reqModel.UserId;
            model.EmployeeName = reqModel.EmployeeName;
            model.Department = reqModel.Department;
            model.FromDate = reqModel.FromDate.CheckEntityItem<DateTime>();

            model.ToDate = reqModel.ToDate.CheckEntityItem<DateTime>();
            model.LeaveType = reqModel.LeaveType;
            model.Notes = reqModel.Note;
            model.CreadedDateTime = DateTime.Now;
            return model;
        }

        public static tbl_Calendar ChangeCalendar(this LeaveRequestRequestModel reqModel)
        {
            tbl_Calendar model = new tbl_Calendar();
            model.UserId = reqModel.UserId;
            model.Name = reqModel.EmployeeName;
            model.Date = reqModel.FromDate.CheckEntityItem<DateTime>();
            model.EndDate = reqModel.ToDate.CheckEntityItem<DateTime>();
            model.LeaveType = reqModel.LeaveType;
            return model;
        }

        public static PublicHolidaysModel Change(this tbl_PublicHolidays reqModel)
        {
            PublicHolidaysModel model = new PublicHolidaysModel();
            model.Name = reqModel.Name;
            model.Date = reqModel.Date.CheckEntityItem<string>();
            return model;
        }

        public static PublicHolidaysModel Change(this tbl_Calendar reqModel)
        {
            PublicHolidaysModel model = new PublicHolidaysModel();
            model.Name = reqModel.Name;
            model.Date = reqModel.Date.CheckEntityItem<string>();
            if(reqModel.LeaveType != null)
            {
                model.Name = model.Name + ' ' + reqModel.LeaveType;
            }
            if(reqModel.EndDate != null)
            {
                model.EndDate = reqModel.EndDate.CheckEntityItem<string>();
            }
            return model;
        }

        public static LeaveRequestModel Change(this tbl_LeaveRequest reqModel)
        {
            LeaveRequestModel model = new LeaveRequestModel();
            model.EmployeeName = reqModel.EmployeeName;
            model.Department = reqModel.Department.CheckEntityItem<string>();
            model.FromDate = reqModel.FromDate.CheckEntityItem<string>();
            model.ToDate = reqModel.ToDate.CheckEntityItem<string>();
            model.Notes = reqModel.Notes;
            model.LeaveType = reqModel.LeaveType;
            return model;
        }

        public static EmployeeModel Change(this tbl_Employee reqModel)
        {
            EmployeeModel model = new EmployeeModel();
            model.EmployeeName = reqModel.EmployeeName;
            model.Age = reqModel.Age.CheckEntityItem<int>();
            model.PhoneNumber = reqModel.PhoneNumber;
            model.Gender = reqModel.Gender;
            model.Email = reqModel.Email;
            model.UserId = reqModel.UserId;
            model.EmployeeId = reqModel.EmployeeId;
            return model;
        }

        public static tbl_PublicHolidays Change(this PublicHolidaysRequestModel reqModel)
        {
            tbl_PublicHolidays model = new tbl_PublicHolidays();
            //model.UserId = reqModel.UserId;
            model.Name = reqModel.Name;
            model.Date = reqModel.Date.CheckEntityItem<DateTime>();
            return model;
        }

        public static tbl_Calendar ChangeCalendar(this PublicHolidaysRequestModel reqModel)
        {
            tbl_Calendar model = new tbl_Calendar();
            model.UserId = reqModel.UserId;
            model.Name = reqModel.Name;
            model.Date = reqModel.Date.CheckEntityItem<DateTime>();
            return model;
        }

        public static T CheckEntityItem<T>(this object obj)
        {
            T res = default(T);
            try
            {
                if (obj != null && !string.IsNullOrEmpty(obj.ToString()) && obj is string)
                    res = (T)Convert.ChangeType(obj.ToString().Trim(), typeof(T));
                else if (obj != null && !string.IsNullOrEmpty(obj.ToString()))
                    res = (T)Convert.ChangeType(obj, typeof(T));
            }
            catch (Exception ex)
            {
                // string message = ex;
            }

            return res;
        }
    }
}
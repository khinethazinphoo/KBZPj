using KBZPj_Api.EntityFramework;
using KBZPj_Api.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KBZPj_Api.DataAccess
{
    public class LeaveRequestDAService
    {
        private DataEntities db;
        public LeaveRequestDAService()
        {
            db = new DataEntities();
        }

        public bool InsertLeaveRequest(LeaveRequestRequestModel reqModel)
        {
            try
            {
                int res = 0;
                tbl_LeaveRequest item = reqModel.Change();
                db.tbl_LeaveRequest.Add(item);
                res = db.SaveChanges();
                return res == 1;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool SetCalendar(LeaveRequestRequestModel reqModel)
        {
            try
            {
                int res = 0;
                tbl_Calendar item = reqModel.ChangeCalendar();
                db.tbl_Calendar.Add(item);
                res = db.SaveChanges();
                return res == 1;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<tbl_LeaveRequest> GetLeaveRequest(string l_Name, string l_Dept)
        {
            try
            {

                var lst = db.tbl_LeaveRequest.Where(x => x.EmployeeName == l_Name && x.Department == l_Dept).AsNoTracking().ToList();
                return lst;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<tbl_LeaveRequest> GetLeaveRequestName(string l_Name, string l_Dept)
        {
            try
            {

                var lst = db.tbl_LeaveRequest.Where(x => x.EmployeeName == l_Name ||  x.Department == l_Dept).AsNoTracking().ToList();
                return lst;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
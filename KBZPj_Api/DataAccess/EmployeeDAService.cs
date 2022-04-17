using KBZPj_Api.EntityFramework;
using KBZPj_Api.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KBZPj_Api.DataAccess
{
    public class EmployeeDAService
    {
        private DataEntities db;
        public EmployeeDAService()
        {
            db = new DataEntities();
        }

        public bool InsertEmployee(EmployeeRequestModel reqModel)
        {
            try
            {
                int res = 0;
                tbl_Employee item = reqModel.Change();
                db.tbl_Employee.Add(item);
                res = db.SaveChanges();
                return res == 1;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<tbl_Employee> GetEmployee(string l_UserId)
        {
            try
            {
                var lst = db.tbl_Employee.Where(x=> x.UserId == l_UserId).AsNoTracking().ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public tbl_Employee GetEmployeeForModify(string l_UserId,int l_EmployeeId)
        {
            try
            {
                var item = db.tbl_Employee.Where(x => x.UserId == l_UserId && x.EmployeeId == l_EmployeeId).AsNoTracking().FirstOrDefault();
                return item;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool ModifyEmployee(EmployeeRequestModel reqModel)
        {
            try
            {
                bool res = false;
                int l_EmployeeId = reqModel.EmployeeId.CheckEntityItem<int>();
                tbl_Employee item = db.tbl_Employee
              .Where(x =>
                         x.UserId == reqModel.UserId &&
                         x.EmployeeId == reqModel.EmployeeId).FirstOrDefault();
                if (item != null)
                {
                    item = item.ModifyChange(reqModel);
                    db.tbl_Employee.AddOrUpdate();
                    int count = db.SaveChanges();
                    res = count == 1;
                }
                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }

}
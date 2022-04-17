using KBZPj_Api.EntityFramework;
using KBZPj_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KBZPj_Api.DataAccess
{
    public class PublicHolidaysDAService
    {
        private DataEntities db;
        public PublicHolidaysDAService()
        {
            db = new DataEntities();
        }

        public List<tbl_PublicHolidays> GetPublicHolidays()
        {
            try
            {
                var lst = db.tbl_PublicHolidays.AsNoTracking().ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //public List<Vw_Calendar> GetPublicHolidaysAndLeaveRequest()
        //{
        //    try
        //    {
        //        var lst = db.Vw_Calendar.AsNoTracking().ToList();
        //        return lst;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        public List<tbl_Calendar> GetPublicHolidaysAndLeaveRequest()
        {
            try
            {
                var lst = db.tbl_Calendar.AsNoTracking().ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool SetPublicHolidays(PublicHolidaysRequestModel reqModel)
        {
            try
            {
                int res = 0;
                tbl_PublicHolidays item = reqModel.Change();
                db.tbl_PublicHolidays.Add(item);
                res = db.SaveChanges();
                return res == 1;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool SetCalendar(PublicHolidaysRequestModel reqModel)
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
    }
}
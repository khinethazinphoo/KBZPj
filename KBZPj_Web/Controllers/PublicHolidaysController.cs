using KBZPj_Web.Models;
using KBZPj_Web.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace KBZPj_Web.Controllers
{
    public class PublicHolidaysController : Controller
    {
        public const string UserId = "89385865-0E5C-4235-A599-1EE8A2EFE432";
        // GET: PublicHolidays
        public ActionResult PublicHolidaysIndex()
        {
            return View();
        }

        [HttpPost]
        [ActionName("PublicHolidaysConfirm")]
        public ActionResult PublicHolidaysConfirm(PublicHolidaysViewModel reqModel)
        {
            Session["PublicHolidaysViewModel"] = reqModel;
            var url = "PublicHolidaysConfirm";
            return Json(new { RedirectUrl = url }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [ActionName("PublicHolidaysConfirm")]
        public ActionResult PublicHolidaysConfirm()
        {
            PublicHolidaysViewModel PublicHolidaysViewModel = Session["PublicHolidaysViewModel"] as PublicHolidaysViewModel;
            return View(PublicHolidaysViewModel);
        }

        [HttpPost]
        [ActionName("FinalConfirm")]
        public ActionResult FinalConfirm()
        {
            PublicHolidaysViewModel PublicHolidaysViewModel = Session["PublicHolidaysViewModel"] as PublicHolidaysViewModel;
            PublicHolidaysViewModel.UserId = UserId;
            PublicHolidaysViewModel.Date = PublicHolidaysViewModel.Date.CheckEntityItem<DateTime>().ToString("yyyy-MM-dd");
            //LeaveRequestViewModel.FromDate = LeaveRequestViewModel.FromDate.CheckEntityItem<DateTime>().ToString("yyyy-MM-dd");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44349/api/");
                var postJob = client.PostAsJsonAsync<PublicHolidaysViewModel>("SetPublicHolidays", PublicHolidaysViewModel);
                postJob.Wait();

                var postResult = postJob.Result;
                if (postResult.IsSuccessStatusCode)
                {
                    var l_Data = postResult.Content.ReadAsStringAsync().Result;
                    PublicHolidaysViewModel response1 =
                       JsonConvert.DeserializeObject<PublicHolidaysViewModel>(l_Data);
                    PublicHolidaysViewModel.IsSuccess = true;
                    goto Result;
                }

            }
        Result:
            return RedirectToAction("PublicHolidaysConfirm");
        }
    }
}
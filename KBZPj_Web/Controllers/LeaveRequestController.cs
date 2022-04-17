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
    public class LeaveRequestController : Controller
    {
        public const string UserId = "89385865-0E5C-4235-A599-1EE8A2EFE432";
        public static string DateFormat { get; } = "yyyy-MM-dd";
        // GET: LeaveRequest
        public ActionResult LeaveRequestIndex()
        {
            return View();
        }

        [HttpPost]
        [ActionName("LeaveRequestConfirm")]
        public ActionResult LeaveRequestConfirm(LeaveRequestViewModel reqModel)
        {
            Session["LeaveRequestViewModel"] = reqModel;
            var url = "LeaveRequestConfirm";
            return Json(new { RedirectUrl = url }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [ActionName("LeaveRequestConfirm")]
        public ActionResult LeaveRequestConfirm()
        {
            LeaveRequestViewModel LeaveRequestViewModel = Session["LeaveRequestViewModel"] as LeaveRequestViewModel;
            return View(LeaveRequestViewModel);
        }

        [HttpPost]
        [ActionName("FinalConfirm")]
        public ActionResult FinalConfirm()
        {
            LeaveRequestViewModel LeaveRequestViewModel = Session["LeaveRequestViewModel"] as LeaveRequestViewModel;
            LeaveRequestViewModel.UserId = UserId;

           
            LeaveRequestViewModel.Date = LeaveRequestViewModel.Date.CheckEntityItem<DateTime>().ToString("yyyy-MM-dd");
            LeaveRequestViewModel.FromDate = LeaveRequestViewModel.FromDate.CheckEntityItem<DateTime>().ToString("yyyy-MM-dd");
            LeaveRequestViewModel.ToDate = LeaveRequestViewModel.ToDate.CheckEntityItem<DateTime>().ToString("yyyy-MM-dd");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44349/api/");
                var postJob = client.PostAsJsonAsync<LeaveRequestViewModel>("SetLeaveRequest", LeaveRequestViewModel);
                postJob.Wait();

                var postResult = postJob.Result;
                if (postResult.IsSuccessStatusCode)
                {
                    var l_Data = postResult.Content.ReadAsStringAsync().Result;
                    LeaveRequestViewModel response1 =
                       JsonConvert.DeserializeObject<LeaveRequestViewModel>(l_Data);
                    LeaveRequestViewModel.IsSuccess = true;
                    goto Result;
                }

            }
        Result:
            return RedirectToAction("LeaveRequestConfirm");
        }


        //[HttpPost]
        //public ActionResult LeaveRequestIndex(LeaveRequestViewModel reqModel)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://localhost:44349/api/");
        //        var postJob = client.PostAsJsonAsync<LeaveRequestViewModel>("SetEmployee", reqModel);
        //        postJob.Wait();

        //        var postResult = postJob.Result;
        //        if (postResult.IsSuccessStatusCode)
        //            goto Result;
        //    }
        //Result:
        //    var url = "Home/Index";
        //    return Json(new { RedirectUrl = url }, JsonRequestBehavior.AllowGet);
        //}
    }
}


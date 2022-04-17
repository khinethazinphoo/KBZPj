using KBZPj_Web.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Web.Mvc;

namespace KBZPj_Web.Controllers
{
    public class EmployeeController : Controller
    {
        public const string UserId = "89385865-0E5C-4235-A599-1EE8A2EFE432";

        #region SetEmployee

        public ActionResult EmployeeIndex()
        {
            return View();
        }

        [HttpPost]
        [ActionName("EmployeeConfirm")]
        public ActionResult EmployeeConfirm(EmployeeViewModel reqModel)
        {
            Session["EmployeeViewModel"] = reqModel;
            var url = "EmployeeConfirm";
            return Json(new { RedirectUrl = url }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [ActionName("EmployeeConfirm")]
        public ActionResult EmployeeConfirm()
        {
            EmployeeViewModel EmployeeViewModel = Session["EmployeeViewModel"] as EmployeeViewModel;
            return View(EmployeeViewModel);
        }

        [HttpPost]
        [ActionName("FinalConfirm")]
        public ActionResult FinalConfirm()
        {
            EmployeeViewModel EmployeeViewModel = Session["EmployeeViewModel"] as EmployeeViewModel;
            EmployeeViewModel.UserId = UserId;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44349/api/");
                var postJob = client.PostAsJsonAsync<EmployeeViewModel>("SetEmployee", EmployeeViewModel);
                postJob.Wait();

                var postResult = postJob.Result;
                if (postResult.IsSuccessStatusCode)
                {
                    var l_Data = postResult.Content.ReadAsStringAsync().Result;
                    EmployeeViewModel response1 =
                       JsonConvert.DeserializeObject<EmployeeViewModel>(l_Data);
                    EmployeeViewModel.IsSuccess = true;
                    goto Result;
                }

            }
        Result:
            return RedirectToAction("EmployeeConfirm");
        }

        #endregion

        [HttpGet]
        [ActionName("EmployeeList")]
        public ActionResult EmployeeList(EmployeeViewModel reqModel)
        {
            EmployeeResponseModel model = new EmployeeResponseModel();
            reqModel.UserId = UserId;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44349/api/");
                var postJob = client.PostAsJsonAsync<EmployeeViewModel>("GetEmployee", reqModel);
                postJob.Wait();

                var postResult = postJob.Result;

                if (postResult.IsSuccessStatusCode)
                {
                    var l_Data = postResult.Content.ReadAsStringAsync().Result;
                    EmployeeResponseModel response1 =
                       JsonConvert.DeserializeObject<EmployeeResponseModel>(l_Data);
                    model.lstEmployee = response1.lstEmployee;

                    goto Result;
                }
            Result:
                return View(model.lstEmployee);
            }
        }

        #region Modify

        [HttpGet]
        [ActionName("EmployeeModify")]
        public ActionResult EmployeeModify()
        {
            EmployeeModel EmployeeModel = Session["EmployeeModel"] as EmployeeModel;
            return View(EmployeeModel);
        }

        [HttpPost]
        [ActionName("EmployeeModify")]
        public ActionResult EmployeeModify(EmployeeViewModel reqModel)
        {
            EmployeeResponseModel model = new EmployeeResponseModel();
            reqModel.UserId = UserId;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44349/api/");
                var postJob = client.PostAsJsonAsync<EmployeeViewModel>("GetEmployeeForModify", reqModel);
                postJob.Wait();

                var postResult = postJob.Result;

                if (postResult.IsSuccessStatusCode)
                {
                    var l_Data = postResult.Content.ReadAsStringAsync().Result;
                    EmployeeResponseModel response1 =
                       JsonConvert.DeserializeObject<EmployeeResponseModel>(l_Data);
                    model.EmployeeModel = response1.EmployeeModel;
                    Session["EmployeeModel"] = model.EmployeeModel;
                    goto Result;
                }
            Result:
                var url = "EmployeeModify";
                return Json(new { RedirectUrl = url }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ActionName("EmployeeModifyConfirm")]
        public ActionResult EmployeeModifyConfirm(EmployeeModel reqModel)
        {
            Session["EmployeeModel"] = reqModel;
            var url = "EmployeeModifyConfirm";
            return Json(new { RedirectUrl = url }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [ActionName("EmployeeModifyConfirm")]
        public ActionResult EmployeeModifyConfirm()
        {
            EmployeeModel EmployeeModel = Session["EmployeeModel"] as EmployeeModel;
            return View(EmployeeModel);
        }

        [HttpPost]
        [ActionName("ModifyFinalConfirm")]
        public ActionResult ModifyFinalConfirm()
        {
            EmployeeModel EmployeeModel = Session["EmployeeModel"] as EmployeeModel;
            EmployeeModel.UserId = UserId;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44349/api/");
                var postJob = client.PostAsJsonAsync<EmployeeModel>("GetEmployeeForModify", EmployeeModel);
                postJob.Wait();

                var postResult = postJob.Result;
                if (postResult.IsSuccessStatusCode)
                {
                    var l_Data = postResult.Content.ReadAsStringAsync().Result;
                    EmployeeModel response1 =
                       JsonConvert.DeserializeObject<EmployeeModel>(l_Data);
                    EmployeeModel.IsSuccess = true;
                    goto Result;
                }

            }
        Result:
            return RedirectToAction("EmployeeModifyConfirm");
        }

        #endregion

        [HttpPost]
        public ActionResult CallApi(EmployeeViewModel reqModel)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44349/api/");
                var postJob = client.PostAsJsonAsync<EmployeeViewModel>("SetEmployee", reqModel);
                postJob.Wait();

                var postResult = postJob.Result;
                if (postResult.IsSuccessStatusCode)
                    goto Result;
            }
        Result:
            var url = "Home/Index";
            return Json(new { RedirectUrl = url }, JsonRequestBehavior.AllowGet);

        }

    }
}
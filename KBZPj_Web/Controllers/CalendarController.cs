using KBZPj_Web.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace KBZPj_Web.Controllers
{
    public class CalendarController : Controller
    {
        // GET: Calendar
        public ActionResult CalendarIndex()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetEvents()
        {
            PublicHolidaysResponseModel model = new PublicHolidaysResponseModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44349/api/");
                var postJob = client.GetAsync("GetPublicHolidays");
                postJob.Wait();

                var postResult = postJob.Result;
                if (postResult.IsSuccessStatusCode)
                {
                    var l_Data = postResult.Content.ReadAsStringAsync().Result;
                    PublicHolidaysResponseModel response1 =
                       JsonConvert.DeserializeObject<PublicHolidaysResponseModel>(l_Data);
                    model.lstModel = response1.lstModel;
                    //events = model.ToString();
                    //var l = JsonConvert.SerializeObject(events);
                    //var obj = JsonConvert.DeserializeObject(events);
                    ////if (jObj.ContainsKey("PinId"))
                    ////{

                    ////}
                    //    json = JsonConvert.SerializeObject(model.lstModel, Formatting.Indented);
                    // if(model.lstModel.Count > 0)
                    //{
                    //    model.lstModel[0].Date = "2022-04-14";
                    //}
                    goto Result;

                }
            }
        Result:
            return Json(new { data = model.lstModel }, JsonRequestBehavior.AllowGet);
        }
    }
}
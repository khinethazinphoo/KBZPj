using CrystalDecisions.CrystalReports.Engine;
using KBZPj_Web.Models;
using KBZPj_Web.Service;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace KBZPj_Web.Controllers
{
    public class ReportController : Controller
    {
  
        public ActionResult ReportIndex()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Search")]
        public ActionResult Search(LeaveRequestModel reqModel)
        {
            LeaveRequestResponseModel model = new LeaveRequestResponseModel();
            using (var client = new HttpClient())  
            {
                client.BaseAddress = new Uri("https://localhost:44349/api/");
                var postJob = client.PostAsJsonAsync<LeaveRequestModel>("GetLeaveRequest", reqModel);
                //var postJob = client.GetAsync("GetLeaveRequest");
                postJob.Wait();

                var postResult = postJob.Result;

                if (postResult.IsSuccessStatusCode)
                {
                    var l_Data = postResult.Content.ReadAsStringAsync().Result;
                    LeaveRequestResponseModel response1 =
                       JsonConvert.DeserializeObject<LeaveRequestResponseModel>(l_Data);
                    model.lstleave = response1.lstleave;
                    //events = model.ToString();
                    //var l = JsonConvert.SerializeObject(events);
                    //var obj = JsonConvert.DeserializeObject(events);
                    ////if (jObj.ContainsKey("PinId"))
                    ////{

                    ////}
                    //    json = JsonConvert.SerializeObject(model.lstModel, Formatting.Indented);
                    Session["LeaveRequestResponseModel"] = model.lstleave;
                    goto Result;
                }
            Result:
                return Json(new { Response = model.lstleave }, JsonRequestBehavior.AllowGet);
            }

        }

        [ActionName("ReportList")]
        public ActionResult ReportList()
        {
            List<LeaveRequestModel> leaveRequest = Session["LeaveRequestResponseModel"] as List<LeaveRequestModel>;
            if (Session["LeaveRequestResponseModel"] == null)
            {
                return null;
            }
            return View(leaveRequest);
        }

        [HttpPost]
        [ActionName("ReportList")]
        public ActionResult ReportList(LeaveRequestModel reqModel)
        {
            LeaveRequestResponseModel model = new LeaveRequestResponseModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44349/api/");
                var postJob = client.PostAsJsonAsync<LeaveRequestModel>("GetLeaveRequest", reqModel);
                //var postJob = client.GetAsync("GetLeaveRequest");
                postJob.Wait();

                var postResult = postJob.Result;

                if (postResult.IsSuccessStatusCode)
                {
                    var l_Data = postResult.Content.ReadAsStringAsync().Result;
                    LeaveRequestResponseModel response1 =
                       JsonConvert.DeserializeObject<LeaveRequestResponseModel>(l_Data);
                    model.lstleave = response1.lstleave;
                    //events = model.ToString();
                    //var l = JsonConvert.SerializeObject(events);
                    //var obj = JsonConvert.DeserializeObject(events);
                    ////if (jObj.ContainsKey("PinId"))
                    ////{

                    ////}
                    //    json = JsonConvert.SerializeObject(model.lstModel, Formatting.Indented);
                    if(model.lstleave.Count > 0)
                    {
                        foreach (var item in model.lstleave)
                        {
                            item.FromDate = item.FromDate.CheckEntityItem<DateTime>().ToString("dd-MM-yyyy");
                            item.ToDate = item.ToDate.CheckEntityItem<DateTime>().ToString("dd-MM-yyyy");
                        }
                    }
                    Session["LeaveRequestResponseModel"] = model.lstleave;
                    goto Result;
                }
            Result:
                var url = "ReportList";
                return Json(new { RedirectUrl = url }, JsonRequestBehavior.AllowGet);
            }

        }


        [ActionName("Download_PDF")]
        public ActionResult Download_PDF()
        {
            List<LeaveRequestModel> leaveRequest = Session["LeaveRequestResponseModel"] as List<LeaveRequestModel>;
            //foreach (var item in leaveRequest)
            //{
            //    item.FromDate = item.FromDate.CheckEntityItem<DateTime>().ToString("dd-MM-yyyy");
            //    item.ToDate = item.ToDate.CheckEntityItem<DateTime>().ToString("dd-MM-yyyy");
            //}
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "LeaveRequestReport.rpt"));
            rd.SetDataSource(leaveRequest);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "LeaveRequestReport.pdf");
        }

        [ActionName("Export")]
        public ActionResult ExportExcel()
        {
            List<LeaveRequestModel> reqModel = Session["LeaveRequestResponseModel"] as List<LeaveRequestModel>;
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Leave Request List");
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;
            //Header of table  
            //  
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;
            workSheet.Cells[1, 1].Value = "No";
            workSheet.Cells[1, 2].Value = "Employee Name";
            workSheet.Cells[1, 3].Value = "Department";
            workSheet.Cells[1, 4].Value = "LeaveType";
            workSheet.Cells[1, 5].Value = "FromDate";
            workSheet.Cells[1, 6].Value = "ToDate";
            workSheet.Cells[1, 7].Value = "Notes";
            //Body of table  
            //  
            int recordIndex = 2;
            foreach (var item in reqModel)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = item.EmployeeName;
                workSheet.Cells[recordIndex, 3].Value = item.Department;
                workSheet.Cells[recordIndex, 4].Value = item.LeaveType;
                workSheet.Cells[recordIndex, 5].Value = item.FromDate;
                workSheet.Cells[recordIndex, 6].Value = item.ToDate;
                workSheet.Cells[recordIndex, 7].Value = item.Notes;
                recordIndex++;
            }
            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();
            workSheet.Column(4).AutoFit();
            workSheet.Column(5).AutoFit();
            workSheet.Column(6).AutoFit();
            workSheet.Column(7).AutoFit();
            string excelName = "LeaveRequest";
            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment; filename=" + excelName + ".xlsx");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
            return null;
        }
    }
}
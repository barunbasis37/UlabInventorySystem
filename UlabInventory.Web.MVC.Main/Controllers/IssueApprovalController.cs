using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Authentication.ExtendedProtection;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Reporting.WebForms;
using ULABInventory.Model;
using ULABInventory.Repository;
using ULABInventory.ViewModels;

namespace UlabInventory.Web.MVC.Main.Controllers
{
    [Authorize]
    public class IssueApprovalController : Controller
    {
        private InventoryDbContext dc = new InventoryDbContext();
        private IssueApprovedRepository aIssueAppDetailRepo = new IssueApprovedRepository();
        private IssueItemStage aIssueItemStage = new IssueItemStage();
        
        [HttpGet]
        public ActionResult GetIssueApprovedItemList()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetIssueItemListForDamage()
        {
            return View();
        }


        [HttpPost]
        public JsonResult ReturnIssueItemUpdate(string issueAppId, string returnRemarks)
        {
            bool status = false;
            
            using (dc)
            {
                using (var transaction = dc.Database.BeginTransaction())
                {
                    IssueApproved aIssueApprovedDb =
                        dc.IssueApproveds.FirstOrDefault(issD => issD.IssueApprovedId == issueAppId);
                    aIssueApprovedDb.CurrentStatus = aIssueItemStage.Returned;
                    aIssueApprovedDb.ReturnRemarks = returnRemarks;
                    aIssueApprovedDb.ReturnBy = User.Identity.Name;
                    aIssueApprovedDb.ReturnDate = DateTime.Now;
                    aIssueApprovedDb.ReturnIp = Request.UserHostAddress;
                    aIssueApprovedDb.UpdatedBy = User.Identity.Name;
                    aIssueApprovedDb.UpdatedDate = DateTime.Now;
                    aIssueApprovedDb.UpdatedIp = Request.UserHostAddress;
                    dc.Entry(aIssueApprovedDb).State = EntityState.Modified;
                    //dc.SaveChanges();

                    RequisitionDetail aRequisitionDetail = dc.RequisitionDetail.FirstOrDefault(reqD =>
                        reqD.RequisitionDetailId == aIssueApprovedDb.RequisitionDId);
                    CheckInDetail aCheckIndetailDB = dc.CheckInDetail.FirstOrDefault(chkD =>
                        chkD.CheckInDetailId == aRequisitionDetail.CheckInDetailIdCode);
                    aCheckIndetailDB.CurrentStatus = aIssueItemStage.Available;
                    aCheckIndetailDB.UpdatedBy = User.Identity.Name;
                    aCheckIndetailDB.UpdatedDate = DateTime.Now;
                    aCheckIndetailDB.UpdatedIp = Request.UserHostAddress;
                    dc.Entry(aCheckIndetailDB).State = EntityState.Modified;

                    dc.SaveChanges();
                    status = true;
                    transaction.Commit();
                }

               

            }
            //}
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DamageIssueItemUpdate(string issueAppId, string disposalRemarks)
        {
            bool status = false;

            using (dc)
            {
                using (var transaction = dc.Database.BeginTransaction())
                {
                    IssueApproved aIssueApprovedDb =
                        dc.IssueApproveds.FirstOrDefault(issD => issD.IssueApprovedId == issueAppId);
                    aIssueApprovedDb.CurrentStatus = aIssueItemStage.Disposal;
                    aIssueApprovedDb.GarbageDescription = disposalRemarks;
                    aIssueApprovedDb.GarbageBy = User.Identity.Name;
                    aIssueApprovedDb.GarbageDate = DateTime.Now;
                    aIssueApprovedDb.GarbageIp = Request.UserHostAddress;
                    aIssueApprovedDb.UpdatedBy = User.Identity.Name;
                    aIssueApprovedDb.UpdatedDate = DateTime.Now;
                    aIssueApprovedDb.UpdatedIp = Request.UserHostAddress;
                    dc.Entry(aIssueApprovedDb).State = EntityState.Modified;
                    dc.SaveChanges();
                    status = true;
                    transaction.Commit();
                }



            }
            //}
            return new JsonResult { Data = new { status = status } };
        }

        public ActionResult IssueDetailsViewReport()
        {
            return View();

        }

        public ActionResult IssueDetailReport(string id)
        {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "rptIssueDetail.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return View("IssueDetailReport");
            }
            List<IssueApprovedVM> cm = new List<IssueApprovedVM>();
            using (dc)
            {
                cm = aIssueAppDetailRepo.GetAllIssueApprovedList();
            }
            ReportDataSource rd = new ReportDataSource("IssueDetailDS", cm);
            lr.DataSources.Add(rd);
            string reportType = "PDF";
            string mimeType;
            string encoding;
            string fileNameExtension;



            string deviceInfo =

            "<DeviceInfo>" +
            "  <OutputFormat>" + id + "</OutputFormat>" +
            "  <PageOrientation>Landsape</PageOrientation>" +
            "  <PageWidth>11.49in</PageWidth>" +
            "  <PageHeight>8.27in</PageHeight>" +
            "  <MarginTop>0.2in</MarginTop>" +
            "  <MarginLeft>0.2in</MarginLeft>" +
            "  <MarginRight>0.2in</MarginRight>" +
            "  <MarginBottom>0.2in</MarginBottom>" +
            //"<TablixMember>" +
               //"<KeepWithGroup>After</KeepWithGroup>" +
               //"<RepeatOnNewPage>true</RepeatOnNewPage>" +
               //"<KeepTogether>true</KeepTogether>" +
            //"</TablixMember>" +
            "</DeviceInfo>";

//            "< TablixMember >" +
//   "< KeepWithGroup > After </ KeepWithGroup >" +
//   "< RepeatOnNewPage > true </ RepeatOnNewPage >" +
//   "< KeepTogether > true </ KeepTogether >" +
//"</ TablixMember >";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = lr.Render(
                reportType, deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);


            //// Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
            //string pathdownload = Server.MapPath("~/Reports/Download/");
            //Random rnd = new Random();
            //int month = rnd.Next(1, 13); // creates a number between 1 and 12
            //int dice = rnd.Next(1, 7); // creates a number between 1 and 6
            //int card = rnd.Next(9); // creates a number between 0 and 51
            //string file_name = "ItemDetails" + month + dice + card + ".pdf"; //save the file in unique name 

            ////3. After that use file stream to write from bytes to pdf file on your server path

            //FileStream file = new FileStream(pathdownload + "/" + file_name, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //file.Write(renderedBytes, 0, renderedBytes.Length);
            //file.Dispose();

            ////4.path the file name by using query string to new page 

            //Response.Write(string.Format("<script>window.open('{0}','_blank');</script>", "ItemDetailReport?file=" + file_name));
            return File(renderedBytes, mimeType);
        }

    }
}
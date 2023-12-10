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
    public class IssueDetailsMultipleController : Controller
    {
        private InventoryDbContext dc = new InventoryDbContext();
        private IssueDetailRepository aIssueDetailRepo = new IssueDetailRepository();
        // GET: IssueDetailsMultiple
        public ActionResult CreateMultipleIssueDetail()
        {
            return View();
        }

        public ActionResult CreateIssue()
        {
            return View();
        }

        //(string itemName, string itemBrand, string itemModel, string itemSize)
        [HttpGet]
        public JsonResult GetDeviceIdByParm()
        {
            //Guid itemCode = new Guid(itemName);
            //var itemCheckInDetailses= dc.CheckInDetails.Where(cd => cd.ItemCodeId == itemCode && cd.ItemBrand == itemBrand && cd.ItemModel == itemModel &&
            //                        cd.ItemSize == itemSize && cd.CurrentStatus == "Available").ToList();

            //dc.Configuration.LazyLoadingEnabled = false; // if your table is relational, contain foreign key
            //var data = dc.CheckInDetails.Select(x => new CheckInDetailsVM
            //{
            //    InvoiceNo = x.CheckIn.InvoiceNo,
            //    AuditCode=x.AuditCode,
            //    CpuCode = x.CpuCode,
            //    DeviceCode=x.DeviceCode,
            //    ItemCName = x.Item.Name,
            //    ItemBrand = x.ItemBrand,
            //    ItemModel = x.ItemModel,
            //    ItemSize = x.ItemSize,
            //    Unitprice = x.Unitprice,
            //    WarrantyExpireDate = x.WarrantyExpireDate,
            //    ProductSerialNo = x.ProductSerialNo,
            //    ItemStatus = x.ItemStatus,
            //    CurrentStatus = x.CurrentStatus,
            //    Remarks = x.Remarks
            //}).ToList();

            var data = dc.CheckInDetail.Include(i => i.Item).Include(c => c.CheckIn).ToList();

            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult SaveIssueDetails(Issue issue)
        {
            issue.QueryId = Guid.NewGuid();
            issue.PostedBy = User.Identity.GetUserName();
            issue.PostedIp = Request.UserHostAddress;
            issue.PostedDate = DateTime.Now;
            issue.UpdatedBy = "N/A";
            issue.UpdatedIp = "N/A";
            issue.UpdatedDate = DateTime.Now;
            bool status = false;
            var isValidModel = TryUpdateModel(issue);


            if (isValidModel)
            {
                using (dc)
                {
                    using (var transaction = dc.Database.BeginTransaction())
                    {
                        try
                        {
                            string issueIdMax = dc.Issue.Max(iSId => iSId.IssueId);
                            string issueIdNo;
                            if (issueIdMax == null)
                            {
                                issueIdNo = String.Format("IS-" + "{0:D8}", "00000000" + 1);
                            }
                            else
                            {
                                issueIdNo = String.Format("IS-" + "{0:D8}", Convert.ToInt32(issueIdMax.Substring(3)) + 1);
                            }

                            issue.IssueId = issueIdNo;

                            


                            foreach (IssueDetail aIssueDetails in issue.IssueDetails.ToList())
                            {
                                string issueDetailIdMax = dc.IssueDetail.Max(iSId => iSId.IssueDetailId);
                                string issueDetailIdNo = null;
                                if (issueDetailIdMax == null)
                                {
                                    //checkInDetailIdNo = String.Format("CD" + "{0:D7}", "000000" + +Convert.ToInt32(itemDetailse.CheckInDetailId));
                                    issueDetailIdNo = String.Format("ISD-" + "{0:D10}", "0000000000" + Convert.ToInt32(aIssueDetails.IssueDetailId));
                                }
                                else
                                {
                                    issueDetailIdNo = String.Format("ISD-" + "{0:D10}", Convert.ToInt32(issueDetailIdMax.Substring(4)) + +Convert.ToInt32(aIssueDetails.IssueDetailId));
                                }
                                aIssueDetails.IssueDetailId = issueDetailIdNo;
                                aIssueDetails.IssueId = issueIdNo;

                                IQueryable<CheckInDetail> checkInDetailses = dc.CheckInDetail.Where(chk => chk.CheckInDetailId == aIssueDetails.CheckInDetailId && chk.CurrentStatus == "Available");
                                foreach (CheckInDetail aCheckInDetails in checkInDetailses)
                                {

                                    aCheckInDetails.CurrentStatus = "UnAvailable";
                                    dc.Entry(aCheckInDetails).State = EntityState.Modified;

                                }
                                dc.SaveChanges();

                            }
                            dc.Issue.Add(issue);
                            dc.SaveChanges();

                            status = true;
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                        }
                    }

                }
            }



            return new JsonResult { Data = new { status = status } };
        }



        [HttpGet]
        public ActionResult GetIssueItemList()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetIssueItemListForDamage()
        {
            return View();
        }


        [HttpPost]
        public JsonResult ModifiedIssueDetails(string issueDetailId, string deviceReturnRemarks, string currentStatus)
        {
            bool status = false;
            //string alumniCardStatusSendNextStep = null;
            //var isValidModel = TryUpdateModel(issueDetail);
            //if (isValidModel)
            //{
            using (dc)
            {
                using (var transaction = dc.Database.BeginTransaction())
                {
                    IssueDetail aIssueDetailDB =
                        dc.IssueDetail.FirstOrDefault(issD => issD.IssueDetailId == issueDetailId);
                    aIssueDetailDB.DeviceReturnRemarks = deviceReturnRemarks;
                    aIssueDetailDB.CurrentStatus = currentStatus;
                    aIssueDetailDB.ReturnDate = DateTime.Now;
                    aIssueDetailDB.ReturnComment = User.Identity.GetUserName();

                    dc.Entry(aIssueDetailDB).State = EntityState.Modified;
                    //dc.SaveChanges();

                    CheckInDetail aCheckIndetailDB = dc.CheckInDetail.FirstOrDefault(chkD =>
                        chkD.CheckInDetailId == aIssueDetailDB.CheckInDetailId);
                    aCheckIndetailDB.CurrentStatus = "Available";
                    dc.Entry(aIssueDetailDB).State = EntityState.Modified;

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
            List<IssueDetailViewVM> cm = new List<IssueDetailViewVM>();
            using (dc)
            {
                cm = aIssueDetailRepo.GetAllIssueDetail();
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
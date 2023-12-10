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
    public class RequisitionDetailsMultipleController : Controller
    {
        private InventoryDbContext dc = new InventoryDbContext();
        private RequisitionDetailRepository aRequisitionDetailRepo = new RequisitionDetailRepository();
        private IssueItemStage aIssueItemStage = new IssueItemStage();
        // GET: RequisitionDetailsMultiple
        //public ActionResult CreateMultipleRequisitionDetail()
        //{
        //    return View();
        //}

        public ActionResult CreateRequisition()
        {
            return View();
        }

        //(string itemName, string itemBrand, string itemModel, string itemSize)
        [HttpGet]
        public JsonResult GetDeviceIdByParm()
        {
            var data = dc.CheckInDetail.Include(i => i.Item).Include(c => c.CheckIn).ToList();

            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult SaveRequisitionDetails(Requisition requisition)
        {
            requisition.QueryId = Guid.NewGuid();
            requisition.PostedBy = User.Identity.GetUserName();
            requisition.PostedIp = Request.UserHostAddress;
            requisition.PostedDate = DateTime.Now;
            requisition.UpdatedBy = "N/A";
            requisition.UpdatedIp = "N/A";
            requisition.UpdatedDate = DateTime.Now;
            bool status = false;
            var isValidModel = TryUpdateModel(requisition);


            if (isValidModel)
            {
                using (dc)
                {
                    using (var transaction = dc.Database.BeginTransaction())
                    {
                        try
                        {
                            string requisitionIdMax = dc.Requisition.Max(rQId => rQId.RequisitionId);
                            string requisitionIdNo;
                            if (requisitionIdMax == null)
                            {
                                requisitionIdNo = String.Format("RQ-" + "{0:D8}", "0000000" + 1);
                            }
                            else
                            {
                                requisitionIdNo = String.Format("RQ-" + "{0:D8}", Convert.ToInt32(requisitionIdMax.Substring(3)) + 1);
                            }

                            requisition.RequisitionId = requisitionIdNo;

                            


                            foreach (RequisitionDetail aRequisitionDetails in requisition.RequisitionDetails.ToList())
                            {
                                string requisitionDetailIdMax = dc.RequisitionDetail.Max(iSId => iSId.RequisitionDetailId);
                                string requisitionDetailIdNo = null;
                                if (requisitionDetailIdMax == null)
                                {
                                    //checkInDetailIdNo = String.Format("CD" + "{0:D7}", "000000" + +Convert.ToInt32(itemDetailse.CheckInDetailId));
                                    requisitionDetailIdNo = String.Format("RQD-" + "{0:D10}", "000000000" + Convert.ToInt32(aRequisitionDetails.RequisitionDetailId));
                                }
                                else
                                {
                                    requisitionDetailIdNo = String.Format("RQD-" + "{0:D10}", Convert.ToInt32(requisitionDetailIdMax.Substring(4)) + +Convert.ToInt32(aRequisitionDetails.RequisitionDetailId));
                                }
                                aRequisitionDetails.RequisitionDetailId = requisitionDetailIdNo;
                                aRequisitionDetails.RequisitionId = requisitionIdNo;

                                IQueryable<CheckInDetail> checkInDetailses = dc.CheckInDetail.Where(chk => chk.CheckInDetailId == aRequisitionDetails.CheckInDetailIdCode && chk.CurrentStatus == "Available");
                                foreach (CheckInDetail aCheckInDetails in checkInDetailses)
                                {

                                    aCheckInDetails.CurrentStatus = aIssueItemStage.Unavailable;
                                    dc.Entry(aCheckInDetails).State = EntityState.Modified;

                                }
                                dc.SaveChanges();

                            }
                            dc.Requisition.Add(requisition);
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
        public ActionResult GetListOfRequisitionItem()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetListOfApprovedItem()
        {
            return View();
        }

        public ActionResult RequisitionItemStatus()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ApprovedRequisitionDetails(string requisitionDetailId, string approvedRemarksData)
        {
            bool status = false;
            //string alumniCardStatusSendNextStep = null;
            //var isValidModel = TryUpdateModel(requisitionDetail);
            //if (isValidModel)
            //{
            using (dc)
            {
                using (var transaction = dc.Database.BeginTransaction())
                {
                    RequisitionDetail aRequisitionDetailDB =
                        dc.RequisitionDetail.FirstOrDefault(issD => issD.RequisitionDetailId == requisitionDetailId);
                    aRequisitionDetailDB.IsApproved = true;
                    aRequisitionDetailDB.ApproveRemarks = approvedRemarksData;
                    aRequisitionDetailDB.ApprovedDateTime = DateTime.Now;
                    aRequisitionDetailDB.ApprovedBy = User.Identity.GetUserName();
                    string hostName = Dns.GetHostName();
                    aRequisitionDetailDB.ApprovedIP = Request.UserHostAddress+"-"+ hostName;
                    dc.Entry(aRequisitionDetailDB).State = EntityState.Modified;
                    //dc.SaveChanges();

                    
                    dc.SaveChanges();
                    status = true;
                    transaction.Commit();
                }

               

            }
            //}
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeniedRequisitionDetails(string requisitionDetailId, string deniedRemarksData)
        {
            bool status = false;
            
            using (dc)
            {
                using (var transaction = dc.Database.BeginTransaction())
                {
                    RequisitionDetail aRequisitionDetailDB =
                        dc.RequisitionDetail.FirstOrDefault(issD => issD.RequisitionDetailId == requisitionDetailId);
                    aRequisitionDetailDB.IsDenied = true;
                    aRequisitionDetailDB.ApproveRemarks = deniedRemarksData;
                    aRequisitionDetailDB.DeniedDateTime = DateTime.Now;
                    aRequisitionDetailDB.DeniedBy = User.Identity.GetUserName();
                    aRequisitionDetailDB.DeniedIP = Request.UserHostAddress;
                    dc.Entry(aRequisitionDetailDB).State = EntityState.Modified;
                    dc.SaveChanges();

                    status = true;
                    transaction.Commit();
                }



            }
            
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult IssuedRequisitionDetails(string requisitionDetailId)
        {
            bool status = false;

            using (dc)
            {
                using (var transaction = dc.Database.BeginTransaction())
                {
                    RequisitionDetail aRequisitionDetailDB = dc.RequisitionDetail.FirstOrDefault(issD => issD.RequisitionDetailId == requisitionDetailId);
                    aRequisitionDetailDB.IsIssued = true;
                    aRequisitionDetailDB.IssuedDateTime = DateTime.Now;
                    aRequisitionDetailDB.IssuedBy = User.Identity.GetUserName();
                    aRequisitionDetailDB.IssuedIP = Request.UserHostAddress;
                    dc.Entry(aRequisitionDetailDB).State = EntityState.Modified;


                    IssueApproved aIssueApproved = new IssueApproved();

                    string issueApproveIdMax = dc.IssueApproveds.Max(iSId => iSId.IssueApprovedId);
                    string issueApprovedIdNo;
                    if (issueApproveIdMax == null)
                    {
                        //checkInDetailIdNo = String.Format("CD" + "{0:D7}", "000000" + +Convert.ToInt32(itemDetailse.CheckInDetailId));
                        issueApprovedIdNo = String.Format("ISD-" + "{0:D10}", "000000000" + 1);
                    }
                    else
                    {
                        issueApprovedIdNo = String.Format("ISD-" + "{0:D10}", Convert.ToInt32(issueApproveIdMax.Substring(4)) + 1);
                    }

                    
                    aIssueApproved.IssueApprovedId = issueApprovedIdNo;
                    aIssueApproved.QueryId = Guid.NewGuid();
                    aIssueApproved.RequisitionDId = aRequisitionDetailDB.RequisitionDetailId;
                    aIssueApproved.CurrentStatus = aIssueItemStage.Issued;
                    aIssueApproved.ReturnRemarks = "N/A";
                    aIssueApproved.ReturnDate = DateTime.Now;
                    aIssueApproved.ReturnBy = User.Identity.GetUserName();
                    aIssueApproved.ReturnIp = Request.UserHostAddress;
                    aIssueApproved.GarbageDescription = "N/A";
                    aIssueApproved.GarbageDate = DateTime.Now;
                    aIssueApproved.GarbageBy = User.Identity.GetUserName();
                    aIssueApproved.GarbageIp = Request.UserHostAddress;
                    aIssueApproved.WarrantyReason = "N/A";
                    aIssueApproved.WarrantyDate = DateTime.Now;
                    aIssueApproved.WarrantyBy = User.Identity.GetUserName();
                    aIssueApproved.WarrantyIp = Request.UserHostAddress;
                    aIssueApproved.PostedBy = User.Identity.GetUserName();
                    aIssueApproved.PostedIp = Request.UserHostAddress;
                    aIssueApproved.PostedDate = DateTime.Now;
                    aIssueApproved.UpdatedBy = "N/A";
                    aIssueApproved.UpdatedIp = "N/A";
                    aIssueApproved.UpdatedDate = DateTime.Now;

                    dc.IssueApproveds.Add(aIssueApproved);



                    dc.SaveChanges();

                    status = true;
                    transaction.Commit();
                }



            }

            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult ReturnIssueDetails(string issueDetailId, string deviceReturnRemarks, string currentStatus)
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
                    aCheckIndetailDB.CurrentStatus = aIssueItemStage.Available;
                    dc.Entry(aIssueDetailDB).State = EntityState.Modified;

                    dc.SaveChanges();
                    status = true;
                    transaction.Commit();
                }



            }
            //}
            return new JsonResult { Data = new { status = status } };
        }




        public ActionResult RequisitionDetailsViewReport()
        {
            return View();

        }

        public ActionResult RequisitionDetailReport(string id)
        {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "rptRequisitionDetail.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return View("RequisitionDetailReport");
            }
            List<RequisitionDetailViewVM> cm = new List<RequisitionDetailViewVM>();
            using (dc)
            {
                cm = aRequisitionDetailRepo.GetAllRequisitionDetail();
            }
            ReportDataSource rd = new ReportDataSource("RequisitionDetailDS", cm);
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
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
//using Microsoft.Reporting.WebForms;
using QRCoder;
using ULABInventory.Model;
using ULABInventory.Repository;
using ULABInventory.ViewModels;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing.Text;
using CrystalDecisions.CrystalReports.Engine;
using Microsoft.Reporting.WebForms;

//using Microsoft.Reporting.WinForms;

namespace UlabInventory.Web.MVC.Main.Controllers
{
    [Authorize]
    public class CheckInDetailsMultipleController : Controller
    {
        // GET: CheckInDetailsMultiple
        public ActionResult CreateCheckInDetailsMultiple()
        {
            return View();
        }

        private InventoryDbContext dc = new InventoryDbContext();
        private CheckInDetailRepository aCheckInDetailRepo = new CheckInDetailRepository();
        [HttpGet]
        public JsonResult GetSupplier(string categoryId)
        {
            List<Supplier> suppliers = new List<Supplier>();
            using (dc)
            {
                suppliers = dc.Supplier.Where(s => s.CategoryId == categoryId).OrderBy(a => a.Name).ToList();
            }
            return new JsonResult { Data = suppliers, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        //Get: CPU
        public JsonResult GetCpu()
        {
            List<CheckInDetail> checkInDetailses = new List<CheckInDetail>();
            using (dc)
            {
                checkInDetailses = dc.CheckInDetail.DistinctBy(cid => cid.CpuId).OrderBy(cid => cid.CpuId).ToList();
            }
            return new JsonResult { Data = checkInDetailses, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetDevice(string CpuId)
        {
            List<CheckInDetail> checkInDetailses = new List<CheckInDetail>();
            using (dc)
            {
                checkInDetailses =
                    dc.CheckInDetail.Where(cid => cid.CpuId == CpuId).OrderBy(cid => cid.DeviceId).ToList();
            }
            return new JsonResult { Data = checkInDetailses, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult AuditCodeAvailability(string userdata)
        {
            System.Threading.Thread.Sleep(200);
            var SeachData = dc.CheckInDetail.Where(x => x.AuditCode == userdata).SingleOrDefault();
            if (SeachData != null)
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }

        }
        //private Random getrandom = new Random();
        [HttpPost]
        //[ValidateAntiForgeryToken]
        //[ActionName("CreateCheckInDetailsMultiple")]
        //SaveCheckInDetails
        public JsonResult SaveCheckInDetails(CheckIn order)
        {
            bool status = false;
            try
            {
                
                string checkInIdMax = dc.CheckIn.Max(cinId => cinId.CheckInId);
                string checkInIdNo;
                //if (checkInIdMax == null)
                //{
                //    checkInIdNo = String.Format("C0000001");
                //}
                //else
                //{
                //    checkInIdNo = String.Format("C" + "{0:D7}", Convert.ToInt32(checkInIdMax.Substring(1)) + 1);
                //}

                if (checkInIdMax == null)
                {
                    checkInIdNo = String.Format("C" + "{0:D7}", "000000" + +Convert.ToInt32(order.CheckInId));
                }
                else
                {
                    checkInIdNo = String.Format("C" + "{0:D7}", Convert.ToInt32(checkInIdMax.Substring(1)) + +Convert.ToInt32(order.CheckInId));
                }

               


                Supplier supplierInfo = dc.Supplier.FirstOrDefault(s => s.SupplierId == order.SupplierId);

                

                ICollection<CheckInDetail> checkDetailsList = order.CheckInDetail;

                var isValidModel = TryUpdateModel(order);
                order.CheckInId = checkInIdNo;
                string cpuInput = order.Comment;
                order.QueryId = Guid.NewGuid();
                order.PostedBy = User.Identity.GetUserName();
                order.PostedIp = Request.UserHostAddress;
                order.PostedDate = DateTime.Now;
                order.UpdatedBy = "N/A";
                order.UpdatedIp = "N/A";
                order.UpdatedDate = DateTime.Now;
                //dc.CheckIn.Add(order);
                //dc.SaveChanges();

                if (isValidModel)
                {
                    using (dc)
                    {
                        var checkInInvoice = dc.CheckIn.SingleOrDefault(i => i.InvoiceNo == order.InvoiceNo);
                        string cpuCodeNo = order.Comment;


                        if (checkInInvoice != null)
                        {

                            foreach (var aCheckInD in checkDetailsList)
                            {
                                //aCheckIn.CheckInId = order.CheckInId;
                                aCheckInD.CheckInId = checkInInvoice.CheckInId;
                                aCheckInD.WarrantyExpireDate =
                                    checkInInvoice.PurchaseDate.AddMonths(aCheckInD.WarrentyDuration);
                                GetItemDetailsPostedByValue(aCheckInD, cpuCodeNo, cpuInput, supplierInfo);
                                dc.CheckInDetail.Add(aCheckInD);
                            }
                        }
                        else
                        {
                            foreach (var aCheckInDetail in checkDetailsList)
                            {
                                aCheckInDetail.CheckInId = order.CheckInId;
                                aCheckInDetail.WarrantyExpireDate =
                                    order.PurchaseDate.AddMonths(aCheckInDetail.WarrentyDuration);
                                GetItemDetailsPostedByValue(aCheckInDetail, cpuCodeNo, cpuInput, supplierInfo);
                            }

                            dc.CheckIn.Add(order);
                        }

                        dc.SaveChanges();
                        status = true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            return new JsonResult { Data = new { status = status } };
        }

        private void GetItemDetailsPostedByValue(CheckInDetail aCheckInDetail, string cpuCodeNo, string cpuInput,Supplier supplier)
        {
            string checkInDetailIdMax = dc.CheckInDetail.Max(iDId => iDId.CheckInDetailId);
            string checkInDetailIdNo=null;
            if (checkInDetailIdMax == null)
            {
                checkInDetailIdNo = String.Format("CD" + "{0:D7}", "000000" + +Convert.ToInt32(aCheckInDetail.CheckInDetailId));
            }
            else
            {
                checkInDetailIdNo = String.Format("CD" + "{0:D7}", Convert.ToInt32(checkInDetailIdMax.Substring(2)) + +Convert.ToInt32(aCheckInDetail.CheckInDetailId));
            }

            aCheckInDetail.CheckInDetailId = checkInDetailIdNo;

            string auditMax = dc.CheckInDetail.Where(cD => cD.AuditCode.Contains("AUD")).Max(iDId => iDId.AuditCode);
            string auditNo = null;
            if (auditMax == null)
            {
                auditNo = String.Format("AUD" + "{0:D7}", "000000" + +Convert.ToInt32(aCheckInDetail.AuditCode));
            }
            else
            {
                auditNo = String.Format("AUD" + "{0:D7}", Convert.ToInt32(auditMax.Substring(3))+ +Convert.ToInt32(aCheckInDetail.AuditCode));
            }

            aCheckInDetail.AuditCode = auditNo;

            //Modified CPU Identity on 16-01-2022 After discussed with Arif vai. (No need to mark CPU's inside item) 

            string scpuIdNo = null;
            string dt = DateTime.Now.ToString("yyMM");
            if (cpuInput == "yes")
            {
                //Single or Combined Process Unit(SPU/CPU)
                //ICollection<CheckInDetail> cpuIdList = dc.CheckInDetail.Where(cD=>cD.CpuId.Contains("CPU")).ToList();

                //string cpuMaxNo = cpuIdList.Max(cpu => cpu.CpuId);

                string cpuMaxNo = dc.CheckInDetail.Where(cD => cD.CpuId.Contains("CPU")).Max(cpu => cpu.CpuId);

                if (cpuMaxNo == null)
                {
                    scpuIdNo = String.Format("CPU" + dt + "{0:D6}", "00000" + Convert.ToInt32(aCheckInDetail.CpuId));
                }
                else
                {
                    scpuIdNo = String.Format("CPU" + dt + "{0:D6}", Convert.ToInt32(cpuMaxNo.Substring(7)) + 1);
                }
            }
            else
            {
                string cpuMaxNo = dc.CheckInDetail.Where(cD=>cD.CpuId.Contains("SPU")).Max(cpu => cpu.CpuId);

                
                if (cpuMaxNo == null)
                {
                    scpuIdNo = String.Format("SPU" + dt + "{0:D6}", "00000" +Convert.ToInt32(aCheckInDetail.CpuId));
                }
                else
                {
                    //string lastNo = "UIT1709000001";
                    //string tst = lastNo.Substring(7);
                    //int no = Convert.ToInt32(tst) + 1;
                    //string test = "UIT" + dt + no.ToString("000000");

                    //cpuIdNo = String.Format("UIT" + dt + "{0:D6}", Convert.ToInt32(cpuMaxNo.Substring(7)) +1);
                    scpuIdNo = String.Format("SPU" + dt + "{0:D6}", Convert.ToInt32(cpuMaxNo.Substring(7)) +Convert.ToInt32(aCheckInDetail.CpuId));
                }


            }
            aCheckInDetail.CpuId = scpuIdNo;
            string deviceIdNo = null;
            string devMaxNo = dc.CheckInDetail.Max(dev => dev.DeviceId);
            if (devMaxNo == null)
            {
                deviceIdNo = String.Format("UIT"+dt+"{0:D6}", "00000" + Convert.ToInt32(aCheckInDetail.DeviceId));
            }
            else
            {
                deviceIdNo = String.Format("UIT" + dt + "{0:D6}", Convert.ToInt32(devMaxNo.Substring(7)) + Convert.ToInt32(aCheckInDetail.DeviceId)); ;
            }

            aCheckInDetail.DeviceId = deviceIdNo;
            aCheckInDetail.QueryId = Guid.NewGuid();


            aCheckInDetail.PostedBy = User.Identity.GetUserName();
            aCheckInDetail.PostedIp = Request.UserHostAddress;
            aCheckInDetail.PostedDate = DateTime.Now;
            aCheckInDetail.UpdatedBy = "N/A";
            aCheckInDetail.UpdatedIp = "N/A";
            aCheckInDetail.UpdatedDate = DateTime.Now;



            string chekDId = aCheckInDetail.CheckInDetailId;
            string cpuId = aCheckInDetail.CpuId;
            string deviceId = deviceIdNo;
            string itemDId = aCheckInDetail.ItemDetailsId;
            string supplierInfo = supplier.Name;

            string qrCodeText = chekDId + "\n" + cpuId + "\n" + deviceId + "\n" + itemDId + "\n" + supplierInfo;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrCodeText, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            //Start QR Generation and Save in DB and Folder

            System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            imgBarCode.Height = 200;
            imgBarCode.Width = 200;
            string qrimageSaveFilePath;
            byte[] imageData = null;
            using (Bitmap bitqrMap = qrCode.GetGraphic(5, Color.Black, Color.White, null, 15, 1, false))
            {
                string chlIdDImage = aCheckInDetail.CheckInDetailId + ".png";
                qrimageSaveFilePath = Server.MapPath("~/Image/CheckInDetails/" + chlIdDImage);
                if (System.IO.File.Exists(qrimageSaveFilePath))
                {
                    System.IO.File.Delete(qrimageSaveFilePath);
                }

                bitqrMap.Save(qrimageSaveFilePath); //save the image file
                MemoryStream ms = new MemoryStream();
                bitqrMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                imageData = ms.ToArray();

            }

            aCheckInDetail.QRImage = imageData;

            aCheckInDetail.QRCodeImgPath = qrimageSaveFilePath;

            //End QR Generation and Save in DB and Folder
        }

        public ActionResult CheckInDetailReport(string id)
        {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "rptCheckInDetail.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return View("CheckInDetailReport");
            }
            List<CheckInDetailViewVM> cm = new List<CheckInDetailViewVM>();
            using (dc)
            {
                cm = aCheckInDetailRepo.GetAllCheckInDetail();
            }
            ReportDataSource rd = new ReportDataSource("CheckInDetailDS", cm);
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
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = lr.Render(
                reportType, deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
            return File(renderedBytes, mimeType);

        }

        public ActionResult QRImgChkInDetailReport(string id)
        {
            LocalReport lr = new LocalReport();
            //this.reportViewer1.LocalReport.ReportPath = "Report1.rdlc";
            string path = Path.Combine(Server.MapPath("~/Reports"), "rptQRImageCheckInD.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return View("CheckInDetailReport");
            }
            List<CheckInDetailViewVM> cm = new List<CheckInDetailViewVM>();
            cm = aCheckInDetailRepo.GetAllCheckInDetail();
            ReportDataSource rd = new ReportDataSource("rptQRImageCheckInD", cm);
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
                "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            try
            {
                renderedBytes = lr.Render(
                    reportType, deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
                return File(renderedBytes, mimeType);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            

        }



        public ActionResult QRImgCheckInDetailReport(string id)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CheckInDetailsQRRpt.rpt"));
            List<CheckInDetailViewVM> cm = new List<CheckInDetailViewVM>();
            cm = aCheckInDetailRepo.GetAllCheckInDetail();
            rd.SetDataSource(cm);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "QRImgCheckInDetails.pdf");
            }
            catch
            {
                throw;
            }

        }

        public ActionResult QRImgReportView()
        {
            return View();
        }

        public ActionResult CheckInDetailsReport()
        {
            return View();
        }
        public ActionResult QRImgCrystalReportView()
        {
            return View();
        }


    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    public class ItemDetailsMultipleController : Controller
    {
        private InventoryDbContext dc = new InventoryDbContext();
        private ItemDetailRepository aItemDetailRepo = new ItemDetailRepository();
        // GET: ItemDetailsMultiple
        public ActionResult CreateMultipleItemDetail()
        {
            return View();
        }

        public ActionResult CreateMultipleItem()
        {
            return View();
        }

        
        [HttpGet]
        public JsonResult GetItemCategories()
        {
            List<Category> categories = new List<Category>();
            using (dc)
            {
                categories = dc.Category.OrderBy(a => a.Name).ToList();
            }
            return new JsonResult { Data = categories, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpGet]
        public JsonResult GetItemSubCategories(string categoryId)
        {
            List<SubCategory> subCategories = new List<SubCategory>();
            using (dc)
            {
                subCategories = dc.SubCategory.Where(sc=>sc.CategoryId==categoryId).OrderBy(a => a.Name).ToList();
            }
            return new JsonResult { Data = subCategories, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public JsonResult save(Item order)
        {
            bool status = false;
            var isValidModel = TryUpdateModel(order);
            order.QueryId = Guid.NewGuid();
            order.PostedBy = User.Identity.GetUserName();
            order.PostedIp = Request.UserHostAddress;
            order.PostedDate = DateTime.Now;
            order.UpdatedBy = "N/A";
            order.UpdatedIp = "N/A";
            order.UpdatedDate = DateTime.Now;
            if (isValidModel)
            {
                using (dc)
                {
                    var itemNameExist = dc.Item.SingleOrDefault(i=>i.Name==order.Name);
                    if (itemNameExist!=null)
                    {
                        foreach (var itemDetailse in order.ItemDetail)
                        {
                            itemDetailse.ItemId = itemNameExist.ItemId;
                            GetItemDetailsPostedByValue(itemDetailse);
                            dc.ItemDetail.Add(itemDetailse);
                        }
                    }
                    else
                    {
                        foreach (var itemDetailse in order.ItemDetail)
                        {
                            GetItemDetailsPostedByValue(itemDetailse);
                        }
                        dc.Item.Add(order);
                    }
                    
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpGet]
        public JsonResult GetSubCategories()
        {
            List<SubCategory> subcategories = new List<SubCategory>();
            using (dc)
            {
                subcategories = dc.SubCategory.OrderBy(a => a.Name).ToList();
            }
            return new JsonResult { Data = subcategories, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpGet]
        public JsonResult GetItem(string subCategoryId)
        {
            List<Item> items = new List<Item>();
            using (dc)
            {
                items = dc.Item.Where(sc => sc.SubCategoryId == subCategoryId).OrderBy(a => a.Name).ToList();
            }
            return new JsonResult { Data = items, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public JsonResult SaveMItem(Item order)
        {
            bool status = false;
            var isValidModel = TryUpdateModel(order);
            try
            {
                if (isValidModel)
                {
                    using (dc)
                    {

                        foreach (var itemDetail in order.ItemDetail)
                        {
                            string itemDetailIdMax = dc.ItemDetail.Max(iDId => iDId.ItemDetailId);
                            string itemDetailIdNo;
                            if (itemDetailIdMax == null)
                            {
                                itemDetailIdNo = String.Format("ITMD-0000001");
                            }
                            else
                            {
                                itemDetailIdNo = String.Format("ITMD-" + "{0:D7}", Convert.ToInt32(itemDetailIdMax.Substring(5)) + 1);
                            }

                            itemDetail.ItemId = order.ItemId;
                            itemDetail.ItemDetailId = itemDetailIdNo;
                            GetItemDetailsPostedByValue(itemDetail);
                            dc.ItemDetail.Add(itemDetail);
                            dc.SaveChanges();
                        }


                        status = true;
                    }
                }
                return new JsonResult { Data = new { status = status } };
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                Console.WriteLine(e);
                throw;
            }
            
        }
        


        private void GetItemDetailsPostedByValue(ItemDetail itemDetails)
        {
            itemDetails.QueryId = Guid.NewGuid();
            itemDetails.PostedBy = User.Identity.GetUserName();
            itemDetails.PostedIp = Request.UserHostAddress;
            itemDetails.PostedDate = DateTime.Now;
            itemDetails.UpdatedBy = "N/A";
            itemDetails.UpdatedIp = "N/A";
            itemDetails.UpdatedDate = DateTime.Now;
        }


        public ActionResult ItemDetailReport(string id)
        {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "rptItemDetail.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return View("ItemDetailReport");
            }
            List<ItemDetailVM> cm = new List<ItemDetailVM>();
            using (dc)
            {
                cm = aItemDetailRepo.GetAllItemDetail();
            }
            ReportDataSource rd = new ReportDataSource("ItemDetailDS", cm);
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
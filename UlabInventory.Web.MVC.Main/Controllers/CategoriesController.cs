using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using Microsoft.AspNet.Identity;
using ULABInventory.Model;
using ULABInventory.Service;
using ULABInventory.ViewModels;

namespace UlabInventory.Web.MVC.Main.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private InventoryDbContext db = new InventoryDbContext();
        CategoryService aCategoryService=new CategoryService();
        // GET: Categories
        public ActionResult Index()
        {
            List<CategoryVM> categoryVms=aCategoryService.GetList();
            return View(categoryVms);
        }

        public ActionResult ExportCategory()
        {
            ReportDocument categoryReportDocument = new ReportDocument();
            categoryReportDocument.Load(Path.Combine(Server.MapPath("~/Report"), "Category.rpt"));
            categoryReportDocument.SetDataSource(db.Category.Select(cat => new
            {
                //Id = cat.Id,
                Code = cat.QueryId,
                Name = cat.Name,
                Priority = cat.Priority,
            }).ToList());
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream =
                categoryReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "CategoryList.pdf");

        }


        // GET: Categories/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Category.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            //if (ModelState.IsValid)
            //{
            category.QueryId = Guid.NewGuid();
            category.PostedBy = User.Identity.GetUserName();
            category.PostedIp = Request.UserHostAddress;
            category.PostedDate = DateTime.Now;
            category.UpdatedBy = User.Identity.GetUserName();
            category.UpdatedIp = Request.UserHostAddress;
            category.UpdatedDate = DateTime.Now;
            bool saved = aCategoryService.Save(category);
            if (saved)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
            
            //}

            //return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Category.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,Name,Priority,Description,QueryId,PostedBy,PostedIp,PostedDate,UpdatedBy,UpdatedIp,UpdatedDate")] Category category)
        {
            if (ModelState.IsValid)
            {
                category.UpdatedBy = User.Identity.GetUserName();
                category.UpdatedIp = Request.UserHostAddress;
                category.UpdatedDate = DateTime.Now;
                bool edited = aCategoryService.Update(category);
                
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Category.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Category category = db.Category.Find(id);
            db.Category.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

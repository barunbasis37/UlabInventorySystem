using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ULABInventory.Model;
using ULABInventory.Service;

namespace UlabInventory.Web.MVC.Main.Controllers
{
    [Authorize]
    public class SubCategoriesController : Controller
    {
        private InventoryDbContext db = new InventoryDbContext();
        SubCategoryService aSubCategoryService = new SubCategoryService();

        // GET: SubCategories
        public ActionResult Index()
        {
            var subCategory = db.SubCategory.Include(s => s.Category);
            return View(subCategory.ToList());
        }

        // GET: SubCategories/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subCategory = db.SubCategory.Include(scId=>scId.Category).FirstOrDefault(scId=>scId.QueryId==id);
            if (subCategory == null)
            {
                return HttpNotFound();
            }
            return View(subCategory);
        }

        // GET: SubCategories/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "Name");
            return View();
        }

        // POST: SubCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubCategory subCategory)
        {
            try
            {
                subCategory.QueryId = Guid.NewGuid();
                subCategory.PostedBy = User.Identity.GetUserName();
                subCategory.PostedIp = "1";
                subCategory.PostedDate = DateTime.Now;
                subCategory.UpdatedBy = User.Identity.GetUserName();
                subCategory.UpdatedIp = "1";
                subCategory.UpdatedDate = DateTime.Now;
                bool saved = aSubCategoryService.Save(subCategory);
                if (saved)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "Name", subCategory.CategoryId);
                    return View(subCategory);
                }
            }
            catch (Exception e)
            {
                
                Console.WriteLine(e);
                throw;
            }
            


            //ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "Name", subCategory.CategoryId);
            //return View(subCategory);
        }

        // GET: SubCategories/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subCategory = db.SubCategory.FirstOrDefault(scId=>scId.QueryId==id);
            if (subCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "Name", subCategory.CategoryId);
            return View(subCategory);
        }

        // POST: SubCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubCategory subCategory)
        {
            subCategory.QueryId = Guid.NewGuid();
            subCategory.PostedBy = User.Identity.GetUserName();
            subCategory.PostedIp = Request.UserHostAddress;
            subCategory.PostedDate = DateTime.Now;
            subCategory.UpdatedBy = User.Identity.GetUserName();
            subCategory.UpdatedIp = Request.UserHostAddress;
            subCategory.UpdatedDate = DateTime.Now;
            db.Entry(subCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            
        }

        // GET: SubCategories/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subCategory = db.SubCategory.Include(sc=>sc.Category).FirstOrDefault(scId => scId.QueryId == id);
            if (subCategory == null)
            {
                return HttpNotFound();
            }
            return View(subCategory);
        }

        // POST: SubCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            SubCategory subCategory = db.SubCategory.FirstOrDefault(scId => scId.QueryId == id);
            db.SubCategory.Remove(subCategory);
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

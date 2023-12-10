using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ULABInventory.Models;

namespace ULABInventory.App.MVC.Controllers
{
    public class ItemsController : Controller
    {
        private InventoryDbContext db = new InventoryDbContext();

        // GET: Items
        public ActionResult Index()
        {
            var item = db.Item.Include(i => i.Category).Include(i => i.SubCategory);
            return View(item.ToList());
        }

        // GET: Items/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Item.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Category, "Id", "Name");
            ViewBag.SubCategoryId = new SelectList(db.SubCategory, "Id", "Name");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Priority,CategoryId,SubCategoryId,Code,PostedBy,PostedIp,UpdatedBy,UpdatedIp")] Item item)
        {
            //if (ModelState.IsValid)
            //{
            item.QueryId = Guid.NewGuid();
            item.PostedBy = User.Identity.GetUserName();
            item.PostedIp = Request.UserHostAddress;
            item.PostedDate = DateTime.Now;
            item.UpdatedBy = User.Identity.GetUserName();
            item.UpdatedIp = Request.UserHostAddress;
            item.UpdatedDate = DateTime.Now;
            db.Item.Add(item);
            db.SaveChanges();
            return RedirectToAction("Index");
            //}

            //ViewBag.CategoryId = new SelectList(db.Category, "Id", "Name", item.CategoryId);
            //ViewBag.SubCategoryId = new SelectList(db.SubCategory, "Id", "Name", item.SubCategoryId);
            //return View(item);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Item.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Category, "Id", "Name", item.CategoryId);
            ViewBag.SubCategoryId = new SelectList(db.SubCategory, "Id", "Name", item.SubCategoryId);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Priority,CategoryId,SubCategoryId,Code,PostedBy,PostedIp,PostedDate,UpdatedBy,UpdatedIp,UpdatedDate")] Item item)
        {
            if (ModelState.IsValid)
            {
                item.UpdatedBy = User.Identity.GetUserName();
                item.UpdatedIp = Request.UserHostAddress;
                item.UpdatedDate = DateTime.Now;
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Category, "Id", "Name", item.CategoryId);
            ViewBag.SubCategoryId = new SelectList(db.SubCategory, "Id", "Name", item.SubCategoryId);
            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Item.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Item item = db.Item.Find(id);
            db.Item.Remove(item);
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

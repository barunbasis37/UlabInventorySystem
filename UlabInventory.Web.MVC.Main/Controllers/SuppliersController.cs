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
    public class SuppliersController : Controller
    {
        private InventoryDbContext db = new InventoryDbContext();
        SupplierService aSupplierService = new SupplierService();
        // GET: Suppliers
        public ActionResult Index()
        {
            var supplier = db.Supplier.Include(s => s.Category);
            return View(supplier.ToList());
        }

        // GET: Suppliers/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Supplier.Include(sp=>sp.Category).FirstOrDefault(sQId => sQId.QueryId == id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // GET: Suppliers/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "Name");
            return View();
        }

        // POST: Suppliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supplier supplier)
        {
            try
            {

                supplier.QueryId = Guid.NewGuid();
                supplier.PostedBy = User.Identity.GetUserName();
                supplier.PostedIp = Request.UserHostAddress;
                supplier.PostedDate = DateTime.Now;
                supplier.UpdatedBy = User.Identity.GetUserName();
                supplier.UpdatedIp = Request.UserHostAddress;
                supplier.UpdatedDate = DateTime.Now;
                bool saved = aSupplierService.Save(supplier);
                if (saved)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(supplier);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            
        }

        // GET: Suppliers/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Supplier.FirstOrDefault(sQId=>sQId.QueryId==id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "Name", supplier.CategoryId);
            return View(supplier);
        }

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,Description,Priority,CategoryId,Code,PostedBy,PostedIp,PostedDate,UpdatedBy,UpdatedIp,UpdatedDate")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "Name", supplier.CategoryId);
            return View(supplier);
        }

        // GET: Suppliers/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Supplier.FirstOrDefault(sQId => sQId.QueryId == id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Supplier supplier = db.Supplier.FirstOrDefault(sQId => sQId.QueryId == id);
            db.Supplier.Remove(supplier);
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

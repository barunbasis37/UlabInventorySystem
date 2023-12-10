using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ULABInventory.Models;

namespace ULABInventory.App.MVC.Controllers
{
    public class PurchaseBiesController : Controller
    {
        private InventoryDbContext db = new InventoryDbContext();

        // GET: PurchaseBies
        public ActionResult Index()
        {
            return View(db.PurchaseBy.ToList());
        }

        // GET: PurchaseBies/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseBy purchaseBy = db.PurchaseBy.Find(id);
            if (purchaseBy == null)
            {
                return HttpNotFound();
            }
            return View(purchaseBy);
        }

        // GET: PurchaseBies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PurchaseBies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Priority,Code,PostedBy,PostedIp,PostedDate,UpdatedBy,UpdatedIp,UpdatedDate")] PurchaseBy purchaseBy)
        {
            if (ModelState.IsValid)
            {
                purchaseBy.QueryId = Guid.NewGuid();
                db.PurchaseBy.Add(purchaseBy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(purchaseBy);
        }

        // GET: PurchaseBies/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseBy purchaseBy = db.PurchaseBy.Find(id);
            if (purchaseBy == null)
            {
                return HttpNotFound();
            }
            return View(purchaseBy);
        }

        // POST: PurchaseBies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Priority,Code,PostedBy,PostedIp,PostedDate,UpdatedBy,UpdatedIp,UpdatedDate")] PurchaseBy purchaseBy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseBy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(purchaseBy);
        }

        // GET: PurchaseBies/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseBy purchaseBy = db.PurchaseBy.Find(id);
            if (purchaseBy == null)
            {
                return HttpNotFound();
            }
            return View(purchaseBy);
        }

        // POST: PurchaseBies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            PurchaseBy purchaseBy = db.PurchaseBy.Find(id);
            db.PurchaseBy.Remove(purchaseBy);
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

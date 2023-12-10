using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ULABInventory.Models;

namespace ULABInventory.Web.MVC.Controllers
{
    public class ItemDetailsController : Controller
    {
        private InventoryDbContext db = new InventoryDbContext();

        // GET: ItemDetails
        public ActionResult Index()
        {
            var itemDetail = db.ItemDetail.Include(i => i.Item);
            return View(itemDetail.ToList());
        }

        // GET: ItemDetails/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemDetails itemDetails = db.ItemDetail.Find(id);
            if (itemDetails == null)
            {
                return HttpNotFound();
            }
            return View(itemDetails);
        }

        // GET: ItemDetails/Create
        public ActionResult Create()
        {
            ViewBag.ItemId = new SelectList(db.Item, "Id", "Name");
            return View();
        }

        // POST: ItemDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ItemId,Model,Size,Brand,Price,Details,Code,PostedBy,PostedIp,PostedDate,UpdatedBy,UpdatedIp,UpdatedDate")] ItemDetails itemDetails)
        {
            if (ModelState.IsValid)
            {
                itemDetails.QueryId = Guid.NewGuid();
                db.ItemDetail.Add(itemDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemId = new SelectList(db.Item, "Id", "Name", itemDetails.ItemId);
            return View(itemDetails);
        }

        // GET: ItemDetails/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemDetails itemDetails = db.ItemDetail.Find(id);
            if (itemDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemId = new SelectList(db.Item, "Id", "Name", itemDetails.ItemId);
            return View(itemDetails);
        }

        // POST: ItemDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ItemId,Model,Size,Brand,Price,Details,Code,PostedBy,PostedIp,PostedDate,UpdatedBy,UpdatedIp,UpdatedDate")] ItemDetails itemDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(db.Item, "Id", "Name", itemDetails.ItemId);
            return View(itemDetails);
        }

        // GET: ItemDetails/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemDetails itemDetails = db.ItemDetail.Find(id);
            if (itemDetails == null)
            {
                return HttpNotFound();
            }
            return View(itemDetails);
        }

        // POST: ItemDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ItemDetails itemDetails = db.ItemDetail.Find(id);
            db.ItemDetail.Remove(itemDetails);
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

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
    public class CheckInDetailsController : Controller
    {
        private InventoryDbContext db = new InventoryDbContext();

        // GET: CheckInDetails
        public ActionResult Index()
        {
            var checkInDetails = db.CheckInDetails.Include(c => c.CheckIn).Include(c => c.Item);
            return View(checkInDetails.ToList());
        }

        // GET: CheckInDetails/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckInDetails checkInDetails = db.CheckInDetails.Find(id);
            if (checkInDetails == null)
            {
                return HttpNotFound();
            }
            return View(checkInDetails);
        }

        // GET: CheckInDetails/Create
        public ActionResult Create()
        {
            ViewBag.CheckInId = new SelectList(db.CheckIn, "Id", "InvoiceNo");
            ViewBag.ItemCodeId = new SelectList(db.Item, "Id", "Name");
            return View();
        }

        // POST: CheckInDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CheckInId,CpuCode,DeviceCode,ItemCodeId,ItemModel,ItemSize,ItemBrand,Unitprice,WarrantyExpireDate,ProductSerialNo,ItemStatus,CurrentStatus,Remarks,Code,PostedBy,PostedIp,PostedDate,UpdatedBy,UpdatedIp,UpdatedDate")] CheckInDetails checkInDetails)
        {
            if (ModelState.IsValid)
            {
                checkInDetails.QueryId = Guid.NewGuid();
                db.CheckInDetails.Add(checkInDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CheckInId = new SelectList(db.CheckIn, "Id", "InvoiceNo", checkInDetails.CheckInId);
            ViewBag.ItemCodeId = new SelectList(db.Item, "Id", "Name", checkInDetails.ItemCodeId);
            return View(checkInDetails);
        }

        // GET: CheckInDetails/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckInDetails checkInDetails = db.CheckInDetails.Find(id);
            if (checkInDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.CheckInId = new SelectList(db.CheckIn, "Id", "InvoiceNo", checkInDetails.CheckInId);
            ViewBag.ItemCodeId = new SelectList(db.Item, "Id", "Name", checkInDetails.ItemCodeId);
            return View(checkInDetails);
        }

        // POST: CheckInDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CheckInId,CpuCode,DeviceCode,ItemCodeId,ItemModel,ItemSize,ItemBrand,Unitprice,WarrantyExpireDate,ProductSerialNo,ItemStatus,CurrentStatus,Remarks,Code,PostedBy,PostedIp,PostedDate,UpdatedBy,UpdatedIp,UpdatedDate")] CheckInDetails checkInDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(checkInDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CheckInId = new SelectList(db.CheckIn, "Id", "InvoiceNo", checkInDetails.CheckInId);
            ViewBag.ItemCodeId = new SelectList(db.Item, "Id", "Name", checkInDetails.ItemCodeId);
            return View(checkInDetails);
        }

        // GET: CheckInDetails/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckInDetails checkInDetails = db.CheckInDetails.Find(id);
            if (checkInDetails == null)
            {
                return HttpNotFound();
            }
            return View(checkInDetails);
        }

        // POST: CheckInDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CheckInDetails checkInDetails = db.CheckInDetails.Find(id);
            db.CheckInDetails.Remove(checkInDetails);
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

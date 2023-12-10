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
    public class RequisitionDetailsController : Controller
    {
        private InventoryDbContext db = new InventoryDbContext();

        // GET: RequisitionDetails
        public ActionResult Index()
        {
            var requisitionDetails = db.RequisitionDetails.Include(r => r.Item).Include(r => r.Requisition);
            return View(requisitionDetails.ToList());
        }

        // GET: RequisitionDetails/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequisitionDetails requisitionDetails = db.RequisitionDetails.Find(id);
            if (requisitionDetails == null)
            {
                return HttpNotFound();
            }
            return View(requisitionDetails);
        }

        // GET: RequisitionDetails/Create
        public ActionResult Create()
        {
            ViewBag.ItemCode = new SelectList(db.Item, "Id", "Name");
            ViewBag.RequisitionId = new SelectList(db.Requisition, "Id", "RoomNo");
            return View();
        }

        // POST: RequisitionDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RequisitionId,ItemCode,Quantity,ApprovedBy,ApprovedDateTime,ApprovedIP,IssuedBy,IssuedDateTime,IssuedIP,Remarks,Status,Code,PostedBy,PostedIp,PostedDate,UpdatedBy,UpdatedIp,UpdatedDate")] RequisitionDetails requisitionDetails)
        {
            if (ModelState.IsValid)
            {
                requisitionDetails.QueryId = Guid.NewGuid();
                db.RequisitionDetails.Add(requisitionDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemCode = new SelectList(db.Item, "Id", "Name", requisitionDetails.ItemCode);
            ViewBag.RequisitionId = new SelectList(db.Requisition, "Id", "RoomNo", requisitionDetails.RequisitionId);
            return View(requisitionDetails);
        }

        // GET: RequisitionDetails/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequisitionDetails requisitionDetails = db.RequisitionDetails.Find(id);
            if (requisitionDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemCode = new SelectList(db.Item, "Id", "Name", requisitionDetails.ItemCode);
            ViewBag.RequisitionId = new SelectList(db.Requisition, "Id", "RoomNo", requisitionDetails.RequisitionId);
            return View(requisitionDetails);
        }

        // POST: RequisitionDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RequisitionId,ItemCode,Quantity,ApprovedBy,ApprovedDateTime,ApprovedIP,IssuedBy,IssuedDateTime,IssuedIP,Remarks,Status,Code,PostedBy,PostedIp,PostedDate,UpdatedBy,UpdatedIp,UpdatedDate")] RequisitionDetails requisitionDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requisitionDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemCode = new SelectList(db.Item, "Id", "Name", requisitionDetails.ItemCode);
            ViewBag.RequisitionId = new SelectList(db.Requisition, "Id", "RoomNo", requisitionDetails.RequisitionId);
            return View(requisitionDetails);
        }

        // GET: RequisitionDetails/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequisitionDetails requisitionDetails = db.RequisitionDetails.Find(id);
            if (requisitionDetails == null)
            {
                return HttpNotFound();
            }
            return View(requisitionDetails);
        }

        // POST: RequisitionDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            RequisitionDetails requisitionDetails = db.RequisitionDetails.Find(id);
            db.RequisitionDetails.Remove(requisitionDetails);
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

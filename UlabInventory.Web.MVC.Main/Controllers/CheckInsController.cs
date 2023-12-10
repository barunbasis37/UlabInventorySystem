using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ULABInventory.Model;

namespace UlabInventory.Web.MVC.Main.Controllers
{
    [Authorize]
    public class CheckInsController : Controller
    {
        private InventoryDbContext db = new InventoryDbContext();

        // GET: CheckIns
        public ActionResult Index()
        {
            var checkIn = db.CheckIn.Include(c => c.Category).Include(c => c.Supplier);
            return View(checkIn.ToList());
        }

        // GET: CheckIns/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckIn checkIn = db.CheckIn.Find(id);
            if (checkIn == null)
            {
                return HttpNotFound();
            }
            return View(checkIn);
        }

        // GET: CheckIns/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Category, "Id", "Name");
            ViewBag.SupplierId = new SelectList(db.Supplier, "Id", "Name");
            return View();
        }

        // POST: CheckIns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CategoryId,InvoiceNo,SupplierId,PurchaseDate,TotalBillAmount,Comment,PurchaseBy,ReceiptNo,Code,PostedBy,PostedIp,PostedDate,UpdatedBy,UpdatedIp,UpdatedDate")] CheckIn checkIn)
        {
            if (ModelState.IsValid)
            {
                checkIn.QueryId = Guid.NewGuid();
                db.CheckIn.Add(checkIn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Category, "Id", "Name", checkIn.CategoryId);
            ViewBag.SupplierId = new SelectList(db.Supplier, "Id", "Name", checkIn.SupplierId);
            return View(checkIn);
        }

        // GET: CheckIns/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckIn checkIn = db.CheckIn.FirstOrDefault(chkI=>chkI.QueryId==id);
            if (checkIn == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "Name", checkIn.CategoryId);
            ViewBag.SupplierId = new SelectList(db.Supplier, "SupplierId", "Name", checkIn.SupplierId);
            return View(checkIn);
        }

        // POST: CheckIns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CheckInId,QueryId,CategoryId,InvoiceNo,PurchaseDate,TotalBillAmount,Comment,PostedBy,PostedIp,PostedDate,UpdatedBy,UpdatedIp,UpdatedDate,SupplierId,InvoiceDate,PurchaseRequestNo,WorkOrderNo")] CheckIn checkIn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(checkIn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "Name", checkIn.CategoryId);
            ViewBag.SupplierId = new SelectList(db.Supplier, "SupplierId", "Name", checkIn.SupplierId);
            return View(checkIn);
        }

        // GET: CheckIns/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckIn checkIn = db.CheckIn.Find(id);
            if (checkIn == null)
            {
                return HttpNotFound();
            }
            return View(checkIn);
        }

        // POST: CheckIns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CheckIn checkIn = db.CheckIn.Find(id);
            db.CheckIn.Remove(checkIn);
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

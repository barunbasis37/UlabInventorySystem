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
    public class GarbagedsController : Controller
    {
        private InventoryDbContext db = new InventoryDbContext();

        // GET: Garbageds
        public ActionResult Index()
        {
            var garbaged = db.Garbaged.Include(g => g.CheckInDetails).Include(g => g.Employee).Include(g => g.InDetails);
            return View(garbaged.ToList());
        }

        // GET: Garbageds/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Garbaged garbaged = db.Garbaged.Find(id);
            if (garbaged == null)
            {
                return HttpNotFound();
            }
            return View(garbaged);
        }

        // GET: Garbageds/Create
        public ActionResult Create()
        {
            ViewBag.DeviceId = new SelectList(db.CheckInDetails, "Id", "ItemModel");
            ViewBag.GarbagedBy = new SelectList(db.Employee, "Id", "EmployeeId");
            ViewBag.CpuId = new SelectList(db.CheckInDetails, "Id", "ItemModel");
            return View();
        }

        // POST: Garbageds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CpuId,DeviceId,GarbagedDate,GarbagedBy,GarbagedIp,GarbagedEntryDate,Code,PostedBy,PostedIp,PostedDate,UpdatedBy,UpdatedIp,UpdatedDate")] Garbaged garbaged)
        {
            if (ModelState.IsValid)
            {
                garbaged.QueryId = Guid.NewGuid();
                db.Garbaged.Add(garbaged);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeviceId = new SelectList(db.CheckInDetails, "Id", "ItemModel", garbaged.DeviceId);
            ViewBag.GarbagedBy = new SelectList(db.Employee, "Id", "EmployeeId", garbaged.GarbagedBy);
            ViewBag.CpuId = new SelectList(db.CheckInDetails, "Id", "ItemModel", garbaged.CpuId);
            return View(garbaged);
        }

        // GET: Garbageds/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Garbaged garbaged = db.Garbaged.Find(id);
            if (garbaged == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeviceId = new SelectList(db.CheckInDetails, "Id", "ItemModel", garbaged.DeviceId);
            ViewBag.GarbagedBy = new SelectList(db.Employee, "Id", "EmployeeId", garbaged.GarbagedBy);
            ViewBag.CpuId = new SelectList(db.CheckInDetails, "Id", "ItemModel", garbaged.CpuId);
            return View(garbaged);
        }

        // POST: Garbageds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CpuId,DeviceId,GarbagedDate,GarbagedBy,GarbagedIp,GarbagedEntryDate,Code,PostedBy,PostedIp,PostedDate,UpdatedBy,UpdatedIp,UpdatedDate")] Garbaged garbaged)
        {
            if (ModelState.IsValid)
            {
                db.Entry(garbaged).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeviceId = new SelectList(db.CheckInDetails, "Id", "ItemModel", garbaged.DeviceId);
            ViewBag.GarbagedBy = new SelectList(db.Employee, "Id", "EmployeeId", garbaged.GarbagedBy);
            ViewBag.CpuId = new SelectList(db.CheckInDetails, "Id", "ItemModel", garbaged.CpuId);
            return View(garbaged);
        }

        // GET: Garbageds/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Garbaged garbaged = db.Garbaged.Find(id);
            if (garbaged == null)
            {
                return HttpNotFound();
            }
            return View(garbaged);
        }

        // POST: Garbageds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Garbaged garbaged = db.Garbaged.Find(id);
            db.Garbaged.Remove(garbaged);
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

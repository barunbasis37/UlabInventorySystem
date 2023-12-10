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
    public class RequisitionsController : Controller
    {
        private InventoryDbContext db = new InventoryDbContext();

        // GET: Requisitions
        public ActionResult Index()
        {
            var requisition = db.Requisition.Include(r => r.Campus).Include(r => r.Employees);
            return View(requisition.ToList());
        }

        // GET: Requisitions/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requisition requisition = db.Requisition.Find(id);
            if (requisition == null)
            {
                return HttpNotFound();
            }
            return View(requisition);
        }

        // GET: Requisitions/Create
        public ActionResult Create()
        {
            ViewBag.CampusID = new SelectList(db.Campus, "Id", "Name");
            ViewBag.EmployeeId = new SelectList(db.Employee, "Id", "EmployeeId");
            return View();
        }

        // POST: Requisitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmployeeId,CampusID,RoomNo,FloorNo,Remarks,Code,PostedBy,PostedIp,PostedDate,UpdatedBy,UpdatedIp,UpdatedDate")] Requisition requisition)
        {
            if (ModelState.IsValid)
            {
                requisition.QueryId = Guid.NewGuid();
                db.Requisition.Add(requisition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CampusID = new SelectList(db.Campus, "Id", "Name", requisition.CampusId);
            ViewBag.EmployeeId = new SelectList(db.Employee, "Id", "EmployeeId", requisition.EmployeeId);
            return View(requisition);
        }

        // GET: Requisitions/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requisition requisition = db.Requisition.Find(id);
            if (requisition == null)
            {
                return HttpNotFound();
            }
            ViewBag.CampusID = new SelectList(db.Campus, "Id", "Name", requisition.CampusId);
            ViewBag.EmployeeId = new SelectList(db.Employee, "Id", "EmployeeId", requisition.EmployeeId);
            return View(requisition);
        }

        // POST: Requisitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployeeId,CampusID,RoomNo,FloorNo,Remarks,Code,PostedBy,PostedIp,PostedDate,UpdatedBy,UpdatedIp,UpdatedDate")] Requisition requisition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requisition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CampusID = new SelectList(db.Campus, "Id", "Name", requisition.CampusId);
            ViewBag.EmployeeId = new SelectList(db.Employee, "Id", "EmployeeId", requisition.EmployeeId);
            return View(requisition);
        }

        // GET: Requisitions/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requisition requisition = db.Requisition.Find(id);
            if (requisition == null)
            {
                return HttpNotFound();
            }
            return View(requisition);
        }

        // POST: Requisitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Requisition requisition = db.Requisition.Find(id);
            db.Requisition.Remove(requisition);
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

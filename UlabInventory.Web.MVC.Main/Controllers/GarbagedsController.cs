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
    public class GarbagedsController : Controller
    {
        private InventoryDbContext db = new InventoryDbContext();

        // GET: Garbageds
        public ActionResult Index()
        {
            var garbaged = db.Garbaged.Include(g => g.Employee);
            return View(garbaged.ToList());
        }

        // GET: Garbageds/Details/5
        public ActionResult Details(string id)
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
            ViewBag.GarbagedBy = new SelectList(db.Employee, "EmployeeId", "Name");
            return View();
        }

        // POST: Garbageds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GarbagedId,CpuId,DeviceId,GarbagedDate,GarbagedBy,GarbagedIp,GarbagedEntryDate,QueryId,PostedBy,PostedIp,PostedDate,UpdatedBy,UpdatedIp,UpdatedDate")] Garbaged garbaged)
        {
            if (ModelState.IsValid)
            {
                db.Garbaged.Add(garbaged);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GarbagedBy = new SelectList(db.Employee, "EmployeeId", "Name", garbaged.GarbagedBy);
            return View(garbaged);
        }

        // GET: Garbageds/Edit/5
        public ActionResult Edit(string id)
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
            ViewBag.GarbagedBy = new SelectList(db.Employee, "EmployeeId", "Name", garbaged.GarbagedBy);
            return View(garbaged);
        }

        // POST: Garbageds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GarbagedId,CpuId,DeviceId,GarbagedDate,GarbagedBy,GarbagedIp,GarbagedEntryDate,QueryId,PostedBy,PostedIp,PostedDate,UpdatedBy,UpdatedIp,UpdatedDate")] Garbaged garbaged)
        {
            if (ModelState.IsValid)
            {
                db.Entry(garbaged).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GarbagedBy = new SelectList(db.Employee, "EmployeeId", "Name", garbaged.GarbagedBy);
            return View(garbaged);
        }

        // GET: Garbageds/Delete/5
        public ActionResult Delete(string id)
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
        public ActionResult DeleteConfirmed(string id)
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

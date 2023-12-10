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
    public class CampusController : Controller
    {
        private InventoryDbContext db = new InventoryDbContext();
        CampusService aCampusService=new CampusService();

        // GET: Campus
        public ActionResult Index()
        {
            return View(db.Campus.ToList());
        }

        public JsonResult getCampus()
        {
            List<Campus> campuses = new List<Campus>();
            using (db)
            {
                campuses = db.Campus.OrderBy(a => a.Name).ToList();
            }
            return new JsonResult { Data = campuses, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        // GET: Campus/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campus campus = db.Campus.FirstOrDefault(dId => dId.QueryId == id);
            if (campus == null)
            {
                return HttpNotFound();
            }
            return View(campus);
        }

        // GET: Campus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Campus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Campus campus)
        {
            //if (ModelState.IsValid)
            //{

            campus.PostedBy = User.Identity.GetUserName();
            campus.PostedIp = Request.UserHostAddress;
            campus.UpdatedBy = User.Identity.GetUserName();
            campus.UpdatedIp = Request.UserHostAddress;
            bool saved = aCampusService.Save(campus);
            if (saved)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(campus);
            }
            //}

            //return View(campus);
        }

        // GET: Campus/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campus campus = db.Campus.FirstOrDefault(dId => dId.QueryId == id);
            if (campus == null)
            {
                return HttpNotFound();
            }
            return View(campus);
        }

        // POST: Campus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CampusId,Name,Address,Type,StartDateTime,QueryId,PostedBy,PostedIp,PostedDate,UpdatedBy,UpdatedIp,UpdatedDate")] Campus campus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(campus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(campus);
        }

        // GET: Campus/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campus campus = db.Campus.FirstOrDefault(dId => dId.QueryId == id);
            if (campus == null)
            {
                return HttpNotFound();
            }
            return View(campus);
        }

        // POST: Campus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid? id)
        {
            Campus campus = db.Campus.FirstOrDefault(dId => dId.QueryId == id);
            db.Campus.Remove(campus);
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

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
    public class IssuesController : Controller
    {
        private InventoryDbContext db = new InventoryDbContext();

        // GET: Issues
        public ActionResult Index()
        {
            var issue = db.Issue.Include(i => i.Campus).Include(i => i.Department).Include(i => i.Employee);
            return View(issue.ToList());
        }

        // GET: Issues/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Issue issue = db.Issue.Find(id);
            if (issue == null)
            {
                return HttpNotFound();
            }
            return View(issue);
        }

        // GET: Issues/Create
        public ActionResult Create()
        {
            ViewBag.CampusId = new SelectList(db.Campus, "Id", "Name");
            ViewBag.DepartmentId = new SelectList(db.Department, "Id", "DepartmentShortCode");
            ViewBag.EmployeeId = new SelectList(db.Employee, "Id", "EmployeeId");
            return View();
        }

        // POST: Issues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmployeeId,DepartmentId,CampusId,Floor,Room,IssueRemark,ReturnRemark,ApprovedId,ApprovedDateTime,ApprovedIp,Code,PostedBy,PostedIp,PostedDate,UpdatedBy,UpdatedIp,UpdatedDate")] Issue issue)
        {
            if (ModelState.IsValid)
            {
                issue.QueryId = Guid.NewGuid();
                db.Issue.Add(issue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CampusId = new SelectList(db.Campus, "Id", "Name", issue.CampusId);
            ViewBag.DepartmentId = new SelectList(db.Department, "Id", "DepartmentShortCode", issue.DepartmentId);
            ViewBag.EmployeeId = new SelectList(db.Employee, "Id", "EmployeeId", issue.EmployeeId);
            return View(issue);
        }

        // GET: Issues/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Issue issue = db.Issue.Find(id);
            if (issue == null)
            {
                return HttpNotFound();
            }
            ViewBag.CampusId = new SelectList(db.Campus, "Id", "Name", issue.CampusId);
            ViewBag.DepartmentId = new SelectList(db.Department, "Id", "DepartmentShortCode", issue.DepartmentId);
            ViewBag.EmployeeId = new SelectList(db.Employee, "Id", "EmployeeId", issue.EmployeeId);
            return View(issue);
        }

        // POST: Issues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployeeId,DepartmentId,CampusId,Floor,Room,IssueRemark,ReturnRemark,ApprovedId,ApprovedDateTime,ApprovedIp,Code,PostedBy,PostedIp,PostedDate,UpdatedBy,UpdatedIp,UpdatedDate")] Issue issue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(issue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CampusId = new SelectList(db.Campus, "Id", "Name", issue.CampusId);
            ViewBag.DepartmentId = new SelectList(db.Department, "Id", "DepartmentShortCode", issue.DepartmentId);
            ViewBag.EmployeeId = new SelectList(db.Employee, "Id", "EmployeeId", issue.EmployeeId);
            return View(issue);
        }

        // GET: Issues/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Issue issue = db.Issue.Find(id);
            if (issue == null)
            {
                return HttpNotFound();
            }
            return View(issue);
        }

        // POST: Issues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Issue issue = db.Issue.Find(id);
            db.Issue.Remove(issue);
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

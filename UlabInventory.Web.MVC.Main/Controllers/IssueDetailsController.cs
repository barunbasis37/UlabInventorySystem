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
    public class IssueDetailsController : Controller
    {
        private InventoryDbContext db = new InventoryDbContext();

        public ActionResult IssueDetailsView()
        {

            return View();
        }
        // GET: IssueDetails
        public ActionResult Index()
        {
            var issueDetail = db.IssueDetail.Include(i => i.Issue);
            return View(issueDetail.ToList());
        }

        // GET: IssueDetails/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IssueDetail issueDetail = db.IssueDetail.FirstOrDefault(issId=>issId.QueryId==id);
            if (issueDetail == null)
            {
                return HttpNotFound();
            }
            return View(issueDetail);
        }

        // GET: IssueDetails/Create
        public ActionResult Create()
        {
            ViewBag.IssueId = new SelectList(db.Issue, "IssueId", "EmployeeId");
            return View();
        }

        // POST: IssueDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IssueDetailId,IssueId,CpuId,DeviceId,AgainstDeviceCode,CurrentStatus,DeviceReturnRemarks,IssueDate,ReturnDate,ReturnComment,QueryId,PostedBy,PostedIp,PostedDate,UpdatedBy,UpdatedIp,UpdatedDate")] IssueDetail issueDetail)
        {
            if (ModelState.IsValid)
            {
                db.IssueDetail.Add(issueDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IssueId = new SelectList(db.Issue, "IssueId", "EmployeeId", issueDetail.IssueId);
            return View(issueDetail);
        }

        // GET: IssueDetails/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IssueDetail issueDetail = db.IssueDetail.Include("CheckInDetail").FirstOrDefault(issId => issId.QueryId == id);
            if (issueDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.IssueId = new SelectList(db.Issue, "IssueId", "EmployeeId", issueDetail.IssueId);
            return View(issueDetail);
        }

        // POST: IssueDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IssueDetailId,IssueId,CpuId,DeviceId,AgainstDeviceCode,CurrentStatus,DeviceReturnRemarks,IssueDate,ReturnDate,ReturnComment,QueryId,PostedBy,PostedIp,PostedDate,UpdatedBy,UpdatedIp,UpdatedDate")] IssueDetail issueDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(issueDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IssueId = new SelectList(db.Issue, "IssueId", "EmployeeId", issueDetail.IssueId);
            return View(issueDetail);
        }

        // GET: IssueDetails/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IssueDetail issueDetail = db.IssueDetail.FirstOrDefault(issId => issId.QueryId == id);
            if (issueDetail == null)
            {
                return HttpNotFound();
            }
            return View(issueDetail);
        }

        // POST: IssueDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid? id)
        {
            IssueDetail issueDetail = db.IssueDetail.FirstOrDefault(issId => issId.QueryId == id);
            db.IssueDetail.Remove(issueDetail);
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

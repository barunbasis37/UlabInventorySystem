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

namespace UlabInventory.Web.MVC.Main.Controllers
{
    public class IssueTypesController : Controller
    {
        private InventoryDbContext db = new InventoryDbContext();

        // GET: IssueTypes
        public ActionResult Index()
        {
            return View(db.IssueTypes.ToList());
        }

        [HttpGet]
        public JsonResult GetIssueType()
        {
            List<IssueType> issueTypes = new List<IssueType>();
            using (db)
            {
                issueTypes = db.IssueTypes.OrderBy(a => a.Name).ToList();
            }
            return new JsonResult { Data = issueTypes, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        // GET: IssueTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IssueType issueType = db.IssueTypes.Find(id);
            if (issueType == null)
            {
                return HttpNotFound();
            }
            return View(issueType);
        }

        // GET: IssueTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IssueTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IssueType issueType)
        {
            //if (ModelState.IsValid)
            //{
            issueType.QueryId = Guid.NewGuid();
            issueType.PostedBy = User.Identity.GetUserName();
            issueType.PostedIp = Request.UserHostAddress;
            issueType.PostedDate = DateTime.Now;
            issueType.UpdatedBy = User.Identity.GetUserName();
            issueType.UpdatedIp = Request.UserHostAddress;
            issueType.UpdatedDate = DateTime.Now;
            db.IssueTypes.Add(issueType);
            db.SaveChanges();
            return RedirectToAction("Index");
            //}

            //return View(issueType);
        }

        // GET: IssueTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IssueType issueType = db.IssueTypes.Find(id);
            if (issueType == null)
            {
                return HttpNotFound();
            }
            return View(issueType);
        }

        // POST: IssueTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IssueType issueType)
        {
            //if (ModelState.IsValid)
            //{
            
            issueType.UpdatedIp = Request.UserHostAddress;
            issueType.UpdatedDate = DateTime.Now;
            db.Entry(issueType).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
            //}
            //return View(issueType);
        }

        // GET: IssueTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IssueType issueType = db.IssueTypes.Find(id);
            if (issueType == null)
            {
                return HttpNotFound();
            }
            return View(issueType);
        }

        // POST: IssueTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IssueType issueType = db.IssueTypes.Find(id);
            db.IssueTypes.Remove(issueType);
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

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
using ULABInventory.ViewModels;

namespace UlabInventory.Web.MVC.Main.Controllers
{
    [Authorize]
    public class SchoolsController : Controller
    {
        SchoolService aSchoolService = new SchoolService();

        // GET: Schools
        public ActionResult Index()
        {
            List<SchoolVM> listofSchools = aSchoolService.GetList();
            return View(listofSchools);
        }


        // GET: Schools/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            School school = aSchoolService.GetDbObject(id);
            if (school == null)
            {
                return HttpNotFound();
            }
            return View(school);
        }

        // GET: Schools/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Schools/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(School school)
        {
            //if (ModelState.IsValid)
            //{

                school.QueryId = Guid.NewGuid();
                school.PostedBy = User.Identity.GetUserName();
                school.PostedIp = Request.UserHostAddress;
                school.PostedDate = DateTime.Now;
                school.UpdatedBy = User.Identity.GetUserName();
                school.UpdatedIp = Request.UserHostAddress;
                school.UpdatedDate = DateTime.Now;
                bool saved = aSchoolService.Save(school);
                if (saved)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(school);
                }
            //}

            //return View(school);
        }

        // GET: Schools/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            School school = aSchoolService.GetDbObject(id);
            if (school == null)
            {
                return HttpNotFound();
            }
            return View(school);
        }

        // POST: Schools/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SchoolId,Name,PriorityLevel,QueryId,PostedBy,PostedIp,PostedDate,UpdatedBy,UpdatedIp,UpdatedDate")] School school)
        {
            if (ModelState.IsValid)
            {
                school.UpdatedBy = User.Identity.GetUserName();
                school.UpdatedIp = Request.UserHostAddress;
                school.UpdatedDate = DateTime.Now;
                bool edited = aSchoolService.Update(school);
                return RedirectToAction("Index");
            }
            return View(school);
        }

        // GET: Schools/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            School school = aSchoolService.GetDbObject(id);
            if (school == null)
            {
                return HttpNotFound();
            }
            return View(school);
        }

        // POST: Schools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(School school)
        {
            bool deleted = aSchoolService.Delete(school);
            return RedirectToAction("Index");
        }

        InventoryDbContext db =new InventoryDbContext();
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

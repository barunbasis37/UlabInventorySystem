using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ULABInventory.Model;
using Microsoft.AspNet.Identity;

using System.IO;
using Microsoft.Reporting.WebForms;

//using Microsoft.Reporting.WebForms;

namespace UlabInventory.Web.MVC.Main.Controllers
{
    [Authorize]
    public class DepartmentsController : Controller
    {
        private InventoryDbContext db = new InventoryDbContext();

        // GET: Departments
        public ActionResult Index()
        {
            var department = db.Department.Include(d => d.School).OrderBy(d => d.Priority);
            return View(department.ToList());
        }

        // GET: Departments
        public ActionResult Report(string id)
        {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "rptDepartment.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return View("Index");
            }
            List<Department> cm = new List<Department>();
            using (db)
            {
                cm = db.Department.ToList();
            }
            ReportDataSource rd = new ReportDataSource("DepartmentDS", cm);
            lr.DataSources.Add(rd);
            string reportType = id;
            string mimeType;
            string encoding;
            string fileNameExtension;



            string deviceInfo =

            "<DeviceInfo>" +
            "  <OutputFormat>" + id + "</OutputFormat>" +
            "  <PageWidth>8.5in</PageWidth>" +
            "  <PageHeight>11in</PageHeight>" +
            "  <MarginTop>0.5in</MarginTop>" +
            "  <MarginLeft>1in</MarginLeft>" +
            "  <MarginRight>1in</MarginRight>" +
            "  <MarginBottom>0.5in</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);
            return File(renderedBytes, mimeType);

        }



        //Get Departments
        [HttpGet]
        public JsonResult GetDepartment()
        {
            List<Department> departments = new List<Department>();
            using (db)
            {
                departments = db.Department.OrderBy(a => a.Priority).ToList();
            }
            return new JsonResult { Data = departments, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        // GET: Departments/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Department.Include(d=>d.School).FirstOrDefault(dId=>dId.QueryId==id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            ViewBag.SchoolId = new SelectList(db.School, "SchoolId", "Name");
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department department)
        {
            try
            {
                department.QueryId = Guid.NewGuid();
                department.PostedBy = User.Identity.GetUserName();
                department.PostedIp = Request.UserHostAddress;
                department.PostedDate = DateTime.Now;
                department.UpdatedBy = User.Identity.GetUserName();
                department.UpdatedIp = Request.UserHostAddress;
                department.UpdatedDate = DateTime.Now;
                //if (ModelState.IsValid)
                //{
                    db.Department.Add(department);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                //}
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            

            //ViewBag.SchoolId = new SelectList(db.School, "SchoolId", "Name", department.SchoolId);
            //return View(department);
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Department.FirstOrDefault(dId => dId.QueryId == id);
            if (department == null)
            {
                return HttpNotFound();
            }
            ViewBag.SchoolId = new SelectList(db.School, "SchoolId", "Name", department.SchoolId);
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartmentId,Name,SchoolId,Type,Priority,Description,QueryId,PostedBy,PostedIp,PostedDate,UpdatedBy,UpdatedIp,UpdatedDate")] Department department)
        {
            if (ModelState.IsValid)
            {
                db.Entry(department).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SchoolId = new SelectList(db.School, "SchoolId", "Name", department.SchoolId);
            return View(department);
        }

        // GET: Departments/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Department.FirstOrDefault(dId => dId.QueryId == id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid? id)
        {
            Department department = db.Department.FirstOrDefault(dId => dId.QueryId == id);
            db.Department.Remove(department);
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

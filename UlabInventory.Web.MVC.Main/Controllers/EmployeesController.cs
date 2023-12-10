using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using Microsoft.AspNet.Identity;
using Microsoft.Reporting.WebForms;
using ULABInventory.Model;
using ULABInventory.Repository;
using ULABInventory.ViewModels;

namespace UlabInventory.Web.MVC.Main.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private InventoryDbContext db = new InventoryDbContext();
        EmployeeRepository aEmpRepo=new EmployeeRepository();

        // GET: Employees
        public ActionResult Index()
        {
            var employee = db.Employee.Include(e => e.Department).Include(e => e.Program);
            return View(employee.ToList());
        }

        //Get Campus
        [HttpGet]
        public JsonResult GetEmployee()
        {
            List<Employee> employees = new List<Employee>();
            using (db)
            {
                employees = db.Employee.OrderBy(a => a.Name).ToList();
            }
            return new JsonResult { Data = employees, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }

        [HttpGet]
        public ActionResult GetEmployeeSP()
        {
            return View(aEmpRepo.GetAllEmployees());

        }

        public ActionResult Report(string id)
        {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "rptEmployee.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return View("GetEmployeeSP");
            }
            List<EmployeeVM> cm = new List<EmployeeVM>();
            using (db)
            {
                cm = aEmpRepo.GetAllEmployees();
            }
            ReportDataSource rd = new ReportDataSource("EmployeeDS", cm);
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

        public ActionResult EmployeeReport(string id)
        {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "rptEmployee.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return View("GetEmployeeSP");
            }
            List<EmployeeVM> cm = new List<EmployeeVM>();
            using (db)
            {
                cm = aEmpRepo.GetAllEmployees();
            }
            ReportDataSource rd = new ReportDataSource("EmployeeDS", cm);
            lr.DataSources.Add(rd);
            string reportType = "PDF";
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
                reportType, deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
            return File(renderedBytes, mimeType);

        }
        public ActionResult DownloadEmployeeList()
        {
            ReportDocument empRpt=new ReportDocument();
            empRpt.Load(Path.Combine(Server.MapPath("~/Report"), "EmployeeInfo.rpt"));
            empRpt.SetDataSource(aEmpRepo.GetAllEmployees());
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            try
            {
                Stream stream = empRpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "EmpList" + User.Identity.GetUserName() + ".pdf");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet]
        public JsonResult GetEmployeeByDept(string departmentId)
        {
            List<Employee> employees = new List<Employee>();
            using (db)
            {
                employees = db.Employee.Where(deptId=>deptId.DepartmentId== departmentId).OrderBy(a => a.Name).ToList();
            }
            return new JsonResult { Data = employees, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }

        // GET: Employees/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Include(e => e.Department).Include(pd=>pd.Program).FirstOrDefault(emp => emp.QueryId == id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.ProgramId = new SelectList(db.Program, "ProgramId", "Name");
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "Name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                employee.QueryId = Guid.NewGuid();
                employee.PostedBy = User.Identity.GetUserName();
                employee.PostedIp = Request.UserHostAddress;
                employee.PostedDate = DateTime.Now;
                employee.UpdatedBy = User.Identity.GetUserName();
                employee.UpdatedIp = Request.UserHostAddress;
                employee.UpdatedDate = DateTime.Now;

                db.Employee.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

            }

            ViewBag.ProgramId = new SelectList(db.Program, "ProgramId", "Name", employee.ProgramId);
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "Name", employee.DepartmentId);
            return View(employee);

        }

        // GET: Employees/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.FirstOrDefault(emp=>emp.QueryId==id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "Name", employee.DepartmentId);
            ViewBag.ProgramId = new SelectList(db.Program, "ProgramId", "Name", employee.ProgramId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            try
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            
                
           
            //ViewBag.ProgramId = new SelectList(db.Program, "ProgramId", "Name", employee.ProgramId);
            //return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Include(e => e.Department).Include(e => e.Program).FirstOrDefault(emp => emp.QueryId == id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Employee employee = db.Employee.FirstOrDefault(emp => emp.QueryId == id);
            db.Employee.Remove(employee);
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

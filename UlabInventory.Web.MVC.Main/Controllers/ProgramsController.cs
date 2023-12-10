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
    [Authorize]
    public class ProgramsController : Controller
    {
        private InventoryDbContext db = new InventoryDbContext();

        // GET: Programs
        public ActionResult Index()
        {
            var program = db.Program.Include(p => p.Department).OrderBy(p=>p.Priority);
            return View(program.ToList());
        }

        // GET: Programs/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Program program = db.Program.Include(p => p.Department).FirstOrDefault(pId => pId.QueryId == id);
            if (program == null)
            {
                return HttpNotFound();
            }
            return View(program);
        }


        public JsonResult GetProgramList(string departmentId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Program> programList = db.Program.Where(x => x.DepartmentId == departmentId).ToList();
            return Json(programList, JsonRequestBehavior.AllowGet);

        }
        
        // GET: Programs/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "Name");
            return View();
        }

        // POST: Programs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Program program)
        {
            //if (ModelState.IsValid)
            //{
            program.QueryId = Guid.NewGuid();
            program.PostedBy = User.Identity.GetUserName();
            program.PostedIp = Request.UserHostAddress;
            program.PostedDate = DateTime.Now;
            program.UpdatedBy = User.Identity.GetUserName();
            program.UpdatedIp = Request.UserHostAddress;
            program.UpdatedDate = DateTime.Now;
            db.Program.Add(program);
                db.SaveChanges();
                return RedirectToAction("Index");
            //}

            //ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "Name", program.DepartmentId);
            //return View(program);
        }

        // GET: Programs/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Program program = db.Program.FirstOrDefault(pId => pId.QueryId == id);
            if (program == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "Name", program.DepartmentId);
            return View(program);
        }

        // POST: Programs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProgramId,Name,DepartmentId,Type,Priority,Description,QueryId,PostedBy,PostedIp,PostedDate,UpdatedBy,UpdatedIp,UpdatedDate")] Program program)
        {
            if (ModelState.IsValid)
            {
                db.Entry(program).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "Name", program.DepartmentId);
            return View(program);
        }

        // GET: Programs/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Program program = db.Program.FirstOrDefault(pId => pId.QueryId == id);
            if (program == null)
            {
                return HttpNotFound();
            }
            return View(program);
        }

        // POST: Programs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid? id)
        {
            Program program = db.Program.FirstOrDefault(pId=>pId.QueryId==id);
            db.Program.Remove(program);
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

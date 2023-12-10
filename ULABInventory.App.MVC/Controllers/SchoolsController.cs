using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ULABInventory.Model;
using ULABInventory.Service;
using ULABInventory.ViewModels;

namespace ULABInventory.App.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SchoolsController : Controller
    {
        SchoolService aSchoolService = new SchoolService();
        // GET: Schools
        public ActionResult Index()
        {
            var schoolList=aSchoolService.GetList();
            return View(schoolList);
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolVM aSchoolVm=aSchoolService.Details(id);
            if (aSchoolVm == null)
            {
                return HttpNotFound();
            }
            return View(aSchoolVm);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(School school)
        {
            school.PostedBy = User.Identity.GetUserName();
            school.PostedIp = Request.UserHostAddress;
            school.PostedDate = DateTime.Now;
            school.UpdatedBy = User.Identity.GetUserName();
            school.UpdatedIp = Request.UserHostAddress;
            school.UpdatedDate = DateTime.Now;
            bool saved = aSchoolService.Save(school);
            return RedirectToActionPermanent("Index");
        }
        [HttpGet]
        public ActionResult Edit(string id)
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
        [HttpPost]
        public ActionResult Edit(School school)
        {
            school.UpdatedBy = User.Identity.GetUserName();
            school.UpdatedIp = Request.UserHostAddress;
            school.UpdatedDate = DateTime.Now;
            bool updated = aSchoolService.Update(school);
            return RedirectToActionPermanent("Index");
        }
        [HttpGet]
        public ActionResult Delete(string id)
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
        [HttpPost]
        public ActionResult Delete(School school)
        {
            bool updated = aSchoolService.Delete(school);
            return RedirectToActionPermanent("Index");
        }
    }
}
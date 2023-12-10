using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PagedList;
using ULABInventory.Model;

namespace UlabInventory.Web.MVC.Main.Controllers
{
    [Authorize]
    public class CheckInDetailsController : Controller
    {
        private InventoryDbContext db = new InventoryDbContext();

        // GET: CheckInDetails
        public ActionResult Index(string search, int? page)
        {
            var checkInDetail = db.CheckInDetail
                .Where(a => a.AuditCode.Contains(search) || a.CpuId.Contains(search) || search == null)
                .Include(c => c.CheckIn).Include(c => c.Item);
            return View(checkInDetail.ToList().ToPagedList(page ?? 1, 10));
        }

        public ActionResult CheckInDetailsView()
        {
            
            return View();
        }

        // GET: CheckInDetails/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckInDetail checkInDetail = db.CheckInDetail.Include(chkD => chkD.ItemDetail.Item).Include(chkD => chkD.ItemDetail).Include(chkD=>chkD.Item.Category).FirstOrDefault(i => i.QueryId == id);
            if (checkInDetail == null)
            {
                return HttpNotFound();
            }
            return View(checkInDetail);
        }

        // GET: CheckInDetails/Create
        public ActionResult Create()
        {
            ViewBag.CheckInId = new SelectList(db.CheckIn, "CheckInId", "CategoryId");
            ViewBag.ItemCodeId = new SelectList(db.Item, "ItemId", "Name");
            return View();
        }

        // POST: CheckInDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CheckInDetail checkInDetail)
        {
            //if (ModelState.IsValid)
            //{
            checkInDetail.QueryId = Guid.NewGuid();
            checkInDetail.PostedBy = User.Identity.GetUserName();
            checkInDetail.PostedIp = Request.UserHostAddress;
            checkInDetail.PostedDate = DateTime.Now;
            checkInDetail.UpdatedBy = User.Identity.GetUserName();
            checkInDetail.UpdatedIp = Request.UserHostAddress;
            checkInDetail.UpdatedDate = DateTime.Now;
            db.CheckInDetail.Add(checkInDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            //}

            //ViewBag.CheckInId = new SelectList(db.CheckIn, "CheckInId", "CategoryId", checkInDetail.CheckInId);
            //ViewBag.ItemCodeId = new SelectList(db.Item, "ItemId", "Name", checkInDetail.ItemCodeId);
            //return View(checkInDetail);
        }

        // GET: CheckInDetails/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckInDetail checkInDetail = db.CheckInDetail.FirstOrDefault(i => i.QueryId == id);
            if (checkInDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.CheckInId = new SelectList(db.CheckIn, "CheckInId", "CategoryId", checkInDetail.CheckInId);
            IEnumerable<ItemDetail> itemDetailsList= db.ItemDetail.Where(iD => iD.ItemDetailId == checkInDetail.ItemDetailsId).Include(itmD => itmD.Item).ToList();
            ViewBag.ItemCodeDId=itemDetailsList.Select(i => new SelectListItem
            {
                Text = i.Item.Name+"("+ i.Model + "-"+i.Brand +"-"+i.Size  +")",
                Value = i.ItemDetailId.ToString()
            });
            //ViewBag.ItemCodeDId = new SelectList(db.ItemDetail.Include(itmD => itmD.Item), "ItemDetailId", "Item.Name" + "(" + "Model" + "Size" + "Brand" + ")");
            return View(checkInDetail);
        }

        // POST: CheckInDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CheckInDetailId,QueryId,CheckInId,AuditCode,ItemId,ItemDetailsId,Unitprice,WarrantyExpireDate,ProductSerialNo,ItemStatus,CurrentStatus,Remarks,CpuId,DeviceId,QRCodeImgPath,QRImage,WarrentyDuration,PostedBy,PostedIp,PostedDate,UpdatedBy,UpdatedIp,UpdatedDate")] CheckInDetail checkInDetail)
        {


            if (ModelState.IsValid)
            {
                db.Entry(checkInDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CheckInId = new SelectList(db.CheckIn, "CheckInId", "CategoryId", checkInDetail.CheckInId);
            ViewBag.ItemCodeId = new SelectList(db.Item, "ItemId", "Name", checkInDetail.ItemId);
            return View(checkInDetail);
        }

        // GET: CheckInDetails/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckInDetail checkInDetail = db.CheckInDetail.FirstOrDefault(i => i.QueryId == id);
            if (checkInDetail == null)
            {
                return HttpNotFound();
            }
            return View(checkInDetail);
        }

        // POST: CheckInDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid? id)
        {
            CheckInDetail checkInDetail = db.CheckInDetail.FirstOrDefault(i => i.QueryId == id);
            db.CheckInDetail.Remove(checkInDetail);
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

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
using ULABInventory.Service;

namespace UlabInventory.Web.MVC.Main.Controllers
{
    [Authorize]
    public class ItemDetailsController : Controller
    {
        private InventoryDbContext db = new InventoryDbContext();
        ItemDetailService aItemDetailService = new ItemDetailService();
        // GET: ItemDetails
        public ActionResult Index(string search, int? page)
        {
            var itemDetail = db.ItemDetail
                .Where(a => a.Brand.Contains(search) || a.ItemDetailId.Contains(search) || a.Size.Contains(search) || a.Model.Contains(search) || search == null)
                .Include(c => c.Item).Include(c => c.Item.Category);
            return View(itemDetail.ToList().ToPagedList(page ?? 1, 10));
        }

        // GET: ItemDetails/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemDetail itemDetail = db.ItemDetail.Include(i => i.Item).FirstOrDefault(i=>i.QueryId==id);
            if (itemDetail == null)
            {
                return HttpNotFound();
            }
            return View(itemDetail);
        }

        // GET: ItemDetails/Create
        public ActionResult Create()
        {
            ViewBag.ItemId = new SelectList(db.Item, "ItemId", "Name");
            return View();
        }

        // POST: ItemDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemDetail itemDetail)
        {
            //if (ModelState.IsValid)
            //{
            try
            {
                itemDetail.QueryId = Guid.NewGuid();
                itemDetail.PostedBy = User.Identity.GetUserName();
                itemDetail.PostedIp = Request.UserHostAddress;
                itemDetail.PostedDate = DateTime.Now;
                itemDetail.UpdatedBy = User.Identity.GetUserName();
                itemDetail.UpdatedIp = Request.UserHostAddress;
                itemDetail.UpdatedDate = DateTime.Now;
                bool saved = aItemDetailService.Save(itemDetail);
                if (saved)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(itemDetail);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            //}

            //ViewBag.ItemId = new SelectList(db.Item, "ItemId", "Name", itemDetail.ItemId);
            //return View(itemDetail);
        }

        // GET: ItemDetails/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemDetail itemDetail = db.ItemDetail.Include(i => i.Item).FirstOrDefault(i => i.QueryId == id);
            if (itemDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemId = new SelectList(db.Item, "ItemId", "Name", itemDetail.ItemId);
            return View(itemDetail);
        }

        // POST: ItemDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemDetailId,ItemId,Model,Size,Brand,Price,Details,QueryId,PostedBy,PostedIp,PostedDate,UpdatedBy,UpdatedIp,UpdatedDate")] ItemDetail itemDetail)
        {
            itemDetail.QueryId = Guid.NewGuid();
            itemDetail.PostedBy = User.Identity.GetUserName();
            itemDetail.PostedIp = Request.UserHostAddress;
            itemDetail.PostedDate = DateTime.Now;
            itemDetail.UpdatedBy = User.Identity.GetUserName();
            itemDetail.UpdatedIp = Request.UserHostAddress;
            itemDetail.UpdatedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(itemDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(db.Item, "ItemId", "Name", itemDetail.ItemId);
            return View(itemDetail);
        }

        // GET: ItemDetails/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemDetail itemDetail = db.ItemDetail.Include(i => i.Item).FirstOrDefault(i => i.QueryId == id);
            if (itemDetail == null)
            {
                return HttpNotFound();
            }
            return View(itemDetail);
        }

        // POST: ItemDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid? id)
        {
            ItemDetail itemDetail = db.ItemDetail.FirstOrDefault(i => i.QueryId == id);
            db.ItemDetail.Remove(itemDetail);
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

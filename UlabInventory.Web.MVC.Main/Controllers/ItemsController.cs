using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using ULABInventory.Model;
using ULABInventory.Service;

namespace UlabInventory.Web.MVC.Main.Controllers
{
    [Authorize]
    public class ItemsController : Controller
    {
        private InventoryDbContext db = new InventoryDbContext();
        ItemService aItemService = new ItemService();
        // GET: Items
        public ActionResult Index()
        {
            var item = db.Item.Include(i => i.Category).Include(i => i.SubCategory);
            return View(item.ToList());
        }

        //Get: Item
        public JsonResult GetItem()
        {
            List<Item> items = new List<Item>();
            using (db)
            {
                items = db.Item.OrderBy(i => i.Name).ToList();
            }
            return new JsonResult {Data = items, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }

        //Get: ItemModel
        public JsonResult GetItemModel(string itemId)
        {
            List<ItemDetail> itemModeList=new List<ItemDetail>();
            using (db)
            {
                itemModeList = db.ItemDetail.Where(id => id.ItemId == itemId).DistinctBy(id=>id.Model).ToList();
            }
            return new JsonResult {Data= itemModeList,JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }
        //Get: ItemSize
        public JsonResult GetItemSize(string itemId)
        {
            var itemSizeList = new List<ItemDetail>();
            using (db)
            {
                itemSizeList = db.ItemDetail.Where(id => id.ItemId == itemId).DistinctBy(id=>id.Size).ToList();
            }
            return new JsonResult { Data = itemSizeList, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        //Get: ItemBrand
        public JsonResult GetItemBrand(string itemId)
        {
            var itemBrandList = new List<ItemDetail>();
            using (db)
            {
                itemBrandList = db.ItemDetail.Where(id => id.ItemId == itemId).DistinctBy(id=>id.Brand).ToList();
            }
            return new JsonResult { Data = itemBrandList, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        // GET: Items/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Item.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "Name");
            ViewBag.SubCategoryId = new SelectList(db.SubCategory, "SubCategoryId", "Name");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Item item)
        {
            item.QueryId = Guid.NewGuid();
            item.PostedBy = User.Identity.GetUserName();
            item.PostedIp = Request.UserHostAddress;
            item.PostedDate = DateTime.Now;
            item.UpdatedBy = User.Identity.GetUserName();
            item.UpdatedIp = Request.UserHostAddress;
            item.UpdatedDate = DateTime.Now;
            bool saved = aItemService.Save(item);
            if (saved)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(item);
            }
        }

        // GET: Items/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Item.FirstOrDefault(iId=>iId.QueryId==id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "Name", item.CategoryId);
            ViewBag.SubCategoryId = new SelectList(db.SubCategory, "SubCategoryId", "Name", item.SubCategoryId);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Name,Description,Priority,CategoryId,SubCategoryId,Code,PostedBy,PostedIp,PostedDate,UpdatedBy,UpdatedIp,UpdatedDate")] Item item)
        public ActionResult Edit(Item item)
        {
            //if (ModelState.IsValid)
            //{
            item.UpdatedBy = User.Identity.GetUserName();
            item.UpdatedIp = Request.UserHostAddress;
            item.UpdatedDate = DateTime.Now;
            db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            //}
            //ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "Name", item.CategoryId);
            //ViewBag.SubCategoryId = new SelectList(db.SubCategory, "SubCategoryId", "Name", item.SubCategoryId);
            //return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Item.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Item item = db.Item.Find(id);
            db.Item.Remove(item);
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

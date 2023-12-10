using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULABInventory.Model;

namespace ULABInventory.Service
{
    public class ItemDetailService
    {
        InventoryDbContext dbContext = new InventoryDbContext();
        public bool Save(ItemDetail itemDetail)
        {

            string itemDetailIdMax = dbContext.ItemDetail.Max(itemId => itemId.ItemDetailId);
            string itemDetailIdNo;
            if (itemDetailIdMax == null)
            {
                itemDetailIdNo = String.Format("ITMD-00001");
            }
            else
            {
                itemDetailIdNo = String.Format("ITMD-" + "{0:D5}", Convert.ToInt32(itemDetailIdMax.Substring(5)) + 1);
            }
            itemDetail.ItemDetailId = itemDetailIdNo;
            dbContext.ItemDetail.Add(itemDetail);
            dbContext.SaveChanges();
            return true;
        }
    }
}

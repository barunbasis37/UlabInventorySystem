using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULABInventory.Model;

namespace ULABInventory.Service
{
    public class ItemService
    {
        InventoryDbContext dbContext = new InventoryDbContext();
        public bool Save(Item item)
        {
            string itemIdMax = dbContext.Item.Max(itemId => itemId.ItemId);
            string itemIdNo;
            if (itemIdMax == null)
            {
                itemIdNo = String.Format("ITM-0001");
            }
            else
            {
                itemIdNo = String.Format("ITM-" + "{0:D4}", Convert.ToInt32(itemIdMax.Substring(4)) + 1);
            }
            item.ItemId = itemIdNo;
            dbContext.Item.Add(item);
            dbContext.SaveChanges();
            return true;
        }
    }
}

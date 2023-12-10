using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using ULABInventory.Model;


namespace ULABInventory.ViewModels
{
    public class ItemInfoVM : BaseVM
    {

        //public ItemInfoVM(Item aItem, ItemDetails aItemDetails):base(aItem)
        //{
        //    CategoryId = aItem.CategoryId;
        //    SubCategoryId = aItem.SubCategoryId;
        //    Model = aItemDetails.Model;
        //    Size = aItemDetails.Size;
        //    Brand = aItemDetails.Brand;
        //    Price = aItemDetails.Price;
        //    Details = aItemDetails.Details;
        //}

        //public ItemInfoVM()
        //{
            
        //}

        public Guid? ItemId { get; set; }
        //public string Description { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? SubCategoryId { get; set; }
        public string Model { get; set; }
        public string Size { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public string Details { get; set; }

    }
}

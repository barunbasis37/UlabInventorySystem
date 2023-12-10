using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULABInventory.Model;

namespace ULABInventory.ViewModels
{
    public class ItemDetailVM
    {
        //public ItemDetailVM(ItemDetail xItemDetail)
        //{
        //    Item_Detail_Id = xItemDetail.ItemDetailId;
        //    Item_Id = xItemDetail.ItemId;
        //    Item_Name = xItemDetail.Item.Name;
        //    Item_Description = xItemDetail.Item.Description;
        //    Item_Priority = xItemDetail.Item.Priority;
        //    Category = xItemDetail.Item.Category.Name;
        //    Subcategory = xItemDetail.Item.SubCategory.Name;
        //    Item_Model = xItemDetail.Model;
        //    Item_Size = xItemDetail.Size;
        //    Item_Brand = xItemDetail.Brand;
        //    Item_Price = xItemDetail.Price;
        //    Item_Details = xItemDetail.Details;
        //}
        [Key]
        public string Item_Detail_Id { get; set; }
        public string Item_Id { get; set; }
        public string Item_Name { get; set; }
        public string Item_Description { get; set; }
        public int Item_Priority { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public string Item_Model { get; set; }
        public string Item_Size { get; set; }
        public string Item_Brand { get; set; }
        public decimal Item_Price { get; set; }
        public string Item_Details { get; set; }
    }
}

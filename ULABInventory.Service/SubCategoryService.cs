using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULABInventory.Model;
using ULABInventory.ViewModels;

namespace ULABInventory.Service
{
    public class SubCategoryService
    {
        InventoryDbContext dbContext = new InventoryDbContext();

        //public List<CategoryVM> GetList()
        //{
        //    var categoryLists = dbContext.Category.OrderBy(cat => cat.Priority).ToList();
        //    var categoryVms = new List<CategoryVM>();
        //    foreach (Category aCategoryList in categoryLists)
        //    {
        //        CategoryVM aCategoryVm = new CategoryVM(aCategoryList);
        //        categoryVms.Add(aCategoryVm);
        //    }
        //    return categoryVms;
        //}

        public bool Save(SubCategory subcategory)
        {
            string subcategoryIdMax = dbContext.SubCategory.Max(catId => catId.SubCategoryId);
            string subcategoryIdNo;
            if (subcategoryIdMax == null)
            {
                subcategoryIdNo = String.Format("SCT-001");
            }
            else
            {
                subcategoryIdNo = String.Format("SCT-" + "{0:D3}", Convert.ToInt32(subcategoryIdMax.Substring(4)) + 1);
            }
            subcategory.SubCategoryId = subcategoryIdNo;
            dbContext.SubCategory.Add(subcategory);
            dbContext.SaveChanges();
            return true;
        }
    }
}

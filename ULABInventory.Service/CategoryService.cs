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
    public class CategoryService
    {
        InventoryDbContext dbContext = new InventoryDbContext();
        public List<CategoryVM> GetList()
        {
            var categoryLists = dbContext.Category.OrderBy(cat => cat.Priority).ToList();
            var categoryVms = new List<CategoryVM>();
            foreach (Category aCategoryList in categoryLists)
            {
                CategoryVM aCategoryVm = new CategoryVM(aCategoryList);
                categoryVms.Add(aCategoryVm);
            }
            return categoryVms;
        }
        public bool Save(Category category)
        {
            string categoryIdMax = dbContext.Category.Max(catId => catId.CategoryId);
            string categoryIdNo;
            if (categoryIdMax == null)
            {
                categoryIdNo = String.Format("CAT-01");
            }
            else
            {
                categoryIdNo = String.Format("CAT-" + "{0:D2}", Convert.ToInt32(categoryIdMax.Substring(4)) + 1);
            }
            category.CategoryId = categoryIdNo;
            dbContext.Category.Add(category);
            dbContext.SaveChanges();
            return true;
        }

        public bool Update(Category category)
        {
            dbContext.Entry(category).State = EntityState.Modified;
            dbContext.SaveChanges();
            return true;
        }

        
    }
}

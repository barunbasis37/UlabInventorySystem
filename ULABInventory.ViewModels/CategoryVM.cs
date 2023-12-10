using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULABInventory.Model;

namespace ULABInventory.ViewModels
{
    public class CategoryVM : BaseVM
    {
        public CategoryVM(Category category) : base(category)
        {
            CategoryId = category.CategoryId;
            Name = category.Name;
            Priority = category.Priority;
            Description = category.Description;
        }
        

        public string CategoryId { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public string Description { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULABInventory.Model;
using ULABInventory.ViewModels;

namespace ULABInventory.Service
{
    public class DepartmentService
    {
        InventoryDbContext dbContext = new InventoryDbContext();
        public List<DepartmentVM> GetList()
        {
            //db.department data
            //Pulls all data into Ram
            var list = dbContext.Department.OrderBy(x => x.Priority).ToList();
            //Convert This data into View data
            var departmentViewModel = new List<DepartmentVM>();
            foreach (Department department in list)
            {
                DepartmentVM aDepartmentVm = new DepartmentVM(department);
                departmentViewModel.Add(aDepartmentVm);
            }
            return departmentViewModel;

        }
    }
}

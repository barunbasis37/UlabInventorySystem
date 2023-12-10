using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULABInventory.Model;

namespace ULABInventory.ViewModels
{
    public class DepartmentVM : BaseVM
    {
        public DepartmentVM(Department xDepartment): base(xDepartment)
        {
            DepartmentId = xDepartment.DepartmentId;
            Name = xDepartment.Name;
            DepartmentShortCode = xDepartment.DepartmentId;
            //SchoolName = xDepartment.School.Name;
            Type = xDepartment.Type;
            Priority = xDepartment.Priority;
            Description = xDepartment.Description;
        }
        public string DepartmentId { get; set; }
        public string DepartmentShortCode { get; set; }
        public string Name { get; set; }
        public string SchoolName { get; set; }
        public string Type { get; set; }
        public int Priority { get; set; }
        public string Description { get; set; }
    }
}

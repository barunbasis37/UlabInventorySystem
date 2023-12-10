using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULABInventory.Model;

namespace ULABInventory.ViewModels
{
    public class SchoolVM : BaseVM
    {
        public SchoolVM(School xSchool) : base(xSchool)
        {
            SchoolId = xSchool.SchoolId;
            Name = xSchool.Name;
            QueryId = xSchool.QueryId;
            PriorityLevel = xSchool.PriorityLevel;
        }

        public string SchoolId { get; set; }
        public string Name { get; set; }
        public Guid QueryId { get; set; }
        public int PriorityLevel { get; set; }
    }
}

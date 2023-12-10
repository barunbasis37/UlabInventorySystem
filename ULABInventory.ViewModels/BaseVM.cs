using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULABInventory.Model;

namespace ULABInventory.ViewModels
{
    public class BaseVM
    {
        public BaseVM()
        {
            
        }

        public BaseVM(Entity entity)
        {
            //Id = entity.Id;
            Code = entity.QueryId;
            PostedBy = entity.PostedBy;
            PostedIp = entity.PostedIp;
            PostedDate = entity.PostedDate;
            UpdatedBy = entity.UpdatedBy;
            UpdatedIp = entity.UpdatedIp;
            UpdatedDate = entity.UpdatedDate;

        }
        //public Guid? Id { get; set; }
        public Guid Code { get; set; }
        public string PostedBy { get; set; }
        public string PostedIp { get; set; }
        public DateTime? PostedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedIp { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}

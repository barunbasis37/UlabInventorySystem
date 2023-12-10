using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULABInventory.Model;


namespace ULABInventory.Service
{
    public class CampusService
    {
        InventoryDbContext dbContext = new InventoryDbContext();
        public bool Save(Campus campus)
        {
            string campusIdMax = dbContext.Campus.Max(cId => cId.CampusId);
            string campusIdNo;
            if (campusIdMax == null)
            {
                campusIdNo = String.Format("CAM-01");
            }
            else
            {
                campusIdNo = String.Format("CAM-" + "{0:D2}", Convert.ToInt32(campusIdMax.Substring(4)) + 1);
            }
            campus.CampusId = campusIdNo;
            campus.QueryId = Guid.NewGuid();
            campus.PostedDate = DateTime.Now;
            campus.UpdatedDate = DateTime.Now;

            Campus add = dbContext.Campus.Add(campus);
            dbContext.SaveChanges();
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULABInventory.Model;

namespace ULABInventory.Service
{
    public class SupplierService
    {
        InventoryDbContext dbContext = new InventoryDbContext();

        public bool Save(Supplier supplier)
        {
            string supplierIdMax = dbContext.Supplier.Max(supId => supId.SupplierId);
            string suplierIdNo=null;
            if (supplierIdMax == null)
            {
                suplierIdNo = String.Format("SP-001");
            }
            else
            {
                suplierIdNo = String.Format("SP-" + "{0:D3}", Convert.ToInt32(supplierIdMax.Substring(3)) + 1);
            }
            supplier.SupplierId = suplierIdNo;
            dbContext.Supplier.Add(supplier);
            dbContext.SaveChanges();
            return true;
        }
    }
}

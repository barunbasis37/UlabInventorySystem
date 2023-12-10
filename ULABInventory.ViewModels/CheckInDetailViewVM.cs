using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULABInventory.ViewModels
{
    public class CheckInDetailViewVM
    {
        public string CheckIn_Detail_Id { get; set; }
        public string CheckIn_Id { get; set; }
        public string Invoice_No { get; set; }
        public DateTime Purchase_Date { get; set; }
        public decimal Total_Bill { get; set; }
        public string Current_Status { get; set; }
        public string Receipt_No { get; set; }
        public string Audit_Code { get; set; }
        public string Category_Name { get; set; }
        public string Supplier_Name { get; set; }
        public string Item_Size { get; set; }
        public string Item_Model { get; set; }
        public string Item_Brand { get; set; }
        public decimal Item_Price { get; set; }
        public DateTime Warranty_Expire_Date { get; set; }
        public string Product_Serial_No { get; set; }
        public string Cpu_Id { get; set; }
        public string Device_Id { get; set; }
        public string QRImgPath { get; set; }
    }
}

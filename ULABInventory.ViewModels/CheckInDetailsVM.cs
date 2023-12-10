using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULABInventory.Model;

namespace ULABInventory.ViewModels
{
    public class CheckInDetailsVM
    {
        //public string WarrentyDateString { get; set; }
        //public string PurchaseDateString { get; set; }
        //public string CheckInId { get; set; }

        public CheckInDetailsVM(CheckInDetail aCheckInDetails)
        {
            //CheckInDetailsId = aCheckInDetails.Id;
            InvoiceNo = aCheckInDetails.CheckIn.InvoiceNo;
            AuditCode = aCheckInDetails.AuditCode;
            CheckInDetailId = aCheckInDetails.CheckInDetailId;
            CpuCode = aCheckInDetails.CpuId;
            DeviceCode = aCheckInDetails.DeviceId;
            ItemCName = aCheckInDetails.ItemDetail.Item.Name;
            ItemDetailsId = aCheckInDetails.ItemDetailsId;
            ItemBrand = aCheckInDetails.ItemDetail.Brand;
            ItemModel = aCheckInDetails.ItemDetail.Model;
            ItemSize = aCheckInDetails.ItemDetail.Size;
            Unitprice = aCheckInDetails.Unitprice;
            WarrantyExpireDate = aCheckInDetails.WarrantyExpireDate;
            ProductSerialNo = aCheckInDetails.ProductSerialNo;
            ItemStatus = aCheckInDetails.ItemStatus;
            CurrentStatus = aCheckInDetails.CurrentStatus;
            Remarks = aCheckInDetails.Remarks;
            QRCodeImgPath = aCheckInDetails.QRCodeImgPath;
        }
        //public Guid CheckInDetailsId { get; set; }
        public string InvoiceNo { get; set; }
        public string AuditCode { get; set; }
        public string CheckInDetailId { get; set; }
        public string CpuCode { get; set; }
        public string DeviceCode { get; set; }
        public string ItemCName{ get; set; }
        public string ItemDetailsId { get; set; }
        public string ItemModel { get; set; }
        public string ItemSize { get; set; }
        public string ItemBrand { get; set; }
        public decimal Unitprice { get; set; }
        public DateTime WarrantyExpireDate { get; set; }
        public string ProductSerialNo { get; set; }
        public string ItemStatus { get; set; }
        public string CurrentStatus { get; set; }
        public string Remarks { get; set; }

        public string DeviceCpuValue= "CPU-00000";
        public string QRCodeImgPath { get; set; }
        

    }
}

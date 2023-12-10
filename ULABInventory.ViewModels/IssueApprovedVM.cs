using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULABInventory.Model;

namespace ULABInventory.ViewModels
{
    public class IssueApprovedVM
    {
        public IssueApprovedVM(IssueApproved aIssueApproved)
        {
            IssueApprovedId = aIssueApproved.IssueApprovedId;
            RequisitionDId = aIssueApproved.RequisitionDId;
            EmployeeId = aIssueApproved.RequisitionDetail.Requisition.EmployeeId;
            EmployeeName = aIssueApproved.RequisitionDetail.Requisition.Employees.Name;
            EmpDepartment = aIssueApproved.RequisitionDetail.Requisition.Employees.Department.Name;
            Campus = aIssueApproved.RequisitionDetail.Requisition.Campus.Name;
            Floor = aIssueApproved.RequisitionDetail.Requisition.FloorNo;
            Room = aIssueApproved.RequisitionDetail.Requisition.RoomNo;
            IsApproved = aIssueApproved.RequisitionDetail.IsApproved;
            IssueTypeName = aIssueApproved.RequisitionDetail.Requisition.IssueType.Name;
            CpuId = aIssueApproved.RequisitionDetail.CheckInDetail.CpuId;
            DeviceId = aIssueApproved.RequisitionDetail.CheckInDetail.DeviceId;
            CheckInDetailId = aIssueApproved.RequisitionDetail.CheckInDetailIdCode;
            CurrentStatus = aIssueApproved.CurrentStatus;
            ReturnRemarks = aIssueApproved.ReturnRemarks;
            IssueDate = aIssueApproved.RequisitionDetail.IssuedDateTime;
            ReturnDate = aIssueApproved.ReturnDate;
            ReturnRemarks = aIssueApproved.ReturnRemarks;
            ItemName = aIssueApproved.RequisitionDetail.CheckInDetail.Item.Name;
            ItemCategory = aIssueApproved.RequisitionDetail.CheckInDetail.Item.Category.Name;
            ItemSubcategory = aIssueApproved.RequisitionDetail.CheckInDetail.Item.SubCategory.Name;
            ItemModel = aIssueApproved.RequisitionDetail.CheckInDetail.ItemDetail.Model;
            ItemSize = aIssueApproved.RequisitionDetail.CheckInDetail.ItemDetail.Size;
            ItemBrand = aIssueApproved.RequisitionDetail.CheckInDetail.ItemDetail.Brand;

        }


        public string IssueApprovedId { get; set; }
        public string RequisitionDId { get; set; }
        public string CurrentStatus { get; set; }
        
        public string ReturnRemarks { get; set; }
        
        public string ReturnBy { get; set; }
        
        public string ReturnIp { get; set; }
       
        public DateTime ReturnDate { get; set; }
        
        public string GarbageDescription { get; set; }
        
        public string GarbageBy { get; set; }
       
        public string GarbageIp { get; set; }
        
        public DateTime GarbageDate { get; set; }
       
        public string WarrantyReason { get; set; }
       
        public string WarrantyBy { get; set; }
        
        public string WarrantyIp { get; set; }
        
        public DateTime WarrantyDate { get; set; }
        public DateTime IssueDate { get; set; }

        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmpDepartment { get; set; }
        public string Campus { get; set; }
        public string Floor { get; set; }
        public string Room { get; set; }
        public bool IsApproved { get; set; }
        public string IssueTypeName { get; set; }
        public string CpuId { get; set; }
        public string DeviceId { get; set; }
        public string CheckInDetailId { get; set; }
        public string ItemName { get; set; }
        public string ItemCategory { get; set; }
        public string ItemSubcategory { get; set; }
        public string ItemModel { get; set; }
        public string ItemSize { get; set; }
        public string ItemBrand { get; set; }


    }
}

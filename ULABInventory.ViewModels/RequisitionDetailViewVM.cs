using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULABInventory.Model;

namespace ULABInventory.ViewModels
{
    public class RequisitionDetailViewVM
    {
        public RequisitionDetailViewVM(RequisitionDetail aRequisitionDetail)
        {
            RequisitionDId = aRequisitionDetail.RequisitionDetailId;
            QueryId = aRequisitionDetail.QueryId;
            Requisition = aRequisitionDetail.RequisitionId;
            RequisitionType = aRequisitionDetail.Requisition.IssueType.Name;
            EmployeeId = aRequisitionDetail.Requisition.Employees.EmployeeId;
            EmployeeName = aRequisitionDetail.Requisition.Employees.Name;
            Department = aRequisitionDetail.Requisition.Employees.Department.Name;
            Campus = aRequisitionDetail.Requisition.Campus.Name;
            Floor = aRequisitionDetail.Requisition.FloorNo;
            Room = aRequisitionDetail.Requisition.RoomNo;
            CheckInDId = aRequisitionDetail.CheckInDetailIdCode;
            SCPUId = aRequisitionDetail.CheckInDetail.CpuId;
            DeviceId = aRequisitionDetail.CheckInDetail.DeviceId;
            Item = aRequisitionDetail.CheckInDetail.Item.Name;
            Model = aRequisitionDetail.CheckInDetail.ItemDetail.Model;
            Size = aRequisitionDetail.CheckInDetail.ItemDetail.Size;
            Brand = aRequisitionDetail.CheckInDetail.ItemDetail.Brand;
            Category = aRequisitionDetail.CheckInDetail.Item.Category.Name;
            Subcategory = aRequisitionDetail.CheckInDetail.Item.SubCategory.Name;
            RequestRemarks = aRequisitionDetail.RequestRemarks;
            IsApproved = aRequisitionDetail.IsApproved;
            ApprovedBy = aRequisitionDetail.ApprovedBy;
            ApprovedDate = aRequisitionDetail.ApprovedDateTime;
            ApprovedIp = aRequisitionDetail.ApprovedIP;
            ApproveRemarks = aRequisitionDetail.ApproveRemarks;
            IsIssued = aRequisitionDetail.IsIssued;
            IssuedBy = aRequisitionDetail.IssuedBy;
            IssuedDate = aRequisitionDetail.IssuedDateTime;
            IssuedIp = aRequisitionDetail.IssuedIP;
            IsDenied = aRequisitionDetail.IsDenied;
            DeniedBy = aRequisitionDetail.DeniedBy;
            DeniedDate = aRequisitionDetail.DeniedDateTime;
            DeniedIp = aRequisitionDetail.DeniedIP;
        }
        public string RequisitionDId { get; set; }
        public Guid QueryId { get; set; }
        public string Requisition { get; set; }
        public string RequisitionType { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public string Campus { get; set; }
        public string Floor { get; set; }
        public string Room { get; set; }
        public string CheckInDId { get; set; }
        public string DeviceId { get; set; }
        public string SCPUId { get; set; }
        public string Item { get; set; }
        public string Model { get; set; }
        public string Size { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public string RequestRemarks { get; set; }
        public bool IsApproved { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime ApprovedDate { get; set; }
        public string ApprovedIp { get; set; }
        public string ApproveRemarks { get; set; }
        public bool IsIssued { get; set; }
        public string IssuedBy { get; set; }
        public DateTime IssuedDate { get; set; }
        public string IssuedIp { get; set; }
        public bool IsDenied { get; set; }
        public string DeniedBy { get; set; }
        public DateTime DeniedDate { get; set; }
        public string DeniedIp { get; set; }
    }
}

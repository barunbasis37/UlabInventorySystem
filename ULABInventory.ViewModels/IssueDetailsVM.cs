using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULABInventory.Model;

namespace ULABInventory.ViewModels
{
    public class IssueDetailsVM
    {
        public IssueDetailsVM(IssueDetail aIssueDetail)
        {
            IssueDetailId = aIssueDetail.IssueDetailId;
            IssueId = aIssueDetail.Issue.IssueId;
            EmployeeId = aIssueDetail.Issue.EmployeeId;
            EmployeeName = aIssueDetail.Issue.Employee.Name;
            EmpDepartment = aIssueDetail.Issue.Employee.Department.Name;
            IsApproved = aIssueDetail.Issue.IsApproved;
            IssueTypeName = aIssueDetail.Issue.IssueType.Name;
            CpuId = aIssueDetail.CheckInDetail.CpuId;
            DeviceId = aIssueDetail.CheckInDetail.DeviceId;
            CheckInDetailId = aIssueDetail.CheckInDetailId;
            AgainstDeviceCode = aIssueDetail.AgainstDeviceCode;
            CurrentStatus = aIssueDetail.CurrentStatus;
            DeviceReturnRemarks = aIssueDetail.DeviceReturnRemarks;
            IssueDate = aIssueDetail.IssueDate;
            ReturnDate = aIssueDetail.ReturnDate;
            ReturnComment = aIssueDetail.ReturnComment;
            ItemName = aIssueDetail.CheckInDetail.Item.Name;
            ItemCategory = aIssueDetail.CheckInDetail.Item.Category.Name;
            ItemSubcategory = aIssueDetail.CheckInDetail.Item.SubCategory.Name;
            ItemModel = aIssueDetail.CheckInDetail.ItemDetail.Model;
            ItemSize = aIssueDetail.CheckInDetail.ItemDetail.Size;
            ItemBrand = aIssueDetail.CheckInDetail.ItemDetail.Brand;

        }
        public string IssueDetailId { get; set; }
        public string IssueId { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmpDepartment { get; set; }
        public bool IsApproved { get; set; }
        public string IssueTypeName { get; set; }
        public string CpuId { get; set; }
        public string DeviceId { get; set; }
        public string CheckInDetailId { get; set; }
        public string AgainstDeviceCode { get; set; }
        public string CurrentStatus { get; set; }
        public string DeviceReturnRemarks { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string ReturnComment { get; set; }

        public string ItemName { get; set; }
        public string ItemCategory { get; set; }
        public string ItemSubcategory { get; set; }
        public string ItemModel { get; set; }
        public string ItemSize { get; set; }
        public string ItemBrand { get; set; }


    }
}

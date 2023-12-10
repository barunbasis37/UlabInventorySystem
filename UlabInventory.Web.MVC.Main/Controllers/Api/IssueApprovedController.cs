using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ULABInventory.Model;
using ULABInventory.ViewModels;

namespace UlabInventory.Web.MVC.Main.Controllers.Api
{
    [Authorize]
    public class IssueApprovedController : ApiController
    {
        public InventoryDbContext _dbContext { get; set; }
        public IssueApprovedController()
        {
            _dbContext = new InventoryDbContext();
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public IHttpActionResult GetIssueApprovedItemList()
        {
            IssueApprovedVM aIssueApprovedItemVM = null;
            IssueItemStage aIssueItemStage = new IssueItemStage();

            using (_dbContext)
            {
                IQueryable<IssueApproved> issueAppItemList = _dbContext.IssueApproveds.Where(aIssueApp => aIssueApp.CurrentStatus== aIssueItemStage.Issued).Include(issApp => issApp.RequisitionDetail.Requisition).Include(issApp => issApp.RequisitionDetail.Requisition.Campus).Include(issApp => issApp.RequisitionDetail.CheckInDetail.Item).Include(issApp => issApp.RequisitionDetail.CheckInDetail.Item.Category).Include(issApp => issApp.RequisitionDetail.CheckInDetail.Item.SubCategory).Include(issApp => issApp.RequisitionDetail.CheckInDetail.ItemDetail).Include(issApp => issApp.RequisitionDetail.Requisition.IssueType).Include(issApp => issApp.RequisitionDetail.Requisition.Employees.Department);

                var issueApprovedItemLists = issueAppItemList.AsEnumerable().Select(x => new IssueApprovedVM(x)).ToList();

                return Ok(issueApprovedItemLists);
            }
        }
        //[HttpGet]
        ////[Authorize(Roles = "Admin")]
        //public IHttpActionResult GetApprovedItemList()
        //{
        //    RequisitionDetailViewVM aRequisitionDetailsVM = null;

        //    using (_dbContext)
        //    {
        //        IQueryable<RequisitionDetail> issueDetailList = _dbContext.RequisitionDetail.Where(aRequisitionD => aRequisitionD.IsDenied == false && aRequisitionD.IsApproved == true && aRequisitionD.IsIssued == false).Include(isD => isD.Requisition).Include(isD => isD.Requisition.Campus).Include(isD => isD.CheckInDetail.Item).Include(isD => isD.CheckInDetail.Item.Category).Include(isD => isD.CheckInDetail.Item.SubCategory).Include(isD => isD.CheckInDetail.ItemDetail).Include(isD => isD.Requisition.IssueType).Include(isD => isD.Requisition.Employees.Department);

        //        var issueItemLists = issueDetailList.AsEnumerable().Select(x => new RequisitionDetailViewVM(x)).ToList();

        //        return Ok(issueItemLists);
        //    }
        //}

    }
}

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
    public class RequisitionController : ApiController
    {
        public InventoryDbContext _dbContext { get; set; }
        public RequisitionController()
        {
            _dbContext = new InventoryDbContext();
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public IHttpActionResult GetRequisitionItemList()
        {
            RequisitionDetailViewVM aRequisitionDetailsVM = null;

            using (_dbContext)
            {
                IQueryable<RequisitionDetail> issueDetailList = _dbContext.RequisitionDetail.Where(aRequisitionD => aRequisitionD.IsDenied==false && aRequisitionD.IsApproved == false && aRequisitionD.IsIssued == false).Include(isD => isD.Requisition).Include(isD => isD.Requisition.Campus).Include(isD => isD.CheckInDetail.Item).Include(isD => isD.CheckInDetail.Item.Category).Include(isD => isD.CheckInDetail.Item.SubCategory).Include(isD => isD.CheckInDetail.ItemDetail).Include(isD => isD.Requisition.IssueType).Include(isD => isD.Requisition.Employees.Department);

                var issueItemLists = issueDetailList.AsEnumerable().Select(x => new RequisitionDetailViewVM(x)).ToList();

                return Ok(issueItemLists);
            }
        }
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public IHttpActionResult GetApprovedItemList()
        {
            RequisitionDetailViewVM aRequisitionDetailsVM = null;

            using (_dbContext)
            {
                IQueryable<RequisitionDetail> issueDetailList = _dbContext.RequisitionDetail.Where(aRequisitionD => aRequisitionD.IsDenied == false && aRequisitionD.IsApproved == true && aRequisitionD.IsIssued == false).Include(isD => isD.Requisition).Include(isD => isD.Requisition.Campus).Include(isD => isD.CheckInDetail.Item).Include(isD => isD.CheckInDetail.Item.Category).Include(isD => isD.CheckInDetail.Item.SubCategory).Include(isD => isD.CheckInDetail.ItemDetail).Include(isD => isD.Requisition.IssueType).Include(isD => isD.Requisition.Employees.Department);

                var issueItemLists = issueDetailList.AsEnumerable().Select(x => new RequisitionDetailViewVM(x)).ToList();

                return Ok(issueItemLists);
            }
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public IHttpActionResult GetRequisitionItemStatus()
        {
            RequisitionDetailViewVM aRequisitionDetailsVM = null;

            using (_dbContext)
            {
                IQueryable<RequisitionDetail> issueDetailList = _dbContext.RequisitionDetail.Include(isD => isD.Requisition).Include(isD => isD.Requisition.Campus).Include(isD => isD.CheckInDetail.Item).Include(isD => isD.CheckInDetail.Item.Category).Include(isD => isD.CheckInDetail.Item.SubCategory).Include(isD => isD.CheckInDetail.ItemDetail).Include(isD => isD.Requisition.IssueType).Include(isD => isD.Requisition.Employees.Department);

                var issueItemLists = issueDetailList.AsEnumerable().Select(x => new RequisitionDetailViewVM(x)).ToList();

                return Ok(issueItemLists);
            }
        }

    }
}

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
    public class IssueController : ApiController
    {
        public InventoryDbContext _dbContext { get; set; }
        public IssueController()
        {
            _dbContext = new InventoryDbContext();
        }

        [HttpGet]
        //[Authorize(Roles = "Admin, CSOAdmin")]
        public IHttpActionResult GetIssueItemList()
        {
            IssueDetailsVM aIssueDetailsVM = null;

            using (_dbContext)
            {
                IQueryable<IssueDetail> issueDetailList = _dbContext.IssueDetail.Where(aIssueD => aIssueD.CurrentStatus == "Issued");

                var issueItemLists = issueDetailList.Include(isD => isD.Issue).Include(isD => isD.CheckInDetail.Item).Include(isD => isD.CheckInDetail.Item.Category).Include(isD => isD.CheckInDetail.Item.SubCategory).Include(isD => isD.CheckInDetail.ItemDetail).Include(isD=>isD.Issue.IssueType).Include(isD => isD.Issue.Employee.Department).AsEnumerable().Select(x => new IssueDetailsVM(x)).ToList();

                return Ok(issueItemLists);
            }
        }



    }
}

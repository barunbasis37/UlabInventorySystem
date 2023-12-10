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
    public class CheckInDetailsController : ApiController
    {
        public InventoryDbContext _dbContext { get; set; }

        public CheckInDetailsController()
        {
            _dbContext = new InventoryDbContext();
        }

        [AllowAnonymous]
        public IHttpActionResult GetAuditCode(string query = null)
        {
            IQueryable<CheckInDetail> auditCodeQuery = _dbContext.CheckInDetail;

            if (!String.IsNullOrWhiteSpace(query))
            {
                auditCodeQuery = auditCodeQuery.Where(c => c.AuditCode.Contains(query));
            }

            var customerDtos = auditCodeQuery.ToList();


            return Ok(customerDtos);
        }




        public IHttpActionResult GetDeviceDetails(string statusSelectedValue)
        {
            CheckInDetailsVM aCheckInDetailsVm = null;
            
            using (_dbContext)
            {
                IQueryable<CheckInDetail> checkInDetailsQuery=null;
                if (statusSelectedValue == "Device")
                {
                    checkInDetailsQuery = _dbContext.CheckInDetail.Include(ck => ck.CheckIn).Include(ck => ck.ItemDetail).Include(ck => ck.ItemDetail.Item).Where(ck => ck.CurrentStatus == "Available" && ck.CpuId.Contains("SPU")).OrderBy(x => x.CpuId);
                }
                else
                {
                    checkInDetailsQuery = _dbContext.CheckInDetail.Include(ck => ck.CheckIn).Include(ck => ck.ItemDetail).Include(ck => ck.ItemDetail.Item).Where(ck => ck.CurrentStatus == "Available" && ck.CpuId.Contains("CPU")).OrderBy(x => x.CpuId);
                }
                var chk= checkInDetailsQuery.AsEnumerable().Select(x => new CheckInDetailsVM(x)).ToList();
                

                return Ok(chk);
            }
            
        }
    }
}

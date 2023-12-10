using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ULABInventory.Model;

namespace UlabInventory.Web.MVC.Main.Controllers.Api
{
    [Authorize]
    public class ItemController : ApiController
    {
        public InventoryDbContext _dbContext { get; set; }
        public ItemController()
        {
            _dbContext=new InventoryDbContext();
        }
        public IHttpActionResult GetItems(string query = null)
        {
            IQueryable<Item> itemQuery = _dbContext.Item;

            if (!String.IsNullOrWhiteSpace(query))
            {
                itemQuery = itemQuery.Where(c => c.Name.Contains(query));
            }

            var customerDtos = itemQuery.ToList();
                

            return Ok(customerDtos);
        }
       

    }
}

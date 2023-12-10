using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULABInventory.ViewModels;

namespace ULABInventory.Repository
{
    public class RequisitionDetailRepository
    {
        public SqlConnection con;
        //To Handle connection related activities
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            con = new SqlConnection(constr);
        }

        //To view ItemDetail with generic list 
        public List<RequisitionDetailViewVM> GetAllRequisitionDetail()
        {
            try
            {
                connection();
                con.Open();
                IList<RequisitionDetailViewVM> RequestDetailList = SqlMapper.Query<RequisitionDetailViewVM>(
                                  con, "spRequisitionDetail").ToList();
                con.Close();
                return RequestDetailList.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
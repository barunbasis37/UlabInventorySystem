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
    public class IssueDetailRepository
    {
        public SqlConnection con;
        //To Handle connection related activities
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            con = new SqlConnection(constr);
        }

        //To view ItemDetail with generic list 
        public List<IssueDetailViewVM> GetAllIssueDetail()
        {
            try
            {
                connection();
                con.Open();
                IList<IssueDetailViewVM> IssueDetailList = SqlMapper.Query<IssueDetailViewVM>(
                                  con, "spIssueDetail").ToList();
                con.Close();
                return IssueDetailList.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
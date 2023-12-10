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
    public class CheckInDetailRepository
    {
        public SqlConnection con;
        //To Handle connection related activities
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            con = new SqlConnection(constr);
        }

        //To view ItemDetail with generic list 
        public List<CheckInDetailViewVM> GetAllCheckInDetail()
        {
            try
            {
                connection();
                con.Open();
                IList<CheckInDetailViewVM> CheckInDetailList = SqlMapper.Query<CheckInDetailViewVM>(
                                  con, "spQRImageCheckInDetail").ToList();
                con.Close();
                return CheckInDetailList.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
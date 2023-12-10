using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ULABInventory.Model;
using ULABInventory.ViewModels;

namespace ULABInventory.Repository
{
    public class EmployeeRepository
    {
    
        public SqlConnection con;
        //To Handle connection related activities
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            con = new SqlConnection(constr);
        }
        //To Add Employee details
        //public void AddEmployee(Employee objEmp)
        //{
        //    //Additing the employess
        //    try
        //    {
        //        connection();
        //        con.Open();
        //        con.Execute("spEmployee", objEmp, commandType: CommandType.StoredProcedure);
        //        con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //To view employee details with generic list 
        public List<EmployeeVM> GetAllEmployees()
        {
            try
            {
                connection();
                con.Open();
                IList<EmployeeVM> EmpList = SqlMapper.Query<EmployeeVM>(
                                  con, "spEmployee").ToList();
                con.Close();
                return EmpList.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        //To Update Employee details
        //public void UpdateEmployee(EmpModel objUpdate)
        //{
        //    try
        //    {
        //        connection();
        //        con.Open();
        //        con.Execute("UpdateEmpDetails", objUpdate, commandType: CommandType.StoredProcedure);
        //        con.Close();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        //To delete Employee details
        //public bool DeleteEmployee(int Id)
        //{
        //    try
        //    {
        //        DynamicParameters param = new DynamicParameters();
        //        param.Add("@EmpId", Id);
        //        connection();
        //        con.Open();
        //        con.Execute("DeleteEmpById", param, commandType: CommandType.StoredProcedure);
        //        con.Close();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        //Log error as per your need 
        //        throw ex;
        //    }
        //}
    }
}
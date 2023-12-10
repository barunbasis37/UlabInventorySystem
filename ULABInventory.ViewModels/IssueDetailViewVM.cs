using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULABInventory.ViewModels
{
    public class IssueDetailViewVM
    {
        public string Issue_Detail_Id { get; set; }
        public string Issue_Id { get; set; }
        public string Issue_Type_Name { get; set; }
        public string Employee_Id { get; set; }
        public string Employee_Name { get; set; }
        public string Dept_Name { get; set; }
        public string Campus_Name { get; set; }
        public string Floor_No { get; set; }
        public string Room_No { get; set; }
        public string Issue_Remark { get; set; }
        public string Return_Remark { get; set; }
        public bool Is_Approved { get; set; }
        public string Approved_Id { get; set; }
        public DateTime Approved_Date { get; set; }
        public string CheckIn_Detail_Id { get; set; }
        public string Current_Status { get; set; }
        public string Device_Return_Remarks { get; set; }
        public DateTime Issue_Date { get; set; }
        public DateTime Return_Date { get; set; }
        public string Return_Comment { get; set; }


    }
}

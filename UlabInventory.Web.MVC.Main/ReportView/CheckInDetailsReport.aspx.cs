using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using ULABInventory.Model;
using ULABInventory.Repository;
using ULABInventory.ViewModels;

namespace UlabInventory.Web.MVC.Main.ReportView
{
    public partial class CheckInDetailsReport : System.Web.UI.Page
    {
        private InventoryDbContext dc = new InventoryDbContext();
        private CheckInDetailRepository aCheckInDetailRepo = new CheckInDetailRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                using (dc)
            {
                List<CheckInDetailViewVM> cm = new List<CheckInDetailViewVM>();
                cm = aCheckInDetailRepo.GetAllCheckInDetail();
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/rptCheckInDetail.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rdc = new ReportDataSource("CheckInDetailDS", cm);
                ReportViewer1.LocalReport.DataSources.Add(rdc);
                ReportViewer1.LocalReport.Refresh();
            }
            }
        }
    }
}
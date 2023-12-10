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
    public partial class IssueDetailsReport : System.Web.UI.Page
    {
        private InventoryDbContext dc = new InventoryDbContext();
        private IssueDetailRepository aIssueDetailRepository = new IssueDetailRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                using (dc)
                {
                    List<IssueDetailViewVM> issueDetailView = new List<IssueDetailViewVM>();
                    issueDetailView = aIssueDetailRepository.GetAllIssueDetail();
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/rptIssueDetail.rdlc");
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportDataSource rdc = new ReportDataSource("IssueDetailDS", issueDetailView);
                    ReportViewer1.LocalReport.DataSources.Add(rdc);
                    ReportViewer1.LocalReport.Refresh();
                }
            }
        }
    }
}
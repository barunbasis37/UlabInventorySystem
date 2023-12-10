using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ULABInventory.Model;
using ULABInventory.Repository;
using ULABInventory.ViewModels;
using UlabInventory.Web.MVC.Main.Reports;

namespace UlabInventory.Web.MVC.Main.ReportView
{
    public partial class QRImgChkInDReportCrystal : System.Web.UI.Page
    {
        private InventoryDbContext dc = new InventoryDbContext();
        private CheckInDetailRepository aCheckInDetailRepo = new CheckInDetailRepository();
        protected void Page_Load(object sender, EventArgs e)
        {


            //CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
            //CheckInDetailsQRRpt crystalReport = new CheckInDetailsQRRpt();
            //NorthwindEntities entities = new NorthwindEntities();
            //crystalReport.SetDataSource(from customer in entities.Customers.Take(10)
            //    select customer);
            //CrystalReportViewer1.ReportSource = crystalReport;
            //CrystalReportViewer1.RefreshReport();

            //if (!IsPostBack)
            //{

                using (dc)
                {
                    List<CheckInDetailViewVM> cm = new List<CheckInDetailViewVM>();
                    cm = aCheckInDetailRepo.GetAllCheckInDetail();
                    CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
                    qrImgReport crystalReport = new qrImgReport();
                    crystalReport.SetDataSource(cm);
                    CrystalReportViewer1.ReportSource = crystalReport;
                    CrystalReportViewer1.RefreshReport();
                }
            //}
            
        }
    }
}





//private InventoryDbContext dc = new InventoryDbContext();
//private CheckInDetailRepository aCheckInDetailRepo = new CheckInDetailRepository();
//protected void Page_Load(object sender, EventArgs e)
//{
//    if (!IsPostBack)
//    {

//        using (dc)
//        {
//            ReportDocument crystalReport = new ReportDocument();
//            //ReportDocument reportDocument = new ReportDocument();
//            crystalReport.Load(Path.Combine(Server.MapPath("~/Reports"), "CheckInDetailsQRRpt.rpt"));
//            List<CheckInDetailViewVM> checkInDlist = new List<CheckInDetailViewVM>();
//            checkInDlist = aCheckInDetailRepo.GetAllCheckInDetail();
//            ReportDataSource rd = new ReportDataSource("rptQRImageCheckInD", checkInDlist);

//            CrystalReportViewer1.ReportSource = rd;
//            //crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat,Response, "QRImgCheckInDetails");
//            CrystalReportViewer1.RefreshReport();



//            //CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
//            //CheckInDetailsQRRpt crystalReport1 = new CheckInDetailsQRRpt();
//            //NorthwindEntities entities = new NorthwindEntities();
//            //crystalReport.SetDataSource(from customer in entities.Customers.Take(10)
//            //    select customer);
//            //CrystalReportViewer1.ReportSource = crystalReport;
//            //CrystalReportViewer1.RefreshReport();
//        }
//    }

//}
using System.Web.Optimization;

namespace IdentitySample
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                         "~/Scripts/bootstrap.js",
                        "~/Scripts/bootbox.js",
                        "~/Scripts/jquery-ui-{version}.js",
                        "~/App/dropdowncontroller.js",
                        "~/App/autocomplete.js",
                        "~/scripts/DataTables/jquery.dataTables.js",
                      "~/scripts/DataTables/dataTables.bootstrap.js",
                        "~/Scripts/toastr.js",
                        "~/Scripts/typeahead.bundle.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-cerulean.css",
                      "~/Content/CustomSiteStyle.css",
                      "~/Content/toastr.css",
                      "~/Content/DataTables/CSS/dataTables.bootstrap.css",
                      "~/Content/typeahead.css",
                      "~/Content/site.css"));
            //css  
            bundles.Add(new StyleBundle("~/Content/cssjqryUi").Include(
                   "~/Content/jquery-ui.css"));
        }
    }
}

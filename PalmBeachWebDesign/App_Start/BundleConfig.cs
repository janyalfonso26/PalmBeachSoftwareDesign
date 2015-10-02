using System.Web;
using System.Web.Optimization;

namespace PalmBeachWebDesign
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/BlockUI.js",
                        "~/Scripts/bootbox.js",
                         "~/Scripts/toastr.min.js",
                       "~/Scripts/utilities.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/toastr.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/jqxGrid").Include(
                       "~/Scripts/jqwidgets/jqxcore.js",
                       "~/Scripts/jqwidgets/jqxdata.js",
                       "~/Scripts/jqwidgets/jqxgrid.js",
                       "~/Scripts/jqwidgets/jqxgrid.pager.js",
                       "~/Scripts/jqwidgets/jqxgrid.sort.js",
                       "~/Scripts/jqwidgets/jqxgrid.filter.js",
                       "~/Scripts/jqwidgets/jqxgrid.columnsresize.js",
                       "~/Scripts/jqwidgets/jqxgrid.selection.js",
                       "~/Scripts/jqwidgets/jqxdata.export.js",
                       "~/Scripts/jqwidgets/jqxgrid.export.js",
                       "~/Scripts/jqwidgets/jqxmenu.js",
                       "~/Scripts/jqwidgets/jqxbuttons.js",
                       "~/Scripts/jqwidgets/jqxscrollbar.js",
                       "~/Scripts/jqwidgets/jqxlistbox.js",
                       "~/Scripts/jqwidgets/jqxdropdownlist.js",
                       "~/Scripts/jqwidgets/jqxpanel.js",
                       "~/Scripts/jqwidgets/globalization/globalize.js"));

            bundles.Add(new StyleBundle("~/Content/jqxGrid").Include(
                          "~/Scripts/jqwidgets/styles/jqx.base.css",
                          "~/Scripts/jqwidgets/styles/jqx.energyblue.css"));
        }
    }
}

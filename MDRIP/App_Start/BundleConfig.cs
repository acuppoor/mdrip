using System.Web;
using System.Web.Optimization;

namespace MDRIP
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/newbootstrap").Include(
                "~/Scripts/script/popper.min.js",
                "~/Scripts/script/bootstrap.min.js",
                "~/Scripts/now-ui-kit.js",
                "~/Scripts/script/bootstrap-switch.js",
                "~/Scripts/script/bootstrap-datepicker.js"));

            bundles.Add(new ScriptBundle("~/bundles/visualisation_dashboard").Include(
                "~/Scripts/script/raphael.min.js",
                "~/Scripts/script/morris.min.js",
                "~/Scripts/script/dashboard.js"));
            
            bundles.Add(new StyleBundle("~/Content/newcss").Include(
                      "~/Content/style/bootstrap.min.css",
                      "~/Content/style/now-ui-kit.css",
                      //"~/Content/style/test-nowui.css",
                "~/Content/style/font-awesome.min.css",
                "~/Content/style/ionicons.min.css",
                "~/Content/style/morris.css",
                "~/Content/style/mycss.css"));

        }
    }
}

using System.Web;
using System.Web.Optimization;

namespace LibrarySystem
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                                                                 "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                                                                    "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                                                                    "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                                                                "~/Scripts/kendo.web.min.js",
                                                                "~/Scripts/kendo.aspnetmvc.min.js"));

            bundles.Add(new StyleBundle("~/Content/kendo").Include(
                                                               "~/Content/kendo.common.min.css",
                                                               "~/Content/kendo.metro.min.css"));

            
            bundles.IgnoreList.Clear();

            bundles.IgnoreList.Ignore("*.intellisense.js");
            bundles.IgnoreList.Ignore("*-vsdoc.js");
            bundles.IgnoreList.Ignore("*.debug.js", OptimizationMode.WhenEnabled);

            bundles.Add(new StyleBundle("~/Content/css").Include(
                                                             "~/Content/Site.css"));
        }
    }
}
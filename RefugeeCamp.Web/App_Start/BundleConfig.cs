using System.Web;
using System.Web.Optimization;

namespace RefugeeCamp.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-datetimepicker.css",
                "~/Content/site.css",
                "~/Content/themes/base/jquery-ui.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquerySignalR").Include(
                "~/Scripts/jquery.signalR-2.2.2.js",
                "~/Scripts/notify.js"));


            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            //jquery ui libraries
            bundles.Add(new ScriptBundle("~/bundles/jqueryui")
                .Include("~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new StyleBundle("~/Content/jqueryui")
                .Include("~/Content/themes/base/all.css"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/bootstrap-datetimepicker.js",
                "~/Scripts/bootstrap-datetimepicker.fr.js",
                      "~/Scripts/respond.js"));


            bundles.Add(new StyleBundle("~/Content/khrcss").Include(
                "~/Content/summernote.css",
                "~/Content/tagsly.css"));

            bundles.Add(new ScriptBundle("~/Scripts/khrscripts").Include(
                "~/Scripts/summernote.js",
                "~/Scripts/tagsly.js"));




        }
    }
}

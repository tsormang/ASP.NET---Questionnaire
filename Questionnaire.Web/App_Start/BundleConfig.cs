using System.Web;
using System.Web.Optimization;

namespace Questionnaire.Web
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
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/jquery.fancybox.pack.js",
                      "~/Scripts/jquery.flexslider-min.js",
                      "~/Scripts/jquery.min.js",
                      "~/Scripts/main.js",
                      "~/Scripts/modernizr.js",
                      "~/Scripts/retina.min.js"
                      ));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/css/css").Include(
                      "~/css/animate.min.css",
                      "~/css/bootstrap.min.css",
                      "~/css/flexslider.css",
                      "~/css/font-icon.css",
                      "~/css/jquery.fancybox.css",
                      "~/css/main.css",
                      "~/css/responsive.css"
                      ));
        }
    }
}

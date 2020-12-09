using System.Web;
using System.Web.Optimization;

namespace RTC.Web
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
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.js",
                        "~/Scripts/angular-sanitize.min.js",
                        "~/Scripts/angular-route.min.js",
                        "~/Scripts/angular-animate.min.js",
                        "~/Scripts/angular-aria.min.js",
                        "~/AngularJS/App/app.js"
                      ));
            bundles.Add(new StyleBundle("~/bundles/fontawesome").Include(
                "~/Content/Themes/css/fa-regular.css",
                "~/Content/Themes/css/fa-brands.css",
                "~/Content/Themes/css/fa-solid.css"
                ));
            bundles.Add(new StyleBundle("~/bundles/baseCss").Include(
                "~/Content/Themes/css/vendors.bundle.css",
                "~/Content/Themes/css/app.bundle.css",
                "~/Content/Themes/css/themes/cust-theme-4.css",
                "~/Content/Themes/css/notifications/toastr/toastr.css",
                "~/Content/Themes/css/datagrid/datatables/datatables.bundle.css",
                "~/Content/Themes/css/formplugins/select2/select2.bundle.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/baseJs").Include(
                "~/Content/Themes/js/vendors.bundle.js",
                "~/Content/Themes/js/app.bundle.js",
                "~/Content/Themes/js/notifications/toastr/toastr.js",
                "~/Content/Themes/js/datagrid/datatables/datatables.bundle.js",
                "~/Content/Themes/js/formplugins/select2/select2.bundle.js"
                ));
            bundles.Add(new StyleBundle("~/bundles/Swiper").Include(
               "~/Content/Plugins/Swiper/css/swiper-bundle.min.css"
               ));
            bundles.Add(new ScriptBundle("~/bundles/Swiper.js").Include(
                "~/Content/Plugins/Swiper/js/swiper-bundle.min.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/moment.js").Include(
                "~/Content/Themes/js/dependency/moment/moment.js"
                ));
        }
    }
}

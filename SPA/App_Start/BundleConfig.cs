namespace TestApp
{
    using System.Web.Optimization;

    /// <summary>
    /// Defines the <see cref="BundleConfig" />
    /// </summary>
    public class BundleConfig
    {
        /// <summary>
        /// The RegisterBundles
        /// </summary>
        /// <param name="bundles">The bundles<see cref="BundleCollection"/></param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/libs").Include(
                        "~/Scripts/jquery/jquery.slim.min.js",
                        "~/Scripts/bootstrap/popper.min.js",
                        "~/Scripts/bootstrap/js/bootstrap.min.js",
                        "~/Scripts/angular.js/angular.min.js",
                        "~/Scripts/angular.js/angular-route.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/testApp").Include(
                        "~/Scripts/API Service/Module.js",
                        "~/Scripts/API Service/Service.js",
                        "~/Scripts/API Service/Controller.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Scripts/bootstrap/css/bootstrap.min.css",
                      "~/Content/site.css"));

            BundleTable.EnableOptimizations = false;
        }
    }
}

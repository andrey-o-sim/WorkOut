using System.Web;
using System.Web.Optimization;

namespace WO.ApiServices
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/app/assets/css").Include(
                "~/app/assets/css/app.css"));

            bundles.Add(new ScriptBundle("~/app/assets/js").Include(
                "~/app/assets/libs/angular.js",
                "~/app/assets/libs/angular-route.js"));

            bundles.Add(new ScriptBundle("~/app/components/modules").Include(
                "~/app/app.module.js"));

            bundles.Add(new ScriptBundle("~/app/components/services").Include(
                "~/app/shared/services/trainingType.service.js"));

            bundles.Add(new ScriptBundle("~/app/components/controllers").Include(
                "~/app/components/TrainingType/forms/trainingType.new.controller.js",
                "~/app/components/TrainingType/forms/trainingType.edit.controller.js",
                "~/app/components/TrainingType/forms/trainingType.view.controller.js",
                "~/app/components/TrainingType/trainingType.route.js"));

            BundleTable.EnableOptimizations = false;
        }
    }
}

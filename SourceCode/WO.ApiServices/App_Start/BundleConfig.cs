using System.Web;
using System.Web.Optimization;

namespace WO.ApiServices
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/app/assets/libs/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/app/assets/libs/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/app/assets/css").Include(
                "~/app/assets/css/app.css"));

            bundles.Add(new ScriptBundle("~/app/assets/js").Include(
                "~/app/assets/libs/angular.js",
                "~/app/assets/libs/angular-route.js",
                "~/app/assets/libs/angular-animate.js",
                "~/app/assets/libs/angular-sanitize.js",
                "~/app/assets/libs/angular-ui/ui-bootstrap-tpls.js"));

            bundles.Add(new ScriptBundle("~/app/assets/js/angularUiRoute").Include(
                "~/app/assets/libs/angular-ui-router/angular-ui-router.js"));

            bundles.Add(new ScriptBundle("~/app/components/modules").Include(
                "~/app/app.module.js"));

            bundles.Add(new ScriptBundle("~/app/components/services").Include(
                "~/app/shared/services/trainingType.service.js",
                "~/app/shared/services/approach.service.js",
                "~/app/shared/services/exercise.service.js",
                "~/app/shared/services/set.service.js"));

            bundles.Add(new ScriptBundle("~/app/components/helpers").Include(
                "~/app/shared/workOut.helper.js"));

            bundles.Add(new ScriptBundle("~/app/shared/directives").Include(
                "~/app/shared/directives/wo.timeSelector.directive.js"));

            bundles.Add(new ScriptBundle("~/app/components/controllers").Include(
                "~/app/components/TrainingType/pages/trainingType.home.controller.js",
                "~/app/components/TrainingType/forms/trainingType.new.controller.js",
                "~/app/components/TrainingType/forms/trainingType.edit.controller.js",
                "~/app/components/TrainingType/forms/trainingType.view.controller.js",
                "~/app/components/TrainingType/trainingType.route.js",

                "~/app/components/Approach/pages/approach.home.controller.js",
                "~/app/components/Approach/forms/approach.new.controller.js",
                "~/app/components/Approach/forms/approach.edit.controller.js",
                "~/app/components/Approach/forms/approach.view.controller.js",
                "~/app/components/Approach/approach.route.js",

                "~/app/components/Exercise/pages/exercise.home.controller.js",
                "~/app/components/Exercise/exercise.route.js",

                "~/app/components/Set/pages/set.home.controller.js",
                "~/app/components/Set/forms/set.new.controller.js",
                "~/app/components/Set/forms/set.edit.controller.js",
                "~/app/components/Set/forms/set.view.controller.js",
                "~/app/components/Set/set.route.js"
                ));

            BundleTable.EnableOptimizations = false;
        }
    }
}

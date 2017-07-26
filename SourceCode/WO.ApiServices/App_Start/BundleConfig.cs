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
                      "~/Content/site.css",
                      "~/Content/selectize.default.css",
                      "~/Content/select.css",
                      "~/Content/font-awesome.css",
                      "~/Content/datetimepicker.css",
                      "~/Content/angular-toastr.css"));

            bundles.Add(new StyleBundle("~/app/assets").Include(
                "~/app/assets/css/app.css",
                 "~/app/assets/libs/angular-datetime-range/datetime-range.css"));

            bundles.Add(new ScriptBundle("~/app/assets/js").Include(
                "~/app/assets/libs/moment/moment.js",
                "~/app/assets/libs/angular.js",
                "~/app/assets/libs/angular-route.js",
                "~/app/assets/libs/angular-animate.js",
                "~/app/assets/libs/angular-sanitize.js",
                "~/app/assets/libs/angular-ui/ui-bootstrap-tpls.js",
                "~/app/assets/libs/angular-validator/angular-validator.js",
                "~/app/assets/libs/ui-select/select.js",
                "~/app/assets/libs/angular-datetime-picker/datetimepicker.js",
                "~/app/assets/libs/angular-datetime-picker/datetimepicker.templates.js",
                "~/app/assets/libs/angular-toastr.js",
                "~/app/assets/libs/angular-toastr.tpls.js",
                "~/app/assets/libs/angular-datetime-range/datetime-range.js"));

            bundles.Add(new ScriptBundle("~/app/assets/js/angularUiRoute").Include(
                "~/app/assets/libs/angular-ui-router/angular-ui-router.js"));

            bundles.Add(new ScriptBundle("~/app/components/modules").Include(
                "~/app/app.module.js",
                "~/app/app.global.js"));

            bundles.Add(new ScriptBundle("~/app/components/services").Include(
                "~/app/shared/services/trainingType.service.js",
                "~/app/shared/services/approach.service.js",
                "~/app/shared/services/exercise.service.js",
                "~/app/shared/services/set.service.js",
                "~/app/shared/services/training.service.js",
                "~/app/shared/services/log.service.js"));

            bundles.Add(new ScriptBundle("~/app/components/helpers").Include(
                "~/app/shared/workOut.helper.js"));

            bundles.Add(new ScriptBundle("~/app/shared/directives").Include(
                "~/app/shared/directives/wo.timeSelector.directive.js"));

            bundles.Add(new ScriptBundle("~/app/components/controllers").Include(
                "~/app/components/TrainingType/pages/trainingType.home.controller.js",
                "~/app/components/TrainingType/forms/trainingType.form.controller.js",
                "~/app/components/TrainingType/forms/trainingType.view.controller.js",
                "~/app/components/TrainingType/trainingType.route.js",

                "~/app/components/Approach/pages/approach.home.controller.js",
                "~/app/components/Approach/forms/approach.view.controller.js",
                "~/app/components/Approach/forms/approach.form.controller.js",
                "~/app/components/Approach/approach.route.js",

                "~/app/components/Exercise/pages/exercise.home.controller.js",
                "~/app/components/Exercise/forms/exercise.form.controller.js",
                "~/app/components/Exercise/exercise.route.js",

                "~/app/components/Set/pages/set.home.controller.js",
                "~/app/components/Set/forms/set.form.controller.js",
                "~/app/components/Set/forms/set.view.controller.js",
                "~/app/components/Set/set.route.js",

                "~/app/components/Training/pages/training.home.controller.js",
                "~/app/components/Training/forms/training.form.controller.js",
                "~/app/components/Training/forms/training.view.controller.js",
                "~/app/components/Training/training.route.js",

                "~/app/components/Log/log.home.controller.js",
                "~/app/components/Log/log.route.js"
                ));

            BundleTable.EnableOptimizations = false;
        }
    }
}

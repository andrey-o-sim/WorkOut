(function () {

    angular
        .module('woApp')
        .controller('TrainingViewController', TrainingViewController);

    TrainingViewController.$inject = [
        '$stateParams',
        'trainingService',
        'toastr',
        'toastrConfig',
        'workOutHelper'];

    function TrainingViewController(
        $stateParams,
        trainingService,
        toastr,
        toastrConfig,
        workOutHelper) {

        var vm = this;
        vm.formIsReady = false;
        vm.startTraining = startTraining;
        vm.finishTraining = finishTraining;

        init();

        function init() {
            trainingService.getById($stateParams.id).then(function (result) {
                if (result) {
                    vm.training = result;
                }
                else {
                    toastrConfig.positionClass = 'toast-top-center';
                    toastrConfig.autoDismiss = false;
                    toastr.error("There is no Training with id = '" + $stateParams.id + "' in the system.");
                }

                vm.formIsReady = true;
            });
        }

        function startTraining() {
            var today = moment().startOf('day');
            var trainingDate = moment(vm.training.TrainingDate, "YYYY-MM-DD");

            if (!today.isSame(trainingDate)) {
                if (confirm('Training Date is different to current date. If you continue, training date will be changed to current date.')) {
                    vm.training.TrainingDate = workOutHelper.getCurrentDateWithoutTimeZone();
                }
            }

            vm.training.Started = true;
            vm.training.StartDateTime = workOutHelper.getCurrentDateWithoutTimeZone();

            save(vm.training);
        }

        function finishTraining() {
            vm.training.Started = false;
            vm.training.Finished = true;
            vm.training.EndDateTime = workOutHelper.getCurrentDateWithoutTimeZone();

            save(vm.training);
        }

        function save(training) {
            trainingService.save(vm.training).then(function (result) {
                if (!result || !result.Succeed) {
                    toastrConfig.positionClass = 'toast-top-center';
                    toastrConfig.autoDismiss = false;
                    toastr.error("Something went wrong. Please try again.");
                }
            });
        }
    }
})();

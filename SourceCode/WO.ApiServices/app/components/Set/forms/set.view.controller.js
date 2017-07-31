(function () {
    angular.module('woApp')
        .controller('SetViewController', SetViewController);

    SetViewController.$inject = [
        '$stateParams',
        'setService',
        'toastr',
        'toastrConfig',
        'workOutHelper'];

    function SetViewController(
        $stateParams,
        setService,
        toastr,
        toastrConfig,
        workOutHelper) {

        var vm = this;
        vm.formIsReady = false;
        vm.startSet = startSet;
        vm.finishSet = finishSet;

        init();

        function init() {
            setService.getById($stateParams.id).then(function (result) {
                if (result) {
                    vm.set = result;
                } else {
                    toastrConfig.positionClass = 'toast-top-center';
                    toastrConfig.autoDismiss = false;
                    toastr.error("There is no Set with id = '" + $stateParams.id + "' in the system.");
                }

                vm.formIsReady = true;
            });
        }

        function startSet() {
            vm.set.Started = true;
            vm.set.StartDateTime = workOutHelper.getCurrentDateTimeWithoutTimeZone();

            save(vm.set);
        }

        function finishSet() {
            vm.set.Started = false;
            vm.set.Finished = true;

            var startTime = moment(vm.set.StartDateTime);
            var endTime = moment();
            vm.set.EndDateTime = workOutHelper.getDateTimeWithoutTimeZone(endTime);

            var spentTime = moment.duration(endTime.diff(startTime));
            vm.set.SpentTime = {
                Minutes: spentTime.get('minutes'),
                Seconds: spentTime.get('seconds')
            };

            save(vm.set);
        }

        function save(set) {
            setService.save(set).then(function (result) {
                toastrConfig.positionClass = 'toast-top-center';
                toastrConfig.autoDismiss = false;
                if (result && result.Succeed) {
                    if (set.Finished) {
                        toastr.info("Congratulation, you have finished the Set.");
                    }
                }
                else {
                    toastr.error("Something went wrong. Please try again.");
                }
            });
        }
    }
}());
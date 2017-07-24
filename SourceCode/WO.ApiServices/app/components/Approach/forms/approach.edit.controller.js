(function () {
    angular
        .module('woApp')
        .controller('ApproachEditController', ApproachEditController);

    ApproachEditController.$inject = [
        '$state',
        '$stateParams',
        'approachService',
        'toastr',
        'toastrConfig'];

    function ApproachEditController(
        $state,
        $stateParams,
        approachService,
        toastr,
        toastrConfig) {

        var vm = this;
        vm.formIsReady = false;
        vm.save = save;

        init();

        function init() {
            approachService.getById($stateParams.id).then(function (result) {
                if (result) {
                    vm.approach = result;
                }
                else {
                    toastrConfig.positionClass = 'toast-top-center';
                    toastrConfig.autoDismiss = false;
                    toastr.error("There is no Approach with id = '" + $stateParams.id + "' in the system.");
                }

                vm.formIsReady = true;
            });
        }

        function save(approach) {
            if (isValidForm(approach)) {
                vm.disableSaveButton = true;
                approachService.save(approach).then(function (result) {
                    if (result.Succeed) {
                        $state.go('approachHome');
                    }
                    else {
                        vm.disableSaveButton = false;
                    }
                });
            }
        }

        function isValidForm(approach) {
            vm.validator = {};
            var isValid = true;
            vm.validateForm = true;

            if (!approach.PlannedTimeForRest
                || (approach.PlannedTimeForRest.Minutes === 0 && approach.PlannedTimeForRest.Seconds === 0)) {
                vm.validator.ValidPlannedTimeForRest = false;
                isValid = false;
            }

            return isValid;
        }
    }
}());
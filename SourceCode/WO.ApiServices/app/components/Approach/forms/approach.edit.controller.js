(function () {
    angular
        .module('woApp')
        .controller('ApproachEditController', ApproachEditController);

    ApproachEditController.$inject = [
        '$state',
        '$stateParams',
        'approachService'];

    function ApproachEditController(
        $state,
        $stateParams,
        approachService) {

        var vm = this;
        vm.formIsReady = false;
        vm.save = save;

        init();

        function init() {
            vm.approach = {
                PlannedTimeForRest: {
                    Minutes: 0,
                    Seconds: 0
                },
                SpentTimeForRest: {
                    Minutes: 0,
                    Seconds: 0
                }
            };

            approachService.getById($stateParams.id).then(function (result) {
                vm.approach = result;
                vm.formIsReady = true;
            });
        }

        function save(approach) {
            if (isValidForm(approach)) {
                vm.disableSaveButton = true;
                approachService.update(approach).then(function (result) {
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
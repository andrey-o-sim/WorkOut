(function () {
    angular
        .module('woApp')
        .controller('ApproachNewController', ApproachNewController);

    ApproachNewController.$inject = [
        '$state',
        'approachService'];

    function ApproachNewController(
        $state,
        approachService) {

        var vm = this;
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
        }

        function save(approach) {
            if (isValidForm(approach)) {
                vm.disableSaveButton = true;
                approachService.save(approach).then(function (result) {
                    if (result.Succeed) {
                        $state.go('approachHome')
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
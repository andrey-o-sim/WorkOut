(function () {
    angular
        .module('woApp')
        .controller('approachEditController', approachEditController);

    approachEditController.$inject = [
        'approachService',
        '$state',
        '$stateParams'];

    function approachEditController(
        approachService,
        $state,
        $stateParams) {

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
}());
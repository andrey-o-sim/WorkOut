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

    function init()
    {
        vm.minutes = [];
        for (i = 0; i <= 5; i++) {
            vm.minutes.push(i);
        }

        vm.seconds = [];
        for (i = 0; i <= 60; i++) {
            vm.seconds.push(i);
        }

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
                $state.go('approachHome')
            }
            else {
                vm.disableSaveButton = false;
            }
        });
    }
}
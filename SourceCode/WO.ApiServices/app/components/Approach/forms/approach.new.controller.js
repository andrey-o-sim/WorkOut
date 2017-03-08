angular
    .module('woApp')
    .controller('approachNewController', approachNewController);

approachNewController
.$inject = ['approachService',
           '$state'];

function approachNewController(
           approachService,
           $state) {

    var vm = this;
    vm.save = save;

    init();

    function init() {
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
    }

    function save(approach) {
        vm.disableSaveButton = true;
        approachService.create(approach).then(function (result) {
            if (result.Succeed) {
                $state.go('approachHome')
            }
            else {
                vm.disableSaveButton = false;
            }
        });
    }
}

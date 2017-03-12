(function () {
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
}());
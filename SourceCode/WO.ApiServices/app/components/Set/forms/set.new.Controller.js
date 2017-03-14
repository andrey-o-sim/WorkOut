(function () {
    angular.module('woApp')
        .controller('setNewController', setNewController);

    setNewController.$inject = [
        'setService',
        '$state'];

    function setNewController(
        setService,
        $state) {

        var vm = this;

        vm.save = save;

        init();

        vm.validator = validator;

        function validator() {
            return false;
        }

        function init() {
            vm.set = {
                PlannedTime: {
                    Hours: 0,
                    Minutes: 0,
                    Seconds: 0
                },
                TimeForRest: {
                    Hours: 0,
                    Minutes: 0,
                    Seconds: 0
                },
                CountApproaches: 0
            }
        }

        function save(set) {
            setService.create(set).then(function (result) {
                if (result.Succeed) {
                    $state.go('setHome');
                }
            });
        }
    }
}());
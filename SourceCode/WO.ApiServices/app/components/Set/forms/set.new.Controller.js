(function () {
    angular.module('woApp')
        .controller('setNewController', setNewController);

    setNewController.$inject = [
        '$state',
        'exerciseService',
        'setService', ];

    function setNewController(
        $state,
        exerciseService,
        setService) {

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
                CountApproaches: 0,
                Exercise: { id: 0, Name: '' }
            };

            exerciseService.getAll().then(function (result) {
                if (result) {
                    vm.Exercises = result;
                }
            });
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
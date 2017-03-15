(function () {
    angular.module('woApp')
        .controller('setNewController', setNewController);

    setNewController.$inject = [
        '$state',
        '$uibModal',
        'exerciseService',
        'setService',];

    function setNewController(
        $state,
        $uibModal,
        exerciseService,
        setService) {

        var vm = this;

        vm.save = save;

        init();

        vm.openModal = openModal;

        vm.validator = validator;

        function validator() {

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

        function openModal() {
            var modalInstance = $uibModal.open({
                animation: true,
                backdrop: 'static',
                ariaLabelledBy: 'Exercise New',
                templateUrl: '/app/components/Exercise/forms/exercise.add.edit.html',
                controller: 'ExerciseAddEditController',
                controllerAs: 'vm'
            });

            modalInstance.result.then(function (exercise) {
                vm.Exercises.push(exercise);
            });
        }
    }
}());
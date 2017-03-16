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
            vm.validateForm = true;
            if (isValidForm(set)) {
                vm.disableSaveButton = true;

                setService.create(set).then(function (result) {
                    if (result.Succeed) {
                        $state.go('setHome');
                    }
                    else {
                        vm.disableSaveButton = false;
                    }
                });
            }
        }

        function isValidForm(set) {
            vm.validator = {};
            var isValid = true;

            if (!set.TimeForRest
                || (set.TimeForRest.Hours === 0 && set.TimeForRest.Minutes === 0 || set.TimeForRest.Seconds === 0)) {
                vm.validator.ValidTimeForRest = false;
                isValid = false;
            }

            if (!set.Exercises || set.Exercises.length == 0) {
                vm.validator.ValidExercises = false;
                isValid = false;
            }

            if (!set.CountApproaches || set.CountApproaches === 0) {
                vm.validator.ValidCountApproaches = false;
                isValid = false;
            }

            return isValid;
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
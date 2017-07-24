angular
    .module('woApp')
    .controller('ExerciseHomeController', ExerciseHomeController);

ExerciseHomeController.$inject = [
    '$uibModal',
    'exerciseService',
    'workOutHelper',
    'toastr'];

function ExerciseHomeController(
    $uibModal,
    exerciseService,
    workOutHelper,
    toastr) {

    var vm = this;
    vm.formIsReady = false;
    vm.addEdit = addEdit;
    vm.remove = remove;

    init();

    function init() {
        exerciseService.getAll().then(function (result) {
            vm.exercises = result;
            vm.formIsReady = true;
        });
    }

    function addEdit(exerciseId) {
        var ariaLabel = exerciseId > 0 ? 'Exercise Edit' : 'Exercise New';

        var modalProperties = {
            ariaLabelledBy: ariaLabel,
            templateUrl: '/app/components/Exercise/forms/exercise.form.html',
            controller: 'ExerciseFormController',
            itemId: exerciseId
        };

        var modalInstance = openModal(modalProperties);

        modalInstance.result.then(
            function (resultExercise) {
                var indexForUpdate = -1;
                vm.exercises.forEach(function (item, index) {
                    if (item.Id === resultExercise.Id) {
                        indexForUpdate = index;
                        return true;
                    }
                });

                if (indexForUpdate > -1) {
                    vm.exercises[indexForUpdate].Name = resultExercise.Name;
                }
                else {
                    vm.exercises.push(resultExercise);
                }
            },
            function () {
            });
    }

    function openModal(modalProperties) {
        var modalInstance = $uibModal.open({
            animation: true,
            backdrop: 'static',
            ariaLabelledBy: modalProperties.ariaLabell,
            templateUrl: modalProperties.templateUrl,
            controller: modalProperties.controller,
            controllerAs: 'vm',
            resolve: {
                id: function () {
                    return modalProperties.itemId;
                }
            }
        });

        return modalInstance;
    }

    function remove(exercise) {
        if (confirm("Do you realy want to remove '" + exercise.Name + "' ?")) {
            exerciseService.remove(exercise.Id).then(function (result) {
                if (result.Succeed) {
                    vm.exercises = workOutHelper.removeElementFromArray(vm.exercises, result.ResultItemId);
                    toastr.info("Exercise '" + exercise.Name + "' was successfully removed.");
                }
            });
        }
    }
}
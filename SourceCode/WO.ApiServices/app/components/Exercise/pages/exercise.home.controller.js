angular
    .module('woApp')
    .controller('exerciseHomeController', exerciseHomeController);

exerciseHomeController.$inject = [
    '$uibModal',
    'exerciseService',
    'workOutHelper'];

function exerciseHomeController(
    $uibModal,
    exerciseService,
    workOutHelper) {

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
            templateUrl: '/app/components/Exercise/forms/exercise.add.edit.html',
            controller: 'ExerciseAddEditController',
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

    function remove(id) {
        exerciseService.remove(id).then(function (result) {
            if (result.Succeed) {
                vm.exercises = workOutHelper.removeElementFromArray(vm.exercises, result.ResultItemId);
            }
        })
    }
}
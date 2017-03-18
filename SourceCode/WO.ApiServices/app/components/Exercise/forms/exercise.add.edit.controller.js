(function () {
    'use strict';

    angular
        .module('woApp')
        .controller('ExerciseAddEditController', ExerciseAddEditController);

    ExerciseAddEditController.$inject = ['$uibModalInstance', 'exerciseService', 'id'];

    function ExerciseAddEditController($uibModalInstance, exerciseService, id) {

        var vm = this;
        vm.updateId = id;

        vm.save = save;
        vm.cancel = cancel;

        init();

        function init() {
            if (vm.updateId > 0) {
                exerciseService.getById(vm.updateId).then(function (result) {
                    vm.exercise = result;
                });
            }
        }

        function save(exercise) {
            if (isValid(exercise)) {
                vm.disableSaveButton = true;

                if (vm.updateId > 0) {
                    exerciseService.update(exercise).then(function (result) {
                        postCreateOrUpdate(exercise, result);
                    });
                }
                else {
                    exerciseService.create(exercise).then(function (result) {
                        postCreateOrUpdate(exercise, result);
                    });
                }
            }
        }

        function postCreateOrUpdate(exercise, result) {
            if (result.Succeed) {
                exercise.Id = result.ResultItemId;
                $uibModalInstance.close(exercise);
            }
            else {
                vm.disableSaveButton = false;
            }
        }

        function isValid(exercise) {
            return exercise.Name != "";
        }

        function cancel() {
            $uibModalInstance.dismiss('cancel');
        }
    }
})();

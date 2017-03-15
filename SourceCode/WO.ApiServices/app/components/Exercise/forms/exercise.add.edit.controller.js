(function () {
    'use strict';

    angular
        .module('woApp')
        .controller('ExerciseAddEditController', ExerciseAddEditController);

    ExerciseAddEditController.$inject = ['$uibModalInstance', 'exerciseService'];

    function ExerciseAddEditController($uibModalInstance, exerciseService) {

        var vm = this;

        vm.save = save;
        vm.cancel = cancel;

        function save(exercise) {
            if (isValid(exercise)) {
                vm.disableSaveButton = true;
                exerciseService.create(exercise).then(function (result) {
                    if (result.Succeed) {
                        exercise.Id = result.ResultItemId;
                        $uibModalInstance.close(exercise);
                    }
                    else {
                        vm.disableSaveButton = false;
                    }
                });
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

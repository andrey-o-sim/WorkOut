(function () {
    angular
        .module('woApp')
        .controller('ExerciseFormController', ExerciseFormController);

    ExerciseFormController.$inject = [
        '$uibModalInstance',
        'exerciseService',
        'id'];

    function ExerciseFormController(
        $uibModalInstance,
        exerciseService,
        id) {

        var vm = this;
        vm.exerciseId = id;
        vm.title = id > 0 ? 'Edit Exercise' : 'Add Exercise';
        vm.formIsReady = false;

        vm.save = save;
        vm.cancel = cancel;

        init();

        function init() {
            if (vm.exerciseId > 0) {
                exerciseService.getById(vm.exerciseId).then(function (result) {
                    vm.exercise = result;
                    vm.formIsReady = true;
                });
            }
            else {
                vm.formIsReady = true;
            }
        }

        function save(exercise) {
            if (isValidForm(exercise)) {
                vm.disableSaveButton = true;

                exerciseService.getByName(exercise.Name).then(function (result) {
                    if (result.Id > 0 && result.Id !== vm.exerciseId) {
                        vm.disableSaveButton = false;
                        vm.validator.ValidNameAlreadyPresent = true;
                    }
                    else {
                        exerciseService.save(exercise).then(function (result) {
                            postSave(exercise, result);
                        });
                    }
                });
            }
        }

        function postSave(exercise, result) {
            if (result.Succeed) {
                exercise.Id = result.ResultItemId;
                $uibModalInstance.close(exercise);
            }
            else {
                vm.disableSaveButton = false;
            }
        }

        function isValidForm(exercise) {
            vm.validator = {};
            var isValid = true;
            vm.validateForm = true;

            if (!exercise.Name || exercise.Name === "") {
                vm.validator.ValidName = false;
                isValid = false;
            }

            return isValid;
        }

        function cancel() {
            $uibModalInstance.dismiss('cancel');
        }
    }
})();

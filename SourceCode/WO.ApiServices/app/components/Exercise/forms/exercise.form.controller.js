(function () {
    angular
        .module('woApp')
        .controller('ExerciseFormController', ExerciseFormController);

    ExerciseFormController.$inject = [
        '$uibModalInstance',
        'exerciseService',
        'trainingTypeService',
        'id'];

    function ExerciseFormController(
        $uibModalInstance,
        exerciseService,
        trainingTypeService,
        id) {

        var vm = this;
        vm.exerciseId = id;
        vm.title = id > 0 ? 'Edit Exercise' : 'Add Exercise';
        vm.formIsReady = false;

        vm.save = save;
        vm.cancel = cancel;

        init();

        function init() {

            trainingTypeService.getAll().then(function (result) {
                vm.TrainingTypes = result;
            });

            if (vm.exerciseId > 0) {
                exerciseService.getById(vm.exerciseId).then(function (result) {
                    vm.exercise = result;
                    vm.formIsReady = true;
                });
            }
            else {
                vm.exercise = {};
                vm.formIsReady = true;
            }
        }

        function save(exercise) {
            vm.disableSaveButton = true;
            if (isValidForm(exercise)) {

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
            else {
                vm.disableSaveButton = false;
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

            if (!exercise.TrainingTypes || exercise.TrainingTypes.length === 0) {
                vm.validator.ValidTrainingTypes = false;
                isValid = false;
            }

            return isValid;
        }

        function cancel() {
            $uibModalInstance.dismiss('cancel');
        }
    }
})();

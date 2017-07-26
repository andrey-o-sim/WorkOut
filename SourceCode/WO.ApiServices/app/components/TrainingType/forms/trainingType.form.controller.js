(function () {
    angular
        .module('woApp')
        .controller('TrainingTypeFormController', TrainingTypeFormController)

    TrainingTypeFormController.$inject = [
        '$uibModalInstance',
        'trainingTypeService',
        'id'];

    function TrainingTypeFormController(
        $uibModalInstance,
        trainingTypeService,
        id) {

        var vm = this;
        vm.formIsReady = false;
        vm.trainingTypeId = id;
        vm.title = id > 0 ? 'Edit Training Type' : 'Add Training Type';

        vm.save = save;
        vm.cancel = cancel;

        init();

        function init() {
            if (vm.trainingTypeId > 0) {
                trainingTypeService.getById(vm.trainingTypeId).then(function (result) {
                    vm.trainingType = result;
                    vm.formIsReady = true;
                });
            }
            else {
                vm.formIsReady = true;
            }
        }

        function save(trainingType) {
            vm.disableSaveButton = true;
            if (isValidForm(trainingType)) {
                trainingTypeService.save(trainingType).then(function (result) {
                    postSave(trainingType, result);
                });
            }
            else {
                vm.disableSaveButton = false;
            }
        }

        function postSave(trainingType, result) {
            if (result.Succeed) {
                trainingType.Id = result.ResultItemId;
                $uibModalInstance.close(trainingType);
            }
            else {
                vm.disableSaveButton = false;
            }
        }

        function isValidForm(trainingType) {
            vm.validator = {};
            var isValid = true;
            vm.validateForm = true;

            if (!trainingType.TypeTraining || trainingType.TypeTraining === '') {
                isValid = false;
                vm.validator.ValidTrainingType = false;
            }

            return isValid;
        }

        function cancel() {
            $uibModalInstance.dismiss('cancel');
        }
    }
}());
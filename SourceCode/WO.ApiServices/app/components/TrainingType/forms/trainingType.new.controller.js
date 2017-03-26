(function () {
    angular
        .module('woApp')
        .controller('TrainingTypeNewController', TrainingTypeNewController)

    TrainingTypeNewController.$inject = [
        '$scope',
        '$state',
        'trainingTypeService'];

    function TrainingTypeNewController(
        $scope,
        $state,
        trainingTypeService) {

        var vm = this;
        vm.save = save;

        vm.trainingType = {
            TypeTraining: '',
            Description: ''
        };

        function save(trainingType) {
            if (isValidForm(trainingType)) {
                vm.disableSaveButton = true;

                trainingTypeService.create(trainingType).then(function (result) {
                    if (result.Succeed) {
                        vm.disableSaveButton = false;
                        $state.go('trainingTypeHome');
                    }
                    else {
                        vm.disableSaveButton = false;
                    }
                });
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
    }
}());
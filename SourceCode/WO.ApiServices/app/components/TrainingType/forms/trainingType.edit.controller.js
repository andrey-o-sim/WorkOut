(function () {
    angular
        .module('woApp')
        .controller('TrainingTypeEditController', TrainingTypeEditController)

    TrainingTypeEditController.$inject = [
        '$scope',
        '$stateParams',
        '$state',
        'trainingTypeService',
        'toastr',
        'toastrConfig'];

    function TrainingTypeEditController(
        $scope,
        $stateParams,
        $state,
        trainingTypeService,
        toastr,
        toastrConfig) {

        var vm = this;
        vm.formIsReady = false;

        vm.save = save;

        init();

        function init() {
            trainingTypeService.getById($stateParams.id).then(function (result) {
                if (result) {
                    vm.trainingType = result;
                }
                else {
                    toastrConfig.positionClass = 'toast-top-center';
                    toastrConfig.autoDismiss = false;
                    toastr.error("There is no Training type with id = '" + $stateParams.id + "' in the system.");
                }

                vm.formIsReady = true;
            });
        }

        function save(trainingType) {
            if (isValidForm(trainingType)) {
                trainingTypeService.update(trainingType).then(function (result) {
                    if (result.Succeed) {
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
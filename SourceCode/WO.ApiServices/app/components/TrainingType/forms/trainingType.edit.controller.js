(function () {
    angular
        .module('woApp')
        .controller('trainingTypeEditController', trainingTypeEditController)

    trainingTypeEditController.$inject = [
        '$scope',
        '$stateParams',
        'trainingTypeService',
        '$state'];

    function trainingTypeEditController(
        $scope,
        $stateParams,
        trainingTypeService,
        $state) {

        var vm = this;
        vm.formIsReady = false;

        vm.save = save;

        init();

        function init() {
            trainingTypeService.getById($stateParams.id).then(function (result) {
                vm.trainingType = result;
                vm.formIsReady = true;
            });
        }

        function save(trainingType) {
            vm.disableSaveButton = true;
            var isValid = isRequiredFieldsPopulated(trainingType);

            if (isValid) {
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

        function isRequiredFieldsPopulated(trainingType) {
            vm.requiredTypeTraining = vm.trainingType.TypeTraining == "";
            vm.requiredDescription = vm.trainingType.Description == "";

            return !(vm.requiredTypeTraining || vm.requiredDescription);
        }
    }
}());
angular
    .module('woApp')
    .controller('trainingTypeNewController', trainingTypeNewController)

trainingTypeNewController
.$inject = ['$scope',
           'trainingTypeService',
           '$state'];

function trainingTypeNewController(
    $scope,
    trainingTypeService,
    $state) {

    var vm = this;
    vm.save = save;

    vm.trainingType = {
        TypeTraining: '',
        Description: ''
    };

    function save(trainingType) {
        vm.disableSaveButton = true;
        var isValid = isRequiredFieldsPopulated(trainingType);

        if (isValid) {
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

    function isRequiredFieldsPopulated(trainingType) {
        vm.requiredTypeTraining = trainingType.TypeTraining == "";
        vm.requiredDescription = trainingType.Description == "";

        return !(vm.requiredTypeTraining || vm.requiredDescription);
    }
}
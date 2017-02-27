angular
    .module('woApp')
    .controller('trainingTypeNewController', trainingTypeNewController)

function trainingTypeNewController(
    $scope,
    trainingTypeService) {

    $scope.save = save;

    $scope.trainingType = {
        TypeTraining: '',
        Description: ''
    };

    function save(trainingType) {
        $scope.disableSaveButton = true;
        var isValid = isRequiredFieldsPopulated(trainingType);

        if (isValid) {
            trainingTypeService.create(trainingType).then(function (result) {
                if (result.Succeed) {
                    alert(result.ResultItemId);
                    $scope.disableSaveButton = false;
                }
                else {
                    $scope.disableSaveButton = false;
                }
            });
        }
        else {
            $scope.disableSaveButton = false;
        }
    }

    function isRequiredFieldsPopulated(trainingType) {
        $scope.requiredTypeTraining = trainingType.TypeTraining == "";
        $scope.requiredDescription = trainingType.Description == "";

        return !($scope.requiredTypeTraining || $scope.requiredDescription);
    }
}
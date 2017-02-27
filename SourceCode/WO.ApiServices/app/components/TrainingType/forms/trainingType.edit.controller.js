angular
    .module('woApp')
    .controller('trainingTypeEditController', trainingTypeEditController)

function trainingTypeEditController(
    $scope,
    $routeParams,
    trainingTypeService) {

    $scope.save = save;

    init();

    function init() {
        trainingTypeService.getById($routeParams.id).then(function (result) {
            $scope.trainingType = result;
        });
    }

    function save(trainingType) {
        $scope.disableSaveButton = true;
        var isValid = isRequiredFieldsPopulated(trainingType);

        if (isValid) {
            trainingTypeService.update(trainingType).then(function (result) {
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
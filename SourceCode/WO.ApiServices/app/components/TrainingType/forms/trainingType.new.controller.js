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
        trainingTypeService.save(trainingType).then(function (result) {
            alert(result.ResultItemId);
        });
    }
}
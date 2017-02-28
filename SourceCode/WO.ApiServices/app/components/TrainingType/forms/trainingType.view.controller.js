angular
    .module('woApp')
    .controller('trainingTypeViewController', trainingTypeViewController)

function trainingTypeViewController(
    $scope,
    $routeParams,
    trainingTypeService) {
    
    init();

    function init() {
        trainingTypeService.getById($routeParams.id).then(function (result) {
            $scope.trainingType = result;
        });
    }
}
angular
    .module('woApp')
    .controller('trainingTypeHomeController', trainingTypeHomeController)

function trainingTypeHomeController(
    $scope,
    $stateParams,
    trainingTypeService) {

    var vm = this;
    init();

    function init() {
        trainingTypeService.getAll().then(function (result) {
            vm.trainingTypes = result;
        });
    }
}
angular
    .module('woApp')
    .controller('trainingTypeHomeController', trainingTypeHomeController)

function trainingTypeHomeController(
    $scope,
    $stateParams,
    trainingTypeService,
    workOutHelper) {

    var vm = this;
    vm.formIsReady = false;

    vm.remove = remove;
    init();

    function init() {
        trainingTypeService.getAll().then(function (result) {
            vm.trainingTypes = result;
            vm.formIsReady = true;
        });
    }

    function remove(id) {
        trainingTypeService.remove(id).then(function (response) {
            if (response.Succeed) {
                vm.trainingTypes = workOutHelper.removeElementFromArray(vm.trainingTypes, response.ResultItemId);
            }
        });
    }
}
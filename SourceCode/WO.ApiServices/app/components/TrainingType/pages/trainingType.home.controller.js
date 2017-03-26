(function () {
    angular
        .module('woApp')
        .controller('TrainingTypeHomeController', TrainingTypeHomeController)

    TrainingTypeHomeController.$inject = [
        'trainingTypeService',
        'workOutHelper'];

    function TrainingTypeHomeController(
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
            trainingTypeService.remove(id).then(function (result) {
                if (result.Succeed) {
                    vm.trainingTypes = workOutHelper.removeElementFromArray(vm.trainingTypes, result.ResultItemId);
                }
            });
        }
    }
}());
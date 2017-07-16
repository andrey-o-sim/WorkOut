(function () {
    angular
        .module('woApp')
        .controller('TrainingTypeHomeController', TrainingTypeHomeController)

    TrainingTypeHomeController.$inject = [
        'trainingTypeService',
        'workOutHelper',
        'toastr'];

    function TrainingTypeHomeController(
        trainingTypeService,
        workOutHelper,
        toastr) {

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

        function remove(trainingType) {
            if (confirm("Do you realy want to remove '" + trainingType.TypeTraining + "' ?")) {
                trainingTypeService.remove(trainingType.Id).then(function (result) {
                    if (result.Succeed) {
                        vm.trainingTypes = workOutHelper.removeElementFromArray(vm.trainingTypes, result.ResultItemId);
                        toastr.info("Training type '" + trainingType.TypeTraining + "' was successfully removed.");
                    }
                });
            }
        }
    }
}());
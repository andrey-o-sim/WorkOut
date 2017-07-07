(function () {

    angular
        .module('woApp')
        .controller('TrainingHomeController', TrainingHomeController);

    TrainingHomeController.$inject = [
        'trainingService',
        'workOutHelper',
        'toastr'];

    function TrainingHomeController(
        trainingService,
        workOutHelper,
        toastr) {

        var vm = this;
        vm.remove = remove;

        vm.formIsReady = false;

        init();

        function init() {
            trainingService.getAll().then(function (result) {
                vm.trainings = result;
                vm.formIsReady = true;
            });
        }

        function remove(training) {
            if (confirm("Do you realy want to remove the item?")) {
                trainingService.remove(training.Id).then(function (result) {
                    if (result.Succeed) {
                        vm.trainings = workOutHelper.removeElementFromArray(vm.trainings, result.ResultItemId);
                        toastr.info("Training with Id '" + result.ResultItemId + "' was successfully removed.");
                    }
                });
            }
        }
    }
})();

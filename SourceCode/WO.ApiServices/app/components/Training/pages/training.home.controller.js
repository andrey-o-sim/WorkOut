(function () {

    angular
        .module('woApp')
        .controller('TrainingHomeController', TrainingHomeController);

    TrainingHomeController.$inject = [
        'trainingService',
        'workOutHelper'];

    function TrainingHomeController(
        trainingService,
        workOutHelper) {

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

        function remove(id) {
            trainingService.remove(id).then(function (result) {
                if (result.Succeed) {
                    vm.trainings = workOutHelper.removeElementFromArray(vm.trainings, result.ResultItemId);
                }
            });
        }
    }
})();

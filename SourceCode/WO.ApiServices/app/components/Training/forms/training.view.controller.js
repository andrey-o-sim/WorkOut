(function () {

    angular
        .module('woApp')
        .controller('TrainingViewController', TrainingViewController);

    TrainingViewController.$inject = [
        '$stateParams',
        'trainingService'];

    function TrainingViewController(
        $stateParams,
        trainingService) {

        var vm = this;
        vm.formIsReady = false;

        init();

        function init() {
            trainingService.getById($stateParams.id).then(function (result) {
                vm.training = result;
                vm.formIsReady = true;
            });
        }
    }
})();

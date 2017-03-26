(function () {
    angular
        .module('woApp')
        .controller('TrainingTypeViewController', TrainingTypeViewController)

    function TrainingTypeViewController(
        $scope,
        $stateParams,
        trainingTypeService) {

        var vm = this;
        vm.formIsReady = false;

        init();

        function init() {
            trainingTypeService.getById($stateParams.id).then(function (result) {
                vm.trainingType = result;
                vm.formIsReady = true;
            });
        }
    }
}());
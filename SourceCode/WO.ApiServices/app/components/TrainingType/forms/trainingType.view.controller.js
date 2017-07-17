(function () {
    angular
        .module('woApp')
        .controller('TrainingTypeViewController', TrainingTypeViewController)

    TrainingTypeViewController.$inject = [
        '$scope',
        '$stateParams',
        'trainingTypeService',
        'toastr',
        'toastrConfig'];

    function TrainingTypeViewController(
        $scope,
        $stateParams,
        trainingTypeService,
        toastr,
        toastrConfig) {

        var vm = this;
        vm.formIsReady = false;

        init();

        function init() {
            trainingTypeService.getById($stateParams.id).then(function (result) {
                if (result) {
                    vm.trainingType = result;
                }
                else {
                    toastrConfig.positionClass = 'toast-top-center';
                    toastrConfig.autoDismiss = false;
                    toastr.error("There is no Training type with id = '" + $stateParams.id + "' in the system.");
                }
                vm.formIsReady = true;
            });
        }
    }
}());
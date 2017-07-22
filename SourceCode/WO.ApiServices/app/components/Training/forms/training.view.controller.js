(function () {

    angular
        .module('woApp')
        .controller('TrainingViewController', TrainingViewController);

    TrainingViewController.$inject = [
        '$stateParams',
        'trainingService',
        'toastr',
        'toastrConfig'];

    function TrainingViewController(
        $stateParams,
        trainingService,
        toastr,
        toastrConfig) {

        var vm = this;
        vm.formIsReady = false;

        init();

        function init() {
            trainingService.getById($stateParams.id).then(function (result) {
                if (result) {
                    vm.training = result;

                    vm.training.StartDateTime = vm.training.StartDateTime ? vm.training.StartDateTime : moment();
                    vm.training.EndDateTime = vm.training.EndDateTime ? vm.training.EndDateTime : moment();
                }
                else {
                    toastrConfig.positionClass = 'toast-top-center';
                    toastrConfig.autoDismiss = false;
                    toastr.error("There is no Training with id = '" + $stateParams.id + "' in the system.");
                }

                vm.formIsReady = true;
            });
        }
    }
})();

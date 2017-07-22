(function () {
    angular
        .module('woApp')
        .controller('ApproachViewController', ApproachViewController);

    ApproachViewController.$inject = [
        '$state',
        '$stateParams',
        'approachService',
        'toastr',
        'toastrConfig'];

    function ApproachViewController(
        $state,
        $stateParams,
        approachService,
        toastr,
        toastrConfig) {

        var vm = this;
        vm.formIsReady = false;

        init();

        function init() {
            approachService.getById($stateParams.id).then(function (result) {
                if (result) {
                    vm.approach = result;
                }
                else {
                    toastrConfig.positionClass = 'toast-top-center';
                    toastrConfig.autoDismiss = false;
                    toastr.error("There is no Approach with id = '" + $stateParams.id + "' in the system.");
                }

                vm.formIsReady = true;
            });
        }
    }
}());
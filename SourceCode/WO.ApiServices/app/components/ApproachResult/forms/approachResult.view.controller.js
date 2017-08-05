(function () {
    angular
        .module('woApp')
        .controller('ApproachResultViewController', ApproachResultViewController);

    ApproachResultViewController.$inject = [
        '$state',
        '$stateParams',
        'approachResultService',
        'toastr',
        'toastrConfig'];

    function ApproachResultViewController(
        $state,
        $stateParams,
        approachResultService,
        toastr,
        toastrConfig) {

        var vm = this;
        vm.formIsReady = false;

        init();

        function init() {
            approachResultService.getById($stateParams.id).then(function (result) {
                if (result) {
                    vm.approachResult = result;
                }
                else {
                    toastrConfig.positionClass = 'toast-top-center';
                    toastrConfig.autoDismiss = false;
                    toastr.error("There is no Approach Result with id = '" + $stateParams.id + "' in the system.");
                }

                vm.formIsReady = true;
            });
        }
    }
}());
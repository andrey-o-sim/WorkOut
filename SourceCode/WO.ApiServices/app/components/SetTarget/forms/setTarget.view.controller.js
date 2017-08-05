(function () {
    angular
        .module('woApp')
        .controller('SetTargetViewController', SetTargetViewController);

    SetTargetViewController.$inject = [
        '$state',
        '$stateParams',
        'setTargetService',
        'toastr',
        'toastrConfig'];

    function SetTargetViewController(
        $state,
        $stateParams,
        setTargetService,
        toastr,
        toastrConfig) {

        var vm = this;
        vm.formIsReady = false;

        init();

        function init() {
            setTargetService.getById($stateParams.id).then(function (result) {
                if (result) {
                    vm.setTarget = result;
                }
                else {
                    toastrConfig.positionClass = 'toast-top-center';
                    toastrConfig.autoDismiss = false;
                    toastr.error("There is no Set Target with id = '" + $stateParams.id + "' in the system.");
                }

                vm.formIsReady = true;
            });
        }
    }
}());
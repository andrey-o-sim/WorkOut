(function () {
    angular.module('woApp')
        .controller('SetViewController', SetViewController);

    SetViewController.$inject = [
        '$stateParams',
        'setService',
        'toastr',
        'toastrConfig'];

    function SetViewController(
        $stateParams,
        setService,
        toastr,
        toastrConfig) {

        var vm = this;
        vm.formIsReady = false;

        init();

        function init() {
            setService.getById($stateParams.id).then(function (result) {
                if (result) {
                    vm.set = result;
                }
                else {
                    toastrConfig.positionClass = 'toast-top-center';
                    toastrConfig.autoDismiss = false;
                    toastr.error("There is no Set with id = '" + $stateParams.id + "' in the system.");
                }

                vm.formIsReady = true;
            })
        }
    }
}());
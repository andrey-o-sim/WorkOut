(function () {
    angular
        .module('woApp')
        .controller('LogHomeController', LogHomeController);

    LogHomeController.$inject = [
        'logService'
    ];

    function LogHomeController(logService) {
        var vm = this;

        vm.formIsReady = false;

        init();

        function init() {
            logService.getAll().then(function (result) {
                vm.logs = result;
                vm.formIsReady = true;
            });
        }
    }
}());
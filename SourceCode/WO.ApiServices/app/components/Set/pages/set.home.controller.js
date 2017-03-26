(function () {
    angular
        .module('woApp')
        .controller('SetHomeController', SetHomeController);

    SetHomeController.$inject = [
        'setService',
        'workOutHelper'];

    function SetHomeController(
        setService,
        workOutHelper) {

        var vm = this;
        vm.formIsReady = false;
        vm.remove = remove;

        init();

        function init() {
            setService.getAll().then(function (result) {
                if (result) {
                    vm.sets = result;
                }

                vm.formIsReady = true;
            });
        }

        function remove(id) {
            setService.remove(id).then(function (result) {
                vm.sets = workOutHelper.removeElementFromArray(vm.sets, result.ResultItemId);
            });
        }
    }
})();

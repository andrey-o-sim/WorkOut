(function () {
    angular
        .module('woApp')
        .controller('approachHomeController', approachHomeController)

    approachHomeController.$inject = [
        'approachService',
        'workOutHelper'];

    function approachHomeController(
        approachService,
        workOutHelper) {

        var vm = this;
        vm.formIsReady = false;

        vm.remove = remove;
        init();

        function init() {
            approachService.getAll().then(function (result) {
                vm.approaches = result;
                vm.formIsReady = true;
            });
        }

        function remove(id) {
            approachService.remove(id).then(function (result) {
                if (result.Succeed) {
                    vm.approaches = workOutHelper.removeElementFromArray(vm.approaches, result.ResultItemId);
                }
            });
        }
    }
}());
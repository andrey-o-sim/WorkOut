(function () {
    angular
        .module('woApp')
        .controller('SetHomeController', SetHomeController);

    SetHomeController.$inject = [
        'setService',
        'workOutHelper',
        'toastr'];

    function SetHomeController(
        setService,
        workOutHelper,
        toastr) {

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

        function remove(set) {
            if (confirm("Do you realy want to remove the item?")) {
                setService.remove(set.Id).then(function (result) {
                    vm.sets = workOutHelper.removeElementFromArray(vm.sets, result.ResultItemId);
                    toastr.info("Set with Id '" + result.ResultItemId + "' was successfully removed.");
                });
            }
        }
    }
})();

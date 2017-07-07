(function () {
    angular
        .module('woApp')
        .controller('ApproachHomeController', ApproachHomeController)

    ApproachHomeController.$inject = [
        'approachService',
        'workOutHelper',
        'toastr'];

    function ApproachHomeController(
        approachService,
        workOutHelper,
        toastr) {

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
            if (confirm("Do you realy want to remove the item?")) {
                approachService.remove(id).then(function (result) {
                    if (result.Succeed) {
                        vm.approaches = workOutHelper.removeElementFromArray(vm.approaches, result.ResultItemId);
                        toastr.info("Approach with Id '" + result.ResultItemId + "' was successfully removed.");
                    }
                });
            }
        }
    }
}());
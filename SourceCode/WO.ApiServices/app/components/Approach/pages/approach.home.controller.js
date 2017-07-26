(function () {
    angular
        .module('woApp')
        .controller('ApproachHomeController', ApproachHomeController)

    ApproachHomeController.$inject = [
        '$uibModal',
        'approachService',
        'workOutHelper',
        'toastr'];

    function ApproachHomeController(
        $uibModal,
        approachService,
        workOutHelper,
        toastr) {

        var vm = this;
        vm.formIsReady = false;
        vm.remove = remove;
        vm.editApproach = editApproach;

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

        function editApproach(approachId,itemIndex) {

            var modalInstance = $uibModal.open({
                animation: true,
                backdrop: 'static',
                ariaLabelledBy: 'Approach Edit',
                templateUrl: '/app/components/Approach/forms/approach.form.html',
                controller: 'ApproachFormController',
                controllerAs: 'vm',
                resolve: {
                    id: function () {
                        return approachId;
                    }
                }
            });

            modalInstance.result.then(function (resultApproach) {
                vm.approaches[itemIndex] = resultApproach;
            },
            function () {
            });
        }
    }
}());
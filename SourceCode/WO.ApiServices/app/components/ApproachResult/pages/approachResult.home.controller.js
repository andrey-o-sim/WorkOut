(function () {
    angular
        .module('woApp')
        .controller('ApproachResultHomeController', ApproachResultHomeController);

    ApproachResultHomeController.$inject = [
        '$uibModal',
        'approachResultService',
        'toastr'
    ];

    function ApproachResultHomeController(
        $uibModal,
        approachResultService,
        toastr) {
        var vm = this;
        vm.formIsReady = false;

        vm.editApproach = editApproach;
        vm.remove = remove;

        init();

        function init() {
            approachResultService.getAll().then(function (result) {
                vm.approachResults = result;
                vm.formIsReady = true;
            });
        }

        function editApproach(approachResultId, itemIndex) {
            var modalInstance = $uibModal.open({
                animation: true,
                backdrop: 'static',
                ariaLabelledBy: 'Approach Result Edit',
                templateUrl: '/app/components/ApproachResult/forms/approachResult.form.html',
                controller: 'ApproachResultFormController',
                controllerAs: 'vm',
                resolve: {
                    id: function () {
                        return approachResultId;
                    }
                }
            });

            modalInstance.result.then(
                function (resultApproach) {
                    vm.approachResults[itemIndex] = resultApproach;
                },
                function () {
                });
        }

        function remove(id, itemIndex) {
            if (confirm("Do you realy want to remove the item?")) {
                approachResultService.remove(id).then(function (result) {
                    if (result.Succeed) {
                        vm.approachResults.splice(itemIndex, 1);
                        toastr.info("Approach Result with Id '" + result.ResultItemId + "' was successfully removed.");
                    }
                });
            }
        }
    }
}());
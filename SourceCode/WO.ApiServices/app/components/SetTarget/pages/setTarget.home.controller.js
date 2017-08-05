(function () {
    angular
        .module('woApp')
        .controller('SetTargetHomeController', SetTargetHomeController);

    SetTargetHomeController.$inject = [
        '$uibModal',
        'setTargetService',
        'toastr'
    ];

    function SetTargetHomeController(
        $uibModal,
        setTargetService,
        toastr) {
        var vm = this;
        vm.formIsReady = false;

        vm.editSetTarget = editSetTarget;
        vm.remove = remove;

        init();

        function init() {
            setTargetService.getAll().then(function (result) {
                vm.setTargets = result;
                vm.formIsReady = true;
            });
        }

        function editSetTarget(setTargetId, itemIndex) {
            var modalInstance = $uibModal.open({
                animation: true,
                backdrop: 'static',
                ariaLabelledBy: 'Set Target Edit',
                templateUrl: '/app/components/SetTarget/forms/setTarget.form.html',
                controller: 'SetTargetFormController',
                controllerAs: 'vm',
                resolve: {
                    id: function () {
                        return setTargetId;
                    }
                }
            });

            modalInstance.result.then(
                function (resultApproach) {
                    vm.setTargets[itemIndex] = resultApproach;
                },
                function () {
                });
        }

        function remove(id, itemIndex) {
            if (confirm("Do you realy want to remove the item?")) {
                setTargetService.remove(id).then(function (result) {
                    if (result.Succeed) {
                        vm.setTargets.splice(itemIndex, 1);
                        toastr.info("Set Target with Id '" + result.ResultItemId + "' was successfully removed.");
                    }
                });
            }
        }
    }
}());
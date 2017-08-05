(function () {
    angular
        .module('woApp')
        .controller('SetTargetFormController', SetTargetFormController);

    SetTargetFormController.$inject = [
        '$state',
        '$stateParams',
        '$uibModalInstance',
        'setTargetService',
        'id'
    ];

    function SetTargetFormController(
        $state,
        $stateParams,
        $uibModalInstance,
        setTargetService,
        id) {

        var vm = this;
        vm.formIsReady = false;
        vm.setTargetId = id;
        vm.title = 'Set Target';
        vm.save = save;
        vm.cancel = cancel;

        init();

        function init() {
            vm.setTarget = setTargetService.getEmptySetTargetResult();
            if (vm.setTargetId > 0) {
                setTargetService.getById(vm.setTargetId).then(function (result) {
                    vm.setTarget = result;
                    vm.formIsReady = true;
                });
            }
            else {
                vm.formIsReady = true;
            }
        }

        function save(setTarget) {
            if (isValidForm(setTarget)) {
                vm.disableSaveButton = true;
                setTargetService.save(setTarget).then(function (result) {
                    postSave(setTarget, result);
                });
            }
        }

        function postSave(setTarget, result) {
            if (result.Succeed) {
                setTarget.Id = result.ResultItemId;
                $uibModalInstance.close(setTarget);
            }
            else {
                vm.disableSaveButton = false;
            }
        }

        function isValidForm(setTarget) {
            vm.validator = {};
            var isValid = true;
            vm.validateForm = true;

            if (!setTarget.PlainNumberOfTimes && setTarget.PlainNumberOfTimes > 0) {
                vm.validator.ValidPlainNumberOfTimes = false;
                isValid = false;
            }

            return isValid;
        }

        function cancel() {
            $uibModalInstance.dismiss('cancel');
        }
    }
}());
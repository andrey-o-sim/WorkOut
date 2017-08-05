(function () {
    angular
        .module('woApp')
        .controller('ApproachResultFormController', ApproachResultFormController);

    ApproachResultFormController.$inject = [
        '$state',
        '$stateParams',
        '$uibModalInstance',
        'approachResultService',
        'id'
    ];

    function ApproachResultFormController(
        $state,
        $stateParams,
        $uibModalInstance,
        approachResultService,
        id) {

        var vm = this;
        vm.formIsReady = false;
        vm.approachResultId = id;
        vm.title = 'Approach Result';
        vm.save = save;
        vm.cancel = cancel;

        init();

        function init() {
            vm.approachResult = approachResultService.getEmptyApproachResult();
            if (vm.approachResultId > 0) {
                approachResultService.getById(vm.approachResultId).then(function (result) {
                    vm.approachResult = result;
                    vm.formIsReady = true;
                });
            }
            else {
                vm.formIsReady = true;
            }
        }

        function save(approachResult) {
            if (isValidForm(approachResult)) {
                vm.disableSaveButton = true;
                approachResultService.save(approachResult).then(function (result) {
                    postSave(approachResult, result);
                });
            }
        }

        function postSave(approachResult, result) {
            if (result.Succeed) {
                approachResult.Id = result.ResultItemId;
                $uibModalInstance.close(approachResult);
            }
            else {
                vm.disableSaveButton = false;
            }
        }

        function isValidForm(approachResult) {
            vm.validator = {};
            var isValid = true;
            vm.validateForm = true;

            if (!approachResult.MadeNumberOfTimes) {
                vm.validator.ValidMadeNumberOfTimes = false;
                isValid = false;
            }

            return isValid;
        }

        function cancel() {
            $uibModalInstance.dismiss('cancel');
        }
    }
}());
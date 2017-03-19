(function () {
    angular
        .module('woApp')
        .controller('ApproachAddEditController', ApproachAddEditController);

    ApproachAddEditController.$inject = [
        '$state',
        '$stateParams',
        '$uibModalInstance',
        'approachService',
        'id',
        'setId'];

    function ApproachAddEditController(
        $state,
        $stateParams,
        $uibModalInstance,
        approachService,
        id,
        setId) {

        var vm = this;
        vm.formIsReady = false;
        vm.approachId = id;
        vm.setId = setId;

        vm.title = id > 0 ? 'Edit Approach' : 'Add New Approach'

        vm.save = save;
        vm.cancel = cancel;

        init();

        function init() {
            vm.approach = {
                PlannedTimeForRest: {
                    Minutes: 0,
                    Seconds: 0
                },
                SpentTimeForRest: {
                    Minutes: 0,
                    Seconds: 0
                },
                SetId: vm.setId
            };

            if (vm.approachId > 0) {
                approachService.getById(vm.approachId).then(function (result) {
                    vm.approach = result;
                    vm.formIsReady = true;
                });
            }
            else {
                vm.formIsReady = true;
            }
        }

        function save(approach) {
            if (isValidForm(approach)) {
                vm.disableSaveButton = true;
                if (vm.approachId > 0) {
                    approachService.update(approach).then(function (result) {
                        postCreateOrUpdate(approach, result);
                    });
                }
                else {
                    approachService.create(approach).then(function (result) {
                        postCreateOrUpdate(approach, result);
                    });
                }
            }
        }

        function postCreateOrUpdate(approach, result) {
            if (result.Succeed) {
                approach.Id = result.ResultItemId;
                $uibModalInstance.close(approach);
            }
            else {
                vm.disableSaveButton = false;
            }
        }

        function isValidForm(approach) {
            vm.validator = {};
            var isValid = true;
            vm.validateForm = true;

            if (!approach.PlannedTimeForRest
                || (approach.PlannedTimeForRest.Minutes === 0 && approach.PlannedTimeForRest.Seconds === 0)) {
                vm.validator.ValidPlannedTimeForRest = false;
                isValid = false;
            }

            return isValid;
        }

        function cancel() {
            $uibModalInstance.dismiss('cancel');
        }
    }
}());
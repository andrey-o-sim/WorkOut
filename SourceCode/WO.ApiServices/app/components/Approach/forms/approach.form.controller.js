﻿(function () {
    angular
        .module('woApp')
        .controller('ApproachFormController', ApproachFormController);

    ApproachFormController.$inject = [
        '$state',
        '$stateParams',
        '$uibModalInstance',
        'approachService',
        'id'];

    function ApproachFormController(
        $state,
        $stateParams,
        $uibModalInstance,
        approachService,
        id) {

        var vm = this;
        vm.formIsReady = false;
        vm.approachId = id;
        vm.title = 'Edit Approach';
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
                }
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
                approachService.save(approach).then(function (result) {
                    postSave(approach, result);
                });
            }
        }

        function postSave(approach, result) {
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
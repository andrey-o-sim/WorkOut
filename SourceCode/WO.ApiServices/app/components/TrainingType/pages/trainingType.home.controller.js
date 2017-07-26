(function () {
    angular
        .module('woApp')
        .controller('TrainingTypeHomeController', TrainingTypeHomeController)

    TrainingTypeHomeController.$inject = [
        '$uibModal',
        'trainingTypeService',
        'workOutHelper',
        'toastr'];

    function TrainingTypeHomeController(
        $uibModal,
        trainingTypeService,
        workOutHelper,
        toastr) {

        var vm = this;
        vm.formIsReady = false;
        vm.addEditTrainingType = addEditTrainingType;

        vm.remove = remove;
        init();

        function init() {
            trainingTypeService.getAll().then(function (result) {
                vm.trainingTypes = result;
                vm.formIsReady = true;
            });
        }

        function addEditTrainingType(trainingTypeId, itemIndex) {
            var ariaLabel = trainingTypeId > 0 ? 'Training Type Edit' : 'Training Type New';

            var modalProperties = {
                ariaLabelledBy: ariaLabel,
                templateUrl: '/app/components/TrainingType/forms/trainingType.form.html',
                controller: 'TrainingTypeFormController',
                itemId: trainingTypeId
            };

            var modalInstance = openModal(modalProperties);

            modalInstance.result.then(
                function (resultTrainingType) {
                    if (trainingTypeId > 0) {
                        vm.trainingTypes[itemIndex] = resultTrainingType;
                    }
                    else {
                        vm.trainingTypes.push(resultTrainingType);
                    }
                },
                function () {
                });
        }

        function openModal(modalProperties) {
            var modalInstance = $uibModal.open({
                animation: true,
                backdrop: 'static',
                ariaLabelledBy: modalProperties.ariaLabell,
                templateUrl: modalProperties.templateUrl,
                controller: modalProperties.controller,
                controllerAs: 'vm',
                resolve: {
                    id: function () {
                        return modalProperties.itemId;
                    }
                }
            });

            return modalInstance;
        }

        function remove(trainingType) {
            if (confirm("Do you realy want to remove '" + trainingType.TypeTraining + "' ?")) {
                trainingTypeService.remove(trainingType.Id).then(function (result) {
                    if (result.Succeed) {
                        vm.trainingTypes = workOutHelper.removeElementFromArray(vm.trainingTypes, result.ResultItemId);
                        toastr.info("Training type '" + trainingType.TypeTraining + "' was successfully removed.");
                    }
                });
            }
        }
    }
}());
(function () {
    angular
        .module('woApp')
        .controller('TrainingFormController', TrainingFormController);

    TrainingFormController.$inject = [
        '$q',
        '$state',
        '$stateParams',
        'trainingService',
        'trainingTypeService',
        'setService',
        'workOutHelper',
        'toastr',
        'toastrConfig',
        '$uibModal'];

    function TrainingFormController(
        $q,
        $state,
        $stateParams,
        trainingService,
        trainingTypeService,
        setService,
        workOutHelper,
        toastr,
        toastrConfig,
        $uibModal) {

        var vm = this;

        vm.save = save;
        vm.removeSet = removeSet;
        vm.addTrainingType = addTrainingType;

        vm.editForm = $stateParams.id && $stateParams.id > 0;

        init().then(function (training) {
            if (training) {
                vm.training = training;
                vm.training.TrainingDate = vm.training.TrainingDate ? moment(vm.training.TrainingDate) : moment();
            }
            vm.formIsReady = true;
        });

        function init() {
            trainingTypeService.getAll().then(function (result) {
                vm.TrainingTypes = result;
            });

            if ($stateParams.training) {
                return $q.when($stateParams.training);
            }
            else {
                if (vm.editForm) {
                    return trainingService.getById($stateParams.id).then(function (result) {

                        if (result) {
                            return result;
                        }
                        else {
                            toastrConfig.positionClass = 'toast-top-center';
                            toastrConfig.autoDismiss = false;
                            toastr.error("There is no Training with id = '" + $stateParams.id + "' in the system.");

                            return $q.when(null);
                        }
                    });
                }
                else {
                    var newTraining = {
                        TrainingType: {},
                        MainTrainingPurpose: '',
                        Description: '',
                        Sets: []
                    };

                    return $q.when(newTraining);
                }
            }
        }

        function save(training) {
            if (isValidForm(training)) {
                vm.disableButton = true;

                trainingService.save(training).then(function (result) {
                    if (result.Succeed) {
                        $state.go('trainingHome');
                    }
                    else {
                        vm.disableButton = false;
                    }
                });
            }
        }

        function removeSet(setId) {
            setService.remove(setId).then(function (result) {
                if (result.Succeed) {
                    vm.training.Sets = workOutHelper.removeElementFromArray(vm.training.Sets, result.ResultItemId);
                }
            });
        }

        function isValidForm(training) {
            vm.validator = {};
            var isValid = true;
            vm.validateForm = true;

            if (!training.TrainingType || !training.TrainingType.Id || !training.TrainingType.TypeTraining === '') {
                isValid = false;
                vm.validator.ValidTrainingType = false;
            }

            if (!training.MainTrainingPurpose || training.MainTrainingPurpose === '') {
                isValid = false;
                vm.validator.ValidMainTrainingPurpose = false;
            }

            if (!training.TrainingDate) {
                isValid = false;
                vm.validator.ValidTrainingDate = false;
            }

            if (!training.Sets || training.Sets.length === 0) {
                isValid = false;
                vm.validator.ValidSets = false;
            }

            return isValid;
        }

        function addTrainingType() {
            var modalInstance = $uibModal.open({
                animation: true,
                backdrop: 'static',
                ariaLabelledBy: 'Add Training Type',
                templateUrl: '/app/components/TrainingType/forms/trainingType.form.html',
                controller: 'TrainingTypeFormController',
                controllerAs: 'vm',
                resolve: {
                    id: 0
                }
            });

            modalInstance.result.then(
                function (resultTrainingType) {
                    vm.training.TrainingType = resultTrainingType;
                    vm.TrainingTypes.push(resultTrainingType);
                },
                function () {
                });
        }
    }
})();

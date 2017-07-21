(function () {

    angular
        .module('woApp')
        .controller('TrainingEditController', TrainingEditController);

    TrainingEditController.$inject = [
        '$state',
        '$stateParams',
        'trainingService',
        'trainingTypeService',
        'setService',
        'workOutHelper',
        'toastr',
        'toastrConfig'];

    function TrainingEditController(
        $state,
        $stateParams,
        trainingService,
        trainingTypeService,
        setService,
        workOutHelper,
        toastr,
        toastrConfig) {

        var vm = this;
        vm.save = save;
        vm.formIsReady = false;

        vm.removeSet = removeSet;

        init();

        function init() {
            trainingService.getById($stateParams.id).then(function (result) {

                if (result) {
                    vm.training = result;
                }
                else {
                    toastrConfig.positionClass = 'toast-top-center';
                    toastrConfig.autoDismiss = false;
                    toastr.error("There is no Training with id = '" + $stateParams.id + "' in the system.");
                }

                vm.formIsReady = true;
            });

            trainingTypeService.getAll().then(function (result) {
                vm.TrainingTypes = result;
            });
        }

        function save(training) {
            if (isValidForm(training)) {
                vm.disableButton = true;

                vm.training.StartDateTime = vm.training.StartDateTime.format();
                vm.training.EndDateTime = vm.training.EndDateTime.format();

                trainingService.update(training).then(function (result) {
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

            var startDate = moment();
            startDate = startDate.set({
                'hour': training.StartDateTime.Hours,
                'minute': training.StartDateTime.Minutes,
                'second': training.StartDateTime.Seconds
            });

            if (training.EndDateTime) {
                var endDate = moment();
                endDate = endDate.set({
                    'hour': training.EndDateTime.Hours,
                    'minute': training.EndDateTime.Minutes,
                    'second': training.EndDateTime.Seconds
                });

                if (startDate > endDate) {
                    isValid = false;
                    vm.validator.ValidEndDate = false;
                }
            }

            if (training.StartDateTime && (!training.Sets || training.Sets.length === 0)) {
                isValid = false;
                vm.validator.ValidSets = false;
            }

            return isValid;
        }
    }
})();

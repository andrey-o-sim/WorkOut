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
        'toastrConfig'];

    function TrainingFormController(
        $q,
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
        vm.removeSet = removeSet;

        vm.editForm = $stateParams.id && $stateParams.id > 0;

        init().then(function (training) {
            if (training) {
                vm.training = training;
                vm.training.StartDateTime = vm.training.StartDateTime ? moment(vm.training.StartDateTime) : moment();
                vm.training.EndDateTime = vm.training.EndDateTime ? moment(vm.training.EndDateTime) : moment();
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
                        StartDateTime: moment(),
                        EndDateTime: moment(),
                        Sets: []
                    };

                    return $q.when(newTraining);
                }
            }
        }

        function save(training) {
            if (isValidForm(training)) {
                vm.disableButton = true;

                var timeZoneLength = 6;
                training.StartDateTime = training.StartDateTime.format().substring(0, training.StartDateTime.format().length - timeZoneLength);
                training.EndDateTime = training.EndDateTime.format().substring(0, training.EndDateTime.format().length - timeZoneLength);

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

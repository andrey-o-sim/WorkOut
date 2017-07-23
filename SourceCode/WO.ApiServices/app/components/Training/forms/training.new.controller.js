(function () {
    angular
        .module('woApp')
        .controller('TrainingNewController', TrainingNewController);

    TrainingNewController.$inject = [
        '$state',
        '$stateParams',
        'trainingService',
        'trainingTypeService'];

    function TrainingNewController(
        $state,
        $stateParams,
        trainingService,
        trainingTypeService) {
        var vm = this;

        vm.save = save;

        init();

        function init() {
            if ($stateParams.training) {
                vm.training = $stateParams.training;
            }
            else {
                vm.training = {
                    TrainingType: {},
                    MainTrainingPurpose: '',
                    Description: '',
                    StartDateTime: moment(),
                    EndDateTime: moment(),
                    Sets: []
                };
            }

            trainingTypeService.getAll().then(function (result) {
                vm.TrainingTypes = result;
            });
        }

        function save(training) {
            if (isValidForm(training)) {
                vm.disableButton = true;
                trainingService.create(training).then(function (result) {
                    if (result.Succeed) {
                        $state.go('trainingHome');
                    }
                    else {
                        vm.disableButton = false;
                    }
                });
            }
        }

        function isValidForm(training) {
            vm.validator = {};
            var isValid = true;
            vm.validateForm = true;

            if (!training.TrainingType || !training.TrainingType.Id || training.TrainingType.TypeTraining === '') {
                isValid = false;
                vm.validator.ValidTrainingType = false;
            }

            if (!training.MainTrainingPurpose || training.MainTrainingPurpose === '') {
                isValid = false;
                vm.validator.ValidMainTrainingPurpose = false;
            }

            return isValid;
        }
    }
})();

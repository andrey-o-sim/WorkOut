(function () {
    angular
        .module('woApp')
        .controller('TrainingNewController', TrainingNewController);

    TrainingNewController.$inject = [
        '$state',
        'trainingService',
        'trainingTypeService'];

    function TrainingNewController(
        $state,
        trainingService,
        trainingTypeService) {
        var vm = this;

        vm.save = save;

        init();

        function init() {
            vm.training = {
                TrainingType: {},
                MainTrainingPurpose: '',
                Description: ''
            };

            trainingTypeService.getAll().then(function (result) {
                vm.TrainingTypes = result;
            });
        }

        function save(training) {
            if (isValidForm(training)) {
                vm.disableButton = true;
                trainingService.create(training).then(function (result) {
                    if (result.Succeed) {
                        $state.go('trainingEdit', { 'id': + result.ResultItemId });
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

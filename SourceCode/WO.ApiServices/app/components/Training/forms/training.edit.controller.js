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
        'workOutHelper'];

    function TrainingEditController(
        $state,
        $stateParams,
        trainingService,
        trainingTypeService,
        setService,
        workOutHelper) {

        var vm = this;
        vm.save = save;
        vm.formIsReady = false;

        vm.editSet = editSet;
        vm.removeSet = removeSet;

        init();

        function init() {
            trainingService.getById($stateParams.id).then(function (result) {
                vm.training = result;
                vm.formIsReady = true;
            });

            trainingTypeService.getAll().then(function (result) {
                vm.TrainingTypes = result;
            });
        }

        function save(training) {

        }

        function editSet(setId) {

        }

        function removeSet(setId) {
            setService.remove(setId).then(function (result) {
                if (result.Succeed) {
                    vm.training.Sets = workOutHelper.removeElementFromArray(vm.training.Sets, result.ResultItemId);
                }
            });
        }
    }
})();

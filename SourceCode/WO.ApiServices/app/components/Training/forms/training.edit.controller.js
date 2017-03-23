(function () {

    angular
        .module('woApp')
        .controller('TrainingEditController', TrainingEditController);

    TrainingEditController.$inject = [
        '$state',
        '$stateParams',
        'trainingService',
        'trainingTypeService'];

    function TrainingEditController(
        $state,
        $stateParams,
        trainingService,
        trainingTypeService) {

        var vm = this;
        vm.save = save;
        vm.formIsReady = false;

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
    }
})();

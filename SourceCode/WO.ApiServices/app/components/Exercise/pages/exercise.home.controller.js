angular
    .module('woApp')
    .controller('exerciseHomeController', exerciseHomeController);

exerciseHomeController.$inject = [
    'exerciseService',
    'workOutHelper'];

function exerciseHomeController(exerciseService,
    workOutHelper) {

    var vm = this;
    vm.formIsReady = false;
    vm.remove = remove;

    init();

    function init() {
        exerciseService.getAll().then(function (result) {
            vm.exercises = result;
            vm.formIsReady = true;
        });
    }

    function remove(id) {
        exerciseService.remove(id).then(function (result) {
            if (result.Succeed) {
                vm.exercises = workOutHelper.removeElementFromArray(vm.exercises, result.ResultItemId);
            }
        })
    }
}
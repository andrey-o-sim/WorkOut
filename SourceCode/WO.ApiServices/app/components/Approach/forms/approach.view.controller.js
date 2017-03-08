angular
    .module('woApp')
    .controller('approachViewController', approachViewController);

approachViewController.$inject = [
    'approachService',
    '$state',
    '$stateParams'];

function approachViewController(
    approachService,
    $state,
    $stateParams) {

    var vm = this;
    vm.formIsReady = false;

    init();

    function init() {
        approachService.getById($stateParams.id).then(function (result) {
            vm.approach = result;
            vm.formIsReady = true;
        });
    }
}

(function () {
    angular
        .module('woApp')
        .controller('ApproachViewController', ApproachViewController);

    ApproachViewController.$inject = [
        '$state',
        '$stateParams',
        'approachService'];

    function ApproachViewController(
        $state,
        $stateParams,
        approachService) {

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
}());
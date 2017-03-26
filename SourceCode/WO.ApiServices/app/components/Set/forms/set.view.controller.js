(function () {
    angular.module('woApp')
        .controller('SetViewController', SetViewController);

    SetViewController.$inject = [
        '$stateParams',
        'setService'];

    function SetViewController(
        $stateParams,
        setService) {

        var vm = this;
        vm.formIsReady = false;

        init();

        function init() {
            setService.getById($stateParams.id).then(function (result) {
                vm.set = result;
                vm.formIsReady = true;
            })
        }
    }
}());
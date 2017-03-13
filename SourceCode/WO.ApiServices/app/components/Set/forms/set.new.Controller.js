(function () {
    angular.module('woApp')
        .controller('setNewController', setNewController);

    setNewController.$inject = [
        'setService',
        '$state'];

    function setNewController(
        setService,
        $state) {

        var vm = this;

        vm.save = save;

        init();

        function init() {

        }

        function save(set) {
            setService.create(set).then(function (result) {
                if (result.Succeed) {
                    $state.go('setHome');
                }
            });
        }
    }
}());
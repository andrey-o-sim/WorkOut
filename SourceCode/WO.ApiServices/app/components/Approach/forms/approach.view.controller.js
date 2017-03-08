    angular
        .module('woApp')
        .controller('approachViewController', approachViewController);

    approachViewController.$inject = ['$location'];

    function approachViewController($location) {
        var vm = this;
        vm.title = 'approach';

        activate();

        function activate() { }
    }

(function () {
    angular.module('woApp')
        .controller('setViewController', setViewController);

    setViewController.$inject = ['setService'];

    function setViewController(setService) {
        var vm = this;

        init();

        function init() {

        }
    }
}());
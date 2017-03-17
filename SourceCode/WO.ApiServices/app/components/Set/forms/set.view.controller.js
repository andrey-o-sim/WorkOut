(function () {
    angular.module('woApp')
        .controller('SetViewController', SetViewController);

    SetViewController.$inject = ['setService'];

    function SetViewController(setService) {
        var vm = this;

        init();

        function init() {

        }
    }
}());
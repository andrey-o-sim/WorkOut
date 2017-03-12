(function () {
    angular.module('woApp')
        .controller('setEditController', setEditController)

    setEditController.$inject = ['setService'];

    function setEditController(setService) {
        var vm = this;

        init();

        function init() {

        }
    }
}());
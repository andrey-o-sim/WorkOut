(function () {
    angular.module('woApp')
        .controller('setNewController', setNewController);

    setNewController.$inject = ['setService'];

    function setNewController(setService) {
        var vm = this;

        init();

        function init() {

        }
    }
}());
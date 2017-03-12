(function () {
    angular
        .module('woApp')
        .controller('setHomeController', setHomeController);

    setHomeController.$inject = ['setService'];

    function setHomeController(setService) {
        var vm = this;

        init();

        function init() { }
    }
})();

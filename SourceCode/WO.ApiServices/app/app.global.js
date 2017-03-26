(function () {
    angular
        .module('woApp').run(initApplication)

    initApplication.$inject = [
        '$rootScope',
        '$window']
    function initApplication(
        $rootScope,
        $window) {
        $rootScope.close = close;

        function close() {
            $window.history.back();
        }
    }
}());
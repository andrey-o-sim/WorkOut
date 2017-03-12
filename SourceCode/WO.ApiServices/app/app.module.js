(function () {
    angular
        .module('woApp', ['ui.router', 'ui.bootstrap']);

    angular
        .module('woApp').config(['$locationProvider', function ($locationProvider) {
            $locationProvider.hashPrefix('');
        }]);
}());

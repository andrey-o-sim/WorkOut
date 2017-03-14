(function () {
    angular
        .module('woApp', ['ui.router', 'ui.bootstrap','angularValidator']);

    angular
        .module('woApp').config(['$locationProvider', function ($locationProvider) {
            $locationProvider.hashPrefix('');
        }]);
}());

(function () {
    angular
        .module('woApp', ['ui.router', 'ui.bootstrap', 'angularValidator', 'ngSanitize', 'ui.select']);

    angular
        .module('woApp').config(['$locationProvider', function ($locationProvider) {
            $locationProvider.hashPrefix('');
        }]);
}());

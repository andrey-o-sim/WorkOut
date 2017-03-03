angular
.module('woApp', ['ui.router']);

angular
.module('woApp').config(['$locationProvider', function ($locationProvider) {
    $locationProvider.hashPrefix('');
}]);
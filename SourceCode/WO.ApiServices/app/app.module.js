angular
.module('woApp', ['ngRoute']);

angular
.module('woApp').config(['$locationProvider', function ($locationProvider) {
    $locationProvider.hashPrefix('');
}]);
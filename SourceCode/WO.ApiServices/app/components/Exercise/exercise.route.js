angular
    .module('woApp')
    .config(routeConfig)

function routeConfig($stateProvider) {
    var homeRoute = {
        name: 'exerciseHome',
        url: '/exercise',
        templateUrl: '/app/components/Exercise/pages/exercise.home.html',
        controller: 'exerciseHomeController',
        controllerAs: 'vm'
    };

    $stateProvider.state(homeRoute);
}
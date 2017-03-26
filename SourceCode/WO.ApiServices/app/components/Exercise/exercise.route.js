(function () {
    angular
        .module('woApp')
        .config(routeConfig)

    function routeConfig($stateProvider) {
        var homeRoute = {
            name: 'exerciseHome',
            url: '/exercise',
            templateUrl: '/app/components/Exercise/pages/exercise.home.html',
            controller: 'ExerciseHomeController',
            controllerAs: 'vm'
        };

        $stateProvider.state(homeRoute);
    }
}());
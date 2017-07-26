(function () {
    angular
        .module('woApp')
        .config(routeConfig)

    function routeConfig($stateProvider) {
        var homeRoute = {
            name: 'trainingTypeHome',
            url: '/trainingType',
            templateUrl: '/app/components/TrainingType/pages/trainingType.home.html',
            controller: 'TrainingTypeHomeController',
            controllerAs: 'vm'
        };

        var viewRoute = {
            name: 'trainingTypeView',
            url: '/trainingType/view/{id}',
            templateUrl: '/app/components/TrainingType/forms/trainingType.view.html',
            controller: 'TrainingTypeViewController',
            controllerAs: 'vm'
        };

        $stateProvider.state(homeRoute);
        $stateProvider.state(viewRoute);
    }
}());
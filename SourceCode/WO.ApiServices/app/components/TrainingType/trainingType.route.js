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

        var newRoute = {
            name: 'trainingTypeNew',
            url: '/trainingType/new',
            templateUrl: '/app/components/TrainingType/forms/trainingType.new.html',
            controller: 'TrainingTypeNewController',
            controllerAs: 'vm'
        };

        var editRoute = {
            name: 'trainingTypeEdit',
            url: '/trainingType/edit/{id}',
            templateUrl: '/app/components/TrainingType/forms/trainingType.edit.html',
            controller: 'TrainingTypeEditController',
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
        $stateProvider.state(newRoute);
        $stateProvider.state(editRoute);
        $stateProvider.state(viewRoute);
    }
}());
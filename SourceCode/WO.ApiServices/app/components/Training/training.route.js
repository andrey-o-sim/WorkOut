(function () {
    angular.module('woApp')
            .config(routeConfig);

    function routeConfig($stateProvider) {
        var homeRoute = {
            name: 'trainingHome',
            url: '/training',
            templateUrl: '/app/components/Training/pages/training.home.html',
            controller: 'TrainingHomeController',
            controllerAs: 'vm'
        };

        var newRoute = {
            name: 'trainingNew',
            url: '/training/new',
            templateUrl: '/app/components/Training/forms/training.new.html',
            controller: 'TrainingNewController',
            controllerAs: 'vm'
        };

        var editRoute = {
            name: 'trainingEdit',
            url: '/training/edit/{id}',
            templateUrl: '/app/components/Training/forms/training.edit.html',
            controller: 'TrainingEditController',
            controllerAs: 'vm'
        };

        var viewRoute = {
            name: 'trainingView',
            url: '/training/view/{id}',
            templateUrl: '/app/components/Training/forms/training.View.html',
            controller: 'TrainingViewController',
            controllerAs: 'vm'
        };

        $stateProvider.state(homeRoute);
        $stateProvider.state(newRoute);
        $stateProvider.state(editRoute);
        $stateProvider.state(viewRoute);
    }
}());
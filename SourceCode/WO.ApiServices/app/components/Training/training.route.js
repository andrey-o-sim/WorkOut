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
            templateUrl: '/app/components/Training/forms/training.form.html',
            controller: 'TrainingFormController',
            controllerAs: 'vm',
            params: {
                training: null
            }
        };

        var editRoute = {
            name: 'trainingEdit',
            url: '/training/edit/{id}',
            templateUrl: '/app/components/Training/forms/training.form.html',
            controller: 'TrainingFormController',
            controllerAs: 'vm',
            params: {
                training: null
            }
        };

        var viewRoute = {
            name: 'trainingView',
            url: '/training/view/{id}',
            templateUrl: '/app/components/Training/forms/training.view.html',
            controller: 'TrainingViewController',
            controllerAs: 'vm'
        };

        $stateProvider.state(homeRoute);
        $stateProvider.state(newRoute);
        $stateProvider.state(editRoute);
        $stateProvider.state(viewRoute);
    }
}());
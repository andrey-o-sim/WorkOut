(function () {
    angular.module('woApp')
        .config(routeConfig);

    function routeConfig($stateProvider) {
        var homeRoute = {
            name: 'setHome',
            url: '/set',
            templateUrl: '/app/components/Set/pages/set.home.html',
            controller: 'SetHomeController',
            controllerAs: 'vm'
        };

        var newRoute = {
            name: 'setNew',
            url: '/set/new',
            templateUrl: '/app/components/Set/forms/set.form.html',
            controller: 'SetFormController',
            controllerAs: 'vm',
            params: {
                training: null
            }
        };

        var editRoute = {
            name: 'setEdit',
            url: '/set/edit/{id}',
            templateUrl: '/app/components/Set/forms/set.form.html',
            controller: 'SetFormController',
            controllerAs: 'vm',
            params: {
                training: null
            }
        };

        var viewRoute = {
            name: 'setView',
            url: '/set/view/{id}',
            templateUrl: '/app/components/Set/forms/set.View.html',
            controller: 'SetViewController',
            controllerAs: 'vm'
        };

        $stateProvider.state(homeRoute);
        $stateProvider.state(newRoute);
        $stateProvider.state(editRoute);
        $stateProvider.state(viewRoute);
    }
}());
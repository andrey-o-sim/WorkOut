(function () {
    angular.module('woApp')
        .config(routeConfig);

    function routeConfig($stateProvider) {
        var homeRoute = {
            name: 'setHome',
            url: '/setHome',
            templateUrl: '/app/components/Set/pages/set.home.html',
            controller: 'setHomeController',
            controllerAs: 'vm'
        };

        var newRoute = {
            name: 'setNew',
            url: '/setNew',
            templateUrl: '/app/components/Set/forms/set.new.html',
            controller: 'setNewController',
            controllerAs: 'vm'
        };

        var editRoute = {
            name: 'setEdit',
            url: '/setEdit',
            templateUrl: '/app/components/Set/forms/set.edit.html',
            controller: 'setEditController',
            controllerAs: 'vm'
        };

        var viewRoute = {
            name: 'setView',
            url: '/setView',
            templateUrl: '/app/components/Set/forms/set.View.html',
            controller: 'setViewController',
            controllerAs: 'vm'
        };

        $stateProvider.state(homeRoute);
        $stateProvider.state(newRoute);
        $stateProvider.state(editRoute);
        $stateProvider.state(viewRoute);
    }
}());
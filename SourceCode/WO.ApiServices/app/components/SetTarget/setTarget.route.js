(function () {
    angular
        .module('woApp')
        .config(routeConfig)

    function routeConfig($stateProvider) {
        var homeRoute = {
            name: 'setTargetHome',
            url: '/setTarget',
            templateUrl: '/app/components/SetTarget/pages/setTarget.home.html',
            controller: 'SetTargetHomeController',
            controllerAs: 'vm'
        };

        var viewRoute = {
            name: 'setTargetView',
            url: '/setTarget/view/{id}',
            templateUrl: '/app/components/SetTarget/forms/setTarget.view.html',
            controller: 'SetTargetViewController',
            controllerAs: 'vm'
        };

        $stateProvider.state(homeRoute);
        $stateProvider.state(viewRoute);
    }
}());
(function () {
    angular.module('woApp')
        .config(routeConfig);

    function routeConfig($stateProvider) {
        var homeRoute = {
            name: 'logHome',
            url: '/log',
            templateUrl: '/app/components/Log/log.home.html',
            controller: 'LogHomeController',
            controllerAs: 'vm'
        };

        $stateProvider.state(homeRoute);
    }
}());
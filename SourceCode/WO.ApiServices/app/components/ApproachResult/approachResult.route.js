(function () {
    angular
        .module('woApp')
        .config(routeConfig)

    function routeConfig($stateProvider) {
        var homeRoute = {
            name: 'approachResultHome',
            url: '/approachResult',
            templateUrl: '/app/components/ApproachResult/pages/approachResult.home.html',
            controller: 'ApproachResultHomeController',
            controllerAs: 'vm'
        };

        var viewRoute = {
            name: 'approachResultView',
            url: '/approachResult/view/{id}',
            templateUrl: '/app/components/ApproachResult/forms/approachResult.view.html',
            controller: 'ApproachResultViewController',
            controllerAs: 'vm'
        };

        $stateProvider.state(homeRoute);
        $stateProvider.state(viewRoute);
    }
}());
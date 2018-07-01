(function () {
    angular
        .module('woApp')
        .config(routeConfig)

    routeConfig.$inject = ['$stateProvider'];

    function routeConfig($stateProvider) {
        var homeRoute = {
            name: 'approachHome',
            url: '/approach',
            templateUrl: '/app/components/Approach/pages/approach.home.html',
            controller: 'ApproachHomeController',
            controllerAs: 'vm'
        };

        var viewRoute = {
            name: 'approachView',
            url: '/approach/view/{id}',
            templateUrl: '/app/components/Approach/forms/approach.view.html',
            controller: 'ApproachViewController',
            controllerAs: 'vm'
        };

        $stateProvider.state(homeRoute);
        $stateProvider.state(viewRoute);
    }
}());
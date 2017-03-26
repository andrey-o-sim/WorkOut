(function () {
    angular
        .module('woApp')
        .config(routeConfig)

    function routeConfig($stateProvider) {
        var homeRoute = {
            name: 'approachHome',
            url: '/approach',
            templateUrl: '/app/components/Approach/pages/approach.home.html',
            controller: 'ApproachHomeController',
            controllerAs: 'vm'
        };

        var newRoute = {
            name: 'approachNew',
            url: '/approach/new',
            templateUrl: '/app/components/Approach/forms/approach.new.html',
            controller: 'ApproachNewController',
            controllerAs: 'vm'
        };

        var editRoute = {
            name: 'approachEdit',
            url: '/approach/edit/{id}',
            templateUrl: '/app/components/Approach/forms/approach.edit.html',
            controller: 'ApproachEditController',
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
        $stateProvider.state(newRoute);
        $stateProvider.state(editRoute);
        $stateProvider.state(viewRoute);
    }
}());
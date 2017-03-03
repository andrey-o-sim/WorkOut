angular
    .module('woApp').config(routeConfig)

function routeConfig($stateProvider) {
    var homeRoute = {
        name: 'trainingTypeHome',
        url: '/trainingType',
        templateUrl: '/app/components/TrainingType/pages/trainingType.home.html',
        controller: 'trainingTypeHomeController',
        controllerAs: 'vm'
    };

    var newRoute = {
        name: 'trainingTypeNew',
        url: '/trainingType/new',
        templateUrl: '/app/components/TrainingType/forms/trainingType.new.html',
        controller: 'trainingTypeNewController',
        controllerAs: 'vm'
    };

    var editRoute = {
        name: 'trainingTypeEdit',
        url: '/trainingType/edit/{id}',
        templateUrl: '/app/components/TrainingType/forms/trainingType.edit.html',
        controller: 'trainingTypeEditController',
        controllerAs: 'vm'
    };

    var viewRoute = {
        name: 'trainingTypeView',
        url: '/trainingType/view/{id}',
        templateUrl: '/app/components/TrainingType/forms/trainingType.view.html',
        controller: 'trainingTypeViewController',
        controllerAs: 'vm'
    };

    $stateProvider.state(homeRoute);
    $stateProvider.state(newRoute);
    $stateProvider.state(editRoute);
    $stateProvider.state(viewRoute);
}

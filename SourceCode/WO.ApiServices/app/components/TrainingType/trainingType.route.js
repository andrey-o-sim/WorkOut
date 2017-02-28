angular
    .module('woApp').config(routeConfig)

function routeConfig($routeProvider, $locationProvider) {
    $routeProvider.when('/trainingType/new',
        {
            controller: 'trainingTypeNewController',
            templateUrl: 'app/components/TrainingType/forms/trainingType.new.html',
        });
    $routeProvider.when('/trainingType/edit/:id',
        {
            controller: 'trainingTypeEditController',
            templateUrl: 'app/components/TrainingType/forms/trainingType.edit.html',
        });
    $routeProvider.when('/trainingType/view/:id',
        {
            controller: 'trainingTypeViewController',
            templateUrl: 'app/components/TrainingType/forms/trainingType.view.html',
        });
}

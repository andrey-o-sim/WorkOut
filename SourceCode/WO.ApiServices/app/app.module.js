(function () {
    angular
        .module('woApp', [
            'ui.router',
            'ui.bootstrap',
            'angularValidator',
            'ngSanitize',
            'ui.select',
            'ui.bootstrap.datetimepicker',
            'ngAnimate',
            'toastr',
            'g1b.datetime-range',
            'ngMaterial',
            'ngRoute'
        ]);

    angular
        .module('woApp').config(['$locationProvider', function ($locationProvider) {
            $locationProvider.hashPrefix('');
        }]);
}());

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
            'g1b.datetime-range'
        ]);

    angular
        .module('woApp').config(['$locationProvider', function ($locationProvider) {
            $locationProvider.hashPrefix('');
        }]);
}());

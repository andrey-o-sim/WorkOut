(function () {
    angular
        .module('woApp')
        .factory('logService', logService);

    logService.$inject = [
        '$http'
    ]

    var serviceUrl = "/api/Log/";

    function logService($http) {
        var service = {
            getAll: getAll
        }

        return service;

        function getAll() {
            return $http.get(serviceUrl)
                .then(success, error);

            function success(response) {
                var result = response ? response.data : {};
                return result;
            }

            function error(error) {
                workOutHelper.writeErrorMessageToConsole(error);
                return [];
            }
        }
    }
}());
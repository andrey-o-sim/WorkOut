(function () {
    angular
        .module('woApp')
    .factory('approachService', approachService);

    approachService.$inject = [
        '$http',
        'workOutHelper'];

    var serviceUrl = "/api/Approach/";

    function approachService(
        $http,
        workOutHelper) {

        var service = {
            getById: getById,
            getAll: getAll,
            create: create,
            update: update,
            remove: remove
        };

        return service;

        function getAll() {
            return $http.get(serviceUrl)
                .then(success, error);

            function success(response) {
                var result = response ? response.data : {};
                return result;
            }

            function error(error) {
                workOutHelper.writeErrorMessageToConsole(response);
            }
        }

        function getById(id) {
            return $http.get(serviceUrl + id)
                .then(success, error)

            function success(response) {
                var result = response ? response.data : {};
                return result;
            }

            function error(error) {
                workOutHelper.writeErrorMessageToConsole(response);
            }
        }

        function create(approach) {
            return $http.post(serviceUrl, approach)
                .then(success, error);

            function success(response) {
                var result = response ? response.data : {};
                return result;
            }

            function error(error) {
                workOutHelper.writeErrorMessageToConsole(response);
            }
        }

        function update(approach) {
            return $http.put(serviceUrl, approach)
                .then(success, error);

            function success(response) {
                var result = response ? response.data : {};
                return result;
            }

            function error(error) {
                workOutHelper.writeErrorMessageToConsole(response);
            }
        }

        function remove(id) {
            return $http.delete(serviceUrl + id)
                .then(success, error);

            function success(response) {
                var result = response ? response.data : {};
                return result;
            }

            function error(error) {
                workOutHelper.writeErrorMessageToConsole(response);
            }
        }
    }
}());
(function () {
    angular.module('woApp')
        .factory('setService', setService);

    setService.$inject = ['$http', 'workOutHelper'];

    var serviceUrl = '/api/Set/';

    function setService(
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

        function getById(id) {
            return $http.get(serviceUrl + id)
                .then(success, error);

            function success(response) {
                var result = response ? response.data : {};
                return result;
            }

            function error(error) {
                workOutHelper.writeErrorMessageToConsole(response);
                return {};
            }
        }

        function getAll() {
            return $http.get(serviceUrl)
                .then(success, error);

            function success(response) {
                var result = response ? response.data : {};
                return result;
            }

            function error(error) {
                workOutHelper.writeErrorMessageToConsole(response);
                return [];
            }
        }

        function create(set) {
            return $http.post(serviceUrl, set)
                .then(success, error);

            function success(response) {
                var result = response ? response.data : {};
                return result;
            }

            function error(error) {
                workOutHelper.writeErrorMessageToConsole(response);
                return { Succeed: false };
            }
        }

        function update(set) {
            return $http.put(serviceUrl, set)
                .then(success, error);

            function success(response) {
                var result = response ? response.data : {};
                return result;
            }

            function error(error) {
                workOutHelper.writeErrorMessageToConsole(response);
                return { Succeed: false };
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
                return { Succeed: false };
            }
        }
    }
}())
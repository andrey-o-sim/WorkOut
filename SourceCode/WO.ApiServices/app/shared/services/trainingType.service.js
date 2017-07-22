(function () {
    angular
        .module('woApp')
        .factory('trainingTypeService', trainingTypeService);

    trainingTypeService.$inject = [
        '$http',
        'workOutHelper'];

    var serviceUrl = "/api/TrainingType/";

    function trainingTypeService(
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
                .then(success, error)

            function success(response) {
                var result = response ? response.data : {};
                return result;
            }

            function error(error) {
                workOutHelper.writeErrorMessageToConsole(error);
                if (error.status == "404") {
                    return null;
                }
                else {
                    return {};
                }
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
                workOutHelper.writeErrorMessageToConsole(error);
                return [];
            }
        }

        function create(trainingType) {
            return $http.post(serviceUrl, trainingType)
                .then(success, error);

            function success(response) {
                var result = response ? response.data : {};
                return result;
            }

            function error(error) {
                workOutHelper.writeErrorMessageToConsole(error);
                return { Succeed: false };
            }
        }

        function update(trainingType) {
            return $http.put(serviceUrl, trainingType)
                .then(success, error);

            function success(response) {
                var result = response ? response.data : {};
                return result;
            }

            function error(error) {
                workOutHelper.writeErrorMessageToConsole(error);
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
                workOutHelper.writeErrorMessageToConsole(error);
                return { Succeed: false };
            }
        }
    };
}());

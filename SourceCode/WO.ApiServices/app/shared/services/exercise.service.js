(function () {
    angular
        .module('woApp')
        .factory('exerciseService', exerciseService)

    exerciseService.$inject = [
        '$http',
        'workOutHelper'];

    var exerciseServiceUrl = '/api/Exercise/';

    function exerciseService(
        $http,
        workOutHelper) {

        var service = {
            getById: getById,
            getByName: getByName,
            getAll: getAll,
            create: create,
            update: update,
            remove: remove
        };

        return service;

        function getById(id) {
            return $http.get(exerciseServiceUrl + id)
                .then(success, error);

            function success(response) {
                var result = response ? response.data : {};
                return result;
            }

            function error(response) {
                workOutHelper.writeErrorMessageToConsole(response);
                return {};
            }
        }

        function getByName(name) {
            return $http.get(exerciseServiceUrl + name)
                .then(success, error);

            function success(response) {
                var result = response ? response.data : {};
                return result;
            }

            function error(response) {
                workOutHelper.writeErrorMessageToConsole(response);
                return {};
            }
        }

        function getAll() {
            return $http.get(exerciseServiceUrl)
                .then(success, error);

            function success(response) {
                var result = response ? response.data : {};
                return result;
            }

            function error(response) {
                workOutHelper.writeErrorMessageToConsole(response);
                return [];
            }
        }

        function create(exercise) {
            return $http.post(exerciseServiceUrl, exercise)
                .then(success, error);

            function success(response) {
                var result = response ? response.data : {};
                return result;
            }

            function error(response) {
                workOutHelper.writeErrorMessageToConsole(response);
                return { Succeed: false };
            }
        }

        function update(exercise) {
            return $http.put(exerciseServiceUrl, exercise)
                .then(success, error);

            function success(response) {
                var result = response ? response.data : {};
                return result;
            }

            function error(response) {
                workOutHelper.writeErrorMessageToConsole(response);
                return { Succeed: false };
            }
        }

        function remove(id) {
            return $http.delete(exerciseServiceUrl + id)
                .then(success, error);

            function success(response) {
                var result = response ? response.data : {};
                return result;
            }

            function error(response) {
                workOutHelper.writeErrorMessageToConsole(response);
                return { Succeed: false };
            }
        }
    }
}());
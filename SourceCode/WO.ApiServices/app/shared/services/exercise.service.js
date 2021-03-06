﻿(function () {
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
            save: save,
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

        function getByName(name) {
            return $http.get(exerciseServiceUrl + name)
                .then(success, error);

            function success(response) {
                var result = response ? response.data : {};
                return result;
            }

            function error(error) {
                workOutHelper.writeErrorMessageToConsole(error);
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

            function error(error) {
                workOutHelper.writeErrorMessageToConsole(error);
                return [];
            }
        }

        function save(exercise) {
            return $http.put(exerciseServiceUrl, exercise)
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
            return $http.delete(exerciseServiceUrl + id)
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
    }
}());
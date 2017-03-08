angular
    .module('woApp')
    .factory('approachService', approachService);

approachService.$inject = ['$http'];

var approachServiceUrl = "/api/Approach";

function approachService($http) {
    var service = {
        getById: getById,
        getAll: getAll,
        create: create,
        update: update,
        remove: remove
    };

    return service;

    function getAll() {
        return $http.get(approachServiceUrl)
        .then(success, error);

        function success(response) {
            var result = response ? response.data : {};
            return result;
        }

        function error(error) {
            console.log(error);
        }
    }

    function getById(id) {
        return $http.get(approachServiceUrl + "/" + id)
        .then(success, error)

        function success(response) {
            var result = response ? response.data : {};
            return result;
        }

        function error(error) {
            console.log(error);
        }
    }

    function create(approach) {
        return $http.post(approachServiceUrl, approach)
            .then(success, error);

        function success(response) {
            var result = response ? response.data : {};
            return result;
        }

        function error(error) {
            console.log(error);
        }
    }

    function update(approach) {
        return $http.put(approachServiceUrl, approach)
            .then(success, error);

        function success(response) {
            var result = response ? response.data : {};
            return result;
        }

        function error(error) {
            console.log(error);
        }
    }

    function remove(id) {
        return $http.delete(approachServiceUrl + "/" + id)
            .then(success, error);

        function success(response) {
            var result = response ? response.data : {};
            return result;
        }

        function error(error) {
            console.log(error);
        }
    }
}

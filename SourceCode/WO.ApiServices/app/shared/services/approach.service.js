angular
    .module('woApp')
    .factory('approachService', approachService);

approachService.$inject = ['$http'];

var approachServiceUrl = "/api/Approach";

function approachService($http) {
    var service = {
        create: create,
        getById: getById
    };

    return service;

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
}

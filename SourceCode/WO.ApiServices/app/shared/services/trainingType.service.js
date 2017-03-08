angular
    .module('woApp')
    .factory('trainingTypeService', trainingTypeService);

trainingTypeService.$inject = ['$http'];

var trainingTypeServiceUrl = "/api/TrainingType";

function trainingTypeService($http) {
    var service = {
        getAll: getAll,
        getById: getById,
        create: create,
        update: update,
        remove: remove
    };

    return service;

    function getAll() {
        return $http.get(trainingTypeServiceUrl).then(function (response) {
            var data = response ? response.data : {};
            return data;
        }, function errorCallback(response) {
            alert('Error');
        });
    }

    function getById(id) {
        return $http.get(trainingTypeServiceUrl + "/" + id).then(function (response) {
            var data = response ? response.data : {};
            return data;
        }, function errorCallback(response) {
            //response = Object {data: "", status: 404, config: Object, statusText: "Not Found"}
            alert('Error');
        });
    }

    function create(trainingType) {
        return $http.post(trainingTypeServiceUrl, trainingType).then(function (response) {
            var data = response ? response.data : {};
            return data;
        }, function errorCallback(response) {
            alert('Error');
        });
    }

    function update(trainingType) {
        return $http.put(trainingTypeServiceUrl, trainingType).then(function (response) {
            var data = response ? response.data : {};
            return data;
        }, function errorCallBack(response) {
            alert('Error');
        });
    }

    function remove(id) {
        return $http.delete(trainingTypeServiceUrl + "/" + id).then(function (response) {
            var data = response ? response.data : {};
            return data;
        }, function errorCallBack(response) {
            alert('Error');
        });
    }
};
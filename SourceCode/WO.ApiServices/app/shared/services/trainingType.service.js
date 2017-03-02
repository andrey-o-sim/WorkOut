angular
    .module('woApp')
    .factory('trainingTypeService', trainingTypeService);

trainingTypeService.$inject = ['$http'];

var serviceUrl = "/api/TrainingType";

function trainingTypeService($http) {
    var service = {
        getById: getById,
        create: create,
        update: update
    };

    return service;

    function getById(id) {
        return $http.get(serviceUrl + "/" + id).then(function (response) {
            var data = response ? response.data : {};
            return data;
        }, function errorCallback(response) {
            alert('Error');
        });
    }

    function create(trainingType) {
        return $http.post(serviceUrl, trainingType).then(function (response) {
            var data = response ? response.data : {};
            return data;
        }, function errorCallback(response) {
            alert('Error');
        });
    }

    function update(trainingType) {
        return $http.put(serviceUrl + "/" + trainingType.Id, trainingType).then(function (response) {
            var data = response ? response.data : {};
            return data;
        }, function errorCallBack(response) {
            alert('Error');
        });
    }
};
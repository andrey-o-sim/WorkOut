angular
    .module('woApp')
    .factory('trainingTypeService', trainingTypeService);

trainingTypeService.$inject = ['$http'];

var serviceUrl = "api/TrainingType";

function trainingTypeService($http) {
    var service = {
        getData: getData,
        save: save
    };

    return service;

    function getData() { }

    function save(trainingType) {
        return $http.post(serviceUrl, trainingType).then(function (response) {
            var data = response ? response.data : {};
            return data;
        }, function errorCallback(response) {
            alert('Error');
        });
    }
};
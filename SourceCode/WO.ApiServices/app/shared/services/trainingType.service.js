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
            getAll: getAll,
            getById: getById,
            create: create,
            update: update,
            remove: remove
        };

        return service;

        function getAll() {
            return $http.get(serviceUrl).then(function (response) {
                var data = response ? response.data : {};
                return data;
            }, function errorCallback(response) {
                workOutHelper.writeErrorMessageToConsole(response);
            });
        }

        function getById(id) {
            return $http.get(serviceUrl + id).then(function (response) {
                var data = response ? response.data : {};
                return data;
            }, function errorCallback(response) {
                workOutHelper.writeErrorMessageToConsole(response);
            });
        }

        function create(trainingType) {
            return $http.post(serviceUrl, trainingType).then(function (response) {
                var data = response ? response.data : {};
                return data;
            }, function errorCallback(response) {
                workOutHelper.writeErrorMessageToConsole(response);
            });
        }

        function update(trainingType) {
            return $http.put(serviceUrl, trainingType).then(function (response) {
                var data = response ? response.data : {};
                return data;
            }, function errorCallBack(response) {
                workOutHelper.writeErrorMessageToConsole(response);
            });
        }

        function remove(id) {
            return $http.delete(serviceUrl + id).then(function (response) {
                var data = response ? response.data : {};
                return data;
            }, function errorCallBack(response) {
                workOutHelper.writeErrorMessageToConsole(response);
            });
        }
    };
}());

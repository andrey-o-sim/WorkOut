(function () {
    angular
        .module('woApp')
        .factory('trainingService', trainingService);

    trainingService.$inject = [
        '$http',
        'workOutHelper'];

    var serviceUrl = "/api/Training/";

    function trainingService(
        $http,
        workOutHelper) {

        var service = {
            getById, getById,
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

                result.StartDateTime = workOutHelper.normalTimeToWoTime(result.StartDateTime);
                result.EndDateTime = workOutHelper.normalTimeToWoTime(result.EndDateTime);

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

        function create(training) {

            if (training.StartDateTime) {
                training.StartDateTime = workOutHelper.woTimeToNormalTime(training.StartDateTime);
            }

            if (training.EndDateTime) {
                training.EndDateTime = workOutHelper.woTimeToNormalTime(training.EndDateTime);
            }

            return $http.post(serviceUrl, training)
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

        function update(training) {

            if (training.StartDateTime) {
                training.StartDateTime = workOutHelper.woTimeToNormalTime(training.StartDateTime);
            }

            if (training.EndDateTime) {
                training.EndDateTime = workOutHelper.woTimeToNormalTime(training.EndDateTime);
            }

            return $http.put(serviceUrl, training)
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
    }
})();
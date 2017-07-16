(function () {
    angular
        .module('woApp')
        .factory('workOutHelper', workOutHelper);

    workOutHelper.$inject = [
        '$log'];

    function workOutHelper(
        $log) {

        var service = {
            removeElementFromArray: removeElementFromArray,
            writeErrorMessageToConsole: writeErrorMessageToConsole
        };

        return service;

        function removeElementFromArray(array, itemId) {
            var removeItem = array.find(function (element) {
                return element.Id == itemId;
            });

            var index = array.indexOf(removeItem);
            if (index != -1) {
                array.splice(index, 1);
            }

            return array;
        }

        function writeErrorMessageToConsole(error) {
            if (error.status != "404") {
                $log.error(error.status + " " + error.statusText);

                var errorMessages = JSON.parse(error.data.Message);
                errorMessages.forEach(function (message) {
                    $log.error("Message: " + message.ErrorMessage);
                });
            }
        }
    }
}());
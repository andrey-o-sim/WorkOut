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

        function writeErrorMessageToConsole(response) {
            $log.debug(response.status + " " + response.statusText);
        }
    }
}());
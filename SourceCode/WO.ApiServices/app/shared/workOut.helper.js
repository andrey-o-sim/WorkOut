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
            writeErrorMessageToConsole: writeErrorMessageToConsole,
            normalTimeToWoTime: normalTimeToWoTime,
            woTimeToNormalTime: woTimeToNormalTime,
            getCurrentDateWithoutTimeZone: getCurrentDateWithoutTimeZone
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

        function normalTimeToWoTime(time) {
            var currentDateTime = !time ? moment() : moment(time);
            var result = {
                Hours: currentDateTime.get('hours'),
                Minutes: currentDateTime.get('minutes'),
                Seconds: currentDateTime.get('seconds')
            }

            return result;
        }

        function woTimeToNormalTime(woTime) {
            var currentDate = moment();

            return currentDate.set({
                'hour': woTime.Hours,
                'minute': woTime.Minutes,
                'second': woTime.Seconds
            }).format();
        }

        function getCurrentDateWithoutTimeZone() {
            var timeZoneLength = 6;
            var currentDateTime = moment();
            return currentDateTime.format().substring(0, currentDateTime.format().length - timeZoneLength);
        }
    }
}());
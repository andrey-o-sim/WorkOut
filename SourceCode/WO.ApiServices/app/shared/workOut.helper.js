﻿angular
    .module('woApp')
    .factory('workOutHelper', workOutHelper);

function workOutHelper() {
    var service = {
        removeElementFromArray: removeElementFromArray
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
}
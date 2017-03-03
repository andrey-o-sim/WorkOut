﻿angular
    .module('woApp')
    .controller('trainingTypeViewController', trainingTypeViewController)

function trainingTypeViewController(
    $scope,
    $stateParams,
    trainingTypeService) {

    var vm = this;

    init();

    function init() {
        trainingTypeService.getById($stateParams.id).then(function (result) {
            vm.trainingType = result;
        });
    }
}
angular
    .module('woApp')
    .controller('trainingTypeEditController', trainingTypeEditController)

function trainingTypeEditController($scope) {
    $scope.trainingTypes = [{
        Id: 1,
        TrainingType: "Elements",

    },
    {
        Id: 2,
        TrainingType: "Base"
    }];
}
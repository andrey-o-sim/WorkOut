angular
    .module('woApp')
    .controller('trainingTypeViewController', trainingTypeViewController)

function trainingTypeViewController($scope) {
    $scope.trainingTypes = [{
        Id: 1,
        TrainingType: "Elements",

    },
    {
        Id: 2,
        TrainingType: "Base"
    }];
}
(function () {
    angular.module('woApp')
        .controller('SetNewController', SetNewController);

    SetNewController.$inject = [
        '$state',
        '$stateParams',
        '$uibModal',
        'exerciseService',
        'setService',];

    function SetNewController(
        $state,
        $stateParams,
        $uibModal,
        exerciseService,
        setService) {

        var vm = this;
        vm.save = save;
        vm.addEditExercise = addEditExercise;

        init();

        function init() {
            vm.set = {
                PlannedTime: {
                    Hours: 0,
                    Minutes: 0,
                    Seconds: 0
                },
                TimeForRest: {
                    Hours: 0,
                    Minutes: 0,
                    Seconds: 0
                },
                CountApproaches: 0,
                TrainingId: $stateParams.trainingId
            };

            exerciseService.getAll().then(function (result) {
                if (result) {
                    vm.Exercises = result;
                }
            });
        }

        function save(set) {
            vm.validateForm = true;
            if (isValidForm(set)) {
                vm.disableSaveButton = true;

                setService.create(set).then(function (result) {
                    if (result.Succeed) {
                        if ($stateParams.trainingId && $stateParams.trainingId > 0) {
                            $state.go('trainingEdit', { 'id': set.TrainingId });
                        }
                        else {
                            $state.go('setHome');
                        }
                    }
                    else {
                        vm.disableSaveButton = false;
                    }
                });
            }
        }

        function isValidForm(set) {
            vm.validator = {};
            var isValid = true;

            if (!set.TimeForRest
                || (set.TimeForRest.Hours === 0 && set.TimeForRest.Minutes === 0 && set.TimeForRest.Seconds === 0)) {
                vm.validator.ValidTimeForRest = false;
                isValid = false;
            }

            if (!set.Exercises || set.Exercises.length === 0) {
                vm.validator.ValidExercises = false;
                isValid = false;
            }

            if (!set.CountApproaches || set.CountApproaches < 1) {
                vm.validator.ValidCountApproaches = false;
                isValid = false;
            }

            return isValid;
        }

        function addEditExercise(exerciseId, setId) {
            var ariaLabel = exerciseId > 0 ? 'Exercise Edit' : 'Exercise New';

            var modalProperties = {
                ariaLabelledBy: ariaLabel,
                templateUrl: '/app/components/Exercise/forms/exercise.add.edit.html',
                controller: 'ExerciseAddEditController',
                itemId: exerciseId,
                setId: setId
            };

            var modalInstance = openModal(modalProperties);

            modalInstance.result.then(
                function (resultExercise) {
                    var indexForUpdate = -1;
                    vm.Exercises.forEach(function (item, index) {
                        if (item.Id === resultExercise.Id) {
                            indexForUpdate = index;
                            return true;
                        }
                    });

                    if (indexForUpdate > -1) {
                        vm.Exercises[indexForUpdate].Name = resultExercise.Name;

                        indexForUpdate = -1;
                        vm.set.Exercises.forEach(function (item, index) {
                            if (item.Id === resultExercise.Id) {
                                indexForUpdate = index;
                                return true;
                            }
                        });

                        if (indexForUpdate > -1) {
                            vm.set.Exercises[indexForUpdate].Name = resultExercise.Name;
                        }
                    }
                    else {
                        vm.Exercises.push(resultExercise);
                    }
                },
                function () {
                });
        }

        function openModal(modalProperties) {
            var modalInstance = $uibModal.open({
                animation: true,
                backdrop: 'static',
                ariaLabelledBy: modalProperties.ariaLabell,
                templateUrl: modalProperties.templateUrl,
                controller: modalProperties.controller,
                controllerAs: 'vm',
                resolve: {
                    id: function () {
                        return modalProperties.itemId;
                    },
                    setId: function () {
                        return modalProperties.setId;
                    }
                }
            });

            return modalInstance;
        }
    }
}());
(function () {
    angular.module('woApp')
        .controller('SetEditController', SetEditController)

    SetEditController.$inject = [
        '$state',
        '$stateParams',
        '$uibModal',
        'setService',
        'exerciseService',
        'approachService',
        'workOutHelper'];

    function SetEditController(
        $state,
        $stateParams,
        $uibModal,
        setService,
        exerciseService,
        approachService,
        workOutHelper) {

        var vm = this;
        vm.formIsReady = false;

        vm.save = save;
        vm.removeApproach = removeApproach;
        vm.addEditApproach = addEditApproach;
        vm.addEditExercise = addEditExercise;

        init();

        function init() {
            vm.set = {};

            setService.getById($stateParams.id).then(function (result) {
                if (result) {
                    vm.set = result;

                    vm.set.Exercises = getShotExercises(vm.set.Exercises);
                }

                vm.formIsReady = true;
            });

            exerciseService.getAll().then(function (result) {
                if (result) {
                    vm.Exercises = getShotExercises(result);
                }
            });
        }

        function getShotExercises(fulExercises) {
            return fulExercises.map(function (item) {
                var resultItem = {
                    Id: item.Id,
                    Name: item.Name
                };

                return resultItem;
            });
        }

        function removeApproach(id) {
            approachService.remove(id).then(function (result) {
                if (result.Succeed) {
                    vm.set.Approaches = workOutHelper.removeElementFromArray(vm.set.Approaches, id);
                }
            });
        }

        function save(set) {
            vm.validateForm = true;
            if (isValidForm(set)) {
                vm.disableSaveButton = true;

                setService.update(set).then(function (result) {
                    if (result.Succeed) {
                        $state.go('setHome');
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

            if (vm.set.Approaches.length === 0) {
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

        function addEditApproach(approachId, setId) {
            var ariaLabel = approachId > 0 ? 'Approach Edit' : 'Approach New';

            var modalProperties = {
                ariaLabelledBy: ariaLabel,
                templateUrl: '/app/components/Approach/forms/approach.add.edit.html',
                controller: 'ApproachAddEditController',
                itemId: approachId,
                setId: setId
            };

            var modalInstance = openModal(modalProperties);

            modalInstance.result.then(
                function (resultApproach) {
                    var indexForUpdate = -1;
                    vm.set.Approaches.forEach(function (setApproach, index) {
                        if (setApproach.Id === resultApproach.Id) {
                            indexForUpdate = index;
                            return true;
                        }
                    });

                    if (indexForUpdate > -1) {
                        vm.set.Approaches[indexForUpdate].PlannedTimeForRest = resultApproach.PlannedTimeForRest;
                        vm.set.Approaches[indexForUpdate].SpentTimeForRest = resultApproach.SpentTimeForRest;
                    }
                    else {
                        vm.set.Approaches.push(resultApproach);
                    }
                },
                function () { }
            );
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
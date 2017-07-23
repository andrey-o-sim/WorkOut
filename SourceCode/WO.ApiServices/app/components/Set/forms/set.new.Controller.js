(function () {
    angular.module('woApp')
        .controller('SetNewController', SetNewController);

    SetNewController.$inject = [
        '$state',
        '$stateParams',
        '$uibModal',
        'exerciseService',
        'setService',
        'approachService',
        'workOutHelper'];

    function SetNewController(
        $state,
        $stateParams,
        $uibModal,
        exerciseService,
        setService,
        approachService,
        workOutHelper) {

        var vm = this;
        vm.save = save;
        vm.addEditExercise = addEditExercise;
        vm.generateApproaches = generateApproaches;
        vm.removeApproach = removeApproach;
        vm.addEditApproach = addEditApproach;

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

            if (!set.Approaches || set.Approaches.length === 0) {
                vm.validator.ValidApproaches = false;
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

        function generateApproaches(set) {
            set.Id = 0;
            vm.generetingApproaches = true;
            approachService.generateApproachesForSet(set).then(function (result) {
                vm.set = result;
                vm.generetingApproaches = false;
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

        function removeApproach(id) {
            approachService.remove(id).then(function (result) {
                if (result.Succeed) {
                    vm.set.Approaches = workOutHelper.removeElementFromArray(vm.set.Approaches, id);
                }
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
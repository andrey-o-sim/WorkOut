﻿(function () {
    angular.module('woApp')
        .controller('SetFormController', SetFormController);

    SetFormController.$inject = [
        '$q',
        '$state',
        '$stateParams',
        '$uibModal',
        'exerciseService',
        'setService',
        'approachService',
        'workOutHelper',
        'toastr',
        'toastrConfig'
    ];

    function SetFormController(
        $q,
        $state,
        $stateParams,
        $uibModal,
        exerciseService,
        setService,
        approachService,
        workOutHelper,
        toastr,
        toastrConfig) {

        var vm = this;
        vm.formIsReady = false;
        vm.training = $stateParams.training;
        vm.save = save;
        vm.addEditExercise = addEditExercise;
        vm.generateApproaches = generateApproaches;
        vm.removeApproach = removeApproach;
        vm.editApproach = editApproach;

        vm.editForm = $stateParams.id && $stateParams.id > 0;

        init().then(function (set) {
            vm.set = set;
            vm.formIsReady = true;
        });

        function init() {

            exerciseService.getAll().then(function (result) {
                if (result) {
                    vm.Exercises = result;
                }
            });

            if (vm.editForm) {
                return setService.getById($stateParams.id).then(function (result) {
                    if (result) {
                        return result;
                    }
                    else {
                        toastrConfig.positionClass = 'toast-top-center';
                        toastrConfig.autoDismiss = false;
                        toastr.error("There is no Set with id = '" + $stateParams.id + "' in the system.");
                        return $q.when(null);
                    }

                });
            }
            else {
                var set = {
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
                    TrainingId: vm.training ? vm.training.Id : null
                };

                return $q.when(set);
            }
        }

        function save(set) {
            vm.validateForm = true;
            if (isValidForm(set)) {
                vm.disableSaveButton = true;

                setService.save(set).then(function (result) {
                    if (result.Succeed) {
                        if (vm.training) {
                            set.Id = result.ResultItemId;
                            vm.training.Sets.push(set)

                            var tainingRoute = vm.training.Id > 0 ? 'trainingEdit' : 'trainingNew';
                            $state.go(tainingRoute, { 'id': vm.training.Id, 'training': vm.training });
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
                templateUrl: '/app/components/Exercise/forms/exercise.form.html',
                controller: 'ExerciseFormController',
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
                    }

                }
            });

            return modalInstance;
        }

        function generateApproaches(set) {
            set.Id = set.Id ? set.Id : 0;
            vm.generetingApproaches = true;
            approachService.generateApproachesForSet(set).then(function (result) {
                vm.set = result;
                vm.generetingApproaches = false;
            });
        }

        function editApproach(approachId, itemIndex) {
            var ariaLabel = approachId > 0 ? 'Approach Edit' : 'Approach New';

            var modalProperties = {
                ariaLabelledBy: ariaLabel,
                templateUrl: '/app/components/Approach/forms/approach.form.html',
                controller: 'ApproachFormController',
                itemId: approachId
            };

            var modalInstance = openModal(modalProperties);

            modalInstance.result.then(
                function (resultApproach) {
                    vm.set.Approaches[itemIndex] = resultApproach;
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
    }
}());
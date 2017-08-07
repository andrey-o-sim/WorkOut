(function () {
    angular.module('woApp')
        .controller('SetFormController', SetFormController);

    SetFormController.$inject = [
        '$rootScope',
        '$q',
        '$state',
        '$stateParams',
        '$uibModal',
        'setService',
        'setTargetService',
        'approachService',
        'trainingService',
        'workOutHelper',
        'toastr',
        'toastrConfig'
    ];

    function SetFormController(
        $rootScope,
        $q,
        $state,
        $stateParams,
        $uibModal,
        setService,
        setTargetService,
        approachService,
        trainingService,
        workOutHelper,
        toastr,
        toastrConfig) {

        var vm = this;
        vm.formIsReady = false;
        vm.training = $stateParams.training;
        vm.save = save;
        vm.close = close;
        vm.generateApproaches = generateApproaches;
        vm.removeApproach = removeApproach;
        vm.editApproach = editApproach;

        vm.doneSetTarget = doneSetTarget;

        vm.isTrainingPresent = isTrainingPresent;

        vm.addEditSetTarget = addEditSetTarget;
        vm.removeSetTarget = removeSetTarget;

        vm.editForm = $stateParams.id && $stateParams.id > 0;

        vm.currentSetTargetIndex = 0;
        vm.currentApproachIndex = 0;

        $q.all({
            set: initSet()
        }).then(function (result) {
            vm.set = result.set;
            vm.countSetTargets = vm.set.SetTargets.length;
            vm.countApproaches = vm.set.Approaches.length;

            if (vm.editForm && vm.set.TrainingId) {
                trainingService.getById(vm.set.TrainingId).then(function (result) {
                    vm.training = result;
                });
            }

            vm.formIsReady = true;
        });

        function initSet() {
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
                    TrainingId: vm.training ? vm.training.Id : null,
                    SetTargets: []
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
                        if ($stateParams.training) {
                            if (vm.editForm) {
                                var indexForUpdate = vm.training.Sets.findIndex(function (set) {
                                    return set.Id === result.ResultItemId;
                                });
                                vm.training.Sets[indexForUpdate] = set;
                            }
                            else {
                                set.Id = result.ResultItemId;
                                vm.training.Sets.push(set)
                            }

                            var trainingRoute = $stateParams.training.Id > 0 ? 'trainingEdit' : 'trainingNew';
                            $state.go(trainingRoute, { 'id': vm.training.Id, 'training': vm.training });
                        }
                        else {
                            $rootScope.close();
                        }
                    }
                    else {
                        vm.disableSaveButton = false;
                    }
                });
            }
        }

        function close() {
            var trainingParam = $stateParams.training;
            if (trainingParam) {
                var trainingRoute = trainingParam.Id > 0 ? 'trainingEdit' : 'trainingNew';
                $state.go(trainingRoute, { 'id': trainingParam.Id, 'training': trainingParam });
            }
            else {
                $rootScope.close();
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

            if (!set.Approaches || set.Approaches.length === 0) {
                vm.validator.ValidApproaches = false;
                isValid = false;
            }

            return isValid;
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

        function removeApproach(id, itemIndex) {
            if (confirm("Do you realy want to remove the item?")) {
                approachService.remove(id).then(function (result) {
                    if (result.Succeed) {
                        vm.set.Approaches.splice(itemIndex, 1);
                        toastr.info("Approach with Id '" + result.ResultItemId + "' was successfully removed.");
                    }
                });
            }
        }

        function addEditSetTarget(setTargetId, itemIndex) {
            var ariaLabel = setTargetId > 0 ? 'Set Target Edit' : 'Set Target New';

            var modalProperties = {
                ariaLabelledBy: ariaLabel,
                templateUrl: '/app/components/SetTarget/forms/setTarget.form.html',
                controller: 'SetTargetFormController',
                itemId: setTargetId
            };

            var modalInstance = openModal(modalProperties);

            modalInstance.result.then(
                function (resultSetTarget) {
                    if (itemIndex || itemIndex >= 0) {
                        vm.set.SetTargets[itemIndex] = resultSetTarget;
                    }
                    else {
                        vm.set.SetTargets.push(resultSetTarget);
                    }
                },
                function () { }
            );
        }

        function removeSetTarget(id, itemIndex) {
            if (confirm("Do you realy want to remove the item?")) {
                setTargetService.remove(id).then(function (result) {
                    if (result.Succeed) {
                        vm.set.SetTargets.splice(itemIndex, 1);
                        toastr.info("Set Target with Id '" + result.ResultItemId + "' was successfully removed.");
                    }
                });
            }
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

        function isTrainingPresent() {
            return vm.set.Training || vm.training;
        }

        function doneSetTarget(setTargetId, itemIndex) {
            vm.currentSetTargetIndex = itemIndex + 1;
            if (vm.currentSetTargetIndex == vm.countSetTargets) {
                vm.set.Approaches[vm.currentApproachIndex].Finished = true;
                vm.currentApproachIndex++;

                if (vm.currentApproachIndex === vm.countApproaches) {
                    vm.set.Finished = true;
                }
                else {
                    vm.currentSetTargetIndex = 0;
                }
            }
        }
    }
}());
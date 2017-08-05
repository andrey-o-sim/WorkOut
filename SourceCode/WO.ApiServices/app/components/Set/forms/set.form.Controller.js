﻿(function () {
    angular.module('woApp')
        .controller('SetFormController', SetFormController);

    SetFormController.$inject = [
        '$rootScope',
        '$q',
        '$state',
        '$stateParams',
        '$uibModal',
        'setService',
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

        vm.editForm = $stateParams.id && $stateParams.id > 0;

        $q.all({
            set: initSet()
        }).then(function (result) {
            vm.set = result.set;

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

        function removeApproach(id) {
            approachService.remove(id).then(function (result) {
                if (result.Succeed) {
                    vm.set.Approaches = workOutHelper.removeElementFromArray(vm.set.Approaches, id);
                }
            });
        }
    }
}());
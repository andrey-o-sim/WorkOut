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
        vm.openModal = openModal;

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
                    vm.set.CountApproaches = vm.set.Approaches.length;
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

            if (vm.set.CountApproaches === 0) {
                vm.validator.ValidCountApproaches = false;
                isValid = false;
            }
            return isValid;
        }

        function openModal(id) {
            var ariaLabell = id > 0 ? 'Exercise Edit' : 'Exercise New';
            var modalInstance = $uibModal.open({
                animation: true,
                backdrop: 'static',
                ariaLabelledBy: ariaLabell,
                templateUrl: '/app/components/Exercise/forms/exercise.add.edit.html',
                controller: 'ExerciseAddEditController',
                controllerAs: 'vm',
                resolve: {
                    id: function () {
                        return id;
                    }
                }
            });

            modalInstance.result.then(function (exercise) {
                var indexForUpdate = -1;
                vm.Exercises.forEach(function (item, index) {
                    if (item.Id === exercise.Id) {
                        indexForUpdate = index;
                        return true;
                    }
                });

                if (indexForUpdate > -1) {
                    vm.Exercises[indexForUpdate].Name = exercise.Name;

                    indexForUpdate = -1;
                    vm.set.Exercises.forEach(function (item, index) {
                        if (item.Id === exercise.Id) {
                            indexForUpdate = index;
                            return true;
                        }
                    });

                    if (indexForUpdate > -1) {
                        vm.set.Exercises[indexForUpdate].Name = exercise.Name;
                    }
                }
                else {
                    vm.Exercises.push(exercise);
                }
            });
        }
    }
}());
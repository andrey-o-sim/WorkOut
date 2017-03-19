(function () {
    angular.module('woApp')
        .directive("woTimeSelector", woTimeSelectorDirective);

    function woTimeSelectorDirective() {

        return {
            restrict: "E",
            templateUrl: '/app/shared/directives/wo.timeSelector.html',
            scope: {
            },
            controllerAs: 'vm',
            bindToController: {
                showHours: '=?',
                showMinutes: '=?',
                showSeconds: '=?',
                time: '='
            },
            controller: woTimeSelectorController
        };

        function woTimeSelectorController() {
            var vm = this;

            vm.maxHours = 23;
            vm.maxMinutes = 59;
            vm.maxSeconds = 55;

            vm.increaseHours = increaseHours;
            vm.increaseMinutes = increaseMinutes;
            vm.increaseSeconds = increaseSeconds;

            vm.decreaseHours = decreaseHours;
            vm.decreaseMinutes = decreaseMinutes;
            vm.decreaseSeconds = decreaseSeconds;

            var emptyTime = {
                Hours: 0,
                Minutes: 0,
                Seconds: 0
            }

            function increaseHours() {
                if (vm.time.Hours !== vm.maxHours) {
                    vm.time = vm.time ? vm.time : emptyTime
                    vm.time.Hours++;
                }
            }

            function increaseMinutes() {
                vm.time = vm.time ? vm.time : emptyTime

                if (vm.showHours && vm.time.Hours !== vm.maxHours && vm.time.Minutes === vm.maxMinutes) {
                    increaseHours();
                    vm.time.Minutes = 0;
                }
                else {
                    if (vm.time.Minutes !== vm.maxMinutes) {
                        vm.time.Minutes++;
                    }
                }
            }

            function increaseSeconds() {
                vm.time = vm.time ? vm.time : emptyTime
                if (vm.time.Seconds + 5 === 60 && vm.time.Hours !== vm.maxHours && vm.time.Minutes !== vm.maxMinutes) {
                    increaseMinutes();
                    vm.time.Seconds = 0;
                }
                else {
                    if (vm.time.Seconds !== vm.maxSeconds) {
                        vm.time.Seconds = vm.time.Seconds + 5;
                    }
                }
            }

            function decreaseHours() {
                if (vm.time.Hours !== 0) {
                    vm.time.Hours--;
                }
            }

            function decreaseMinutes() {
                if (vm.showHours && vm.time.Hours >= 1 && vm.time.Minutes === 0) {
                    decreaseHours();
                    vm.time.Minutes = vm.maxMinutes;
                }
                else {
                    if (vm.time.Minutes !== 0) {
                        vm.time.Minutes--;
                    }
                }
            }

            function decreaseSeconds() {
                if (vm.time.Seconds === 0 && vm.time.Minutes !== 0) {
                    decreaseMinutes();
                    vm.time.Seconds = vm.maxSeconds;
                }
                else {
                    if (vm.time.Seconds !== 0) {
                        vm.time.Seconds = vm.time.Seconds - 5;
                    }
                }
            }
        }
    }
}());
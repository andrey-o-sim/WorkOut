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

            vm.increaseHours = increaseHours;
            vm.increaseMinutes = increaseMinutes;
            vm.increaseSeconds = increaseSeconds;

            vm.decreaseHours = decreaseHours;
            vm.decreaseMinutes = decreaseMinutes;
            vm.decreaseSeconds = decreaseSeconds;

            //vm.onlyNumbersPattern = /^\d+$/;

            var emptyTime = {
                Hours: 0,
                Minutes: 0,
                Seconds: 0
            }

            function increaseHours() {
                vm.time = vm.time ? vm.time : emptyTime
                vm.time.Hours++;
            }

            function increaseMinutes() {
                vm.time = vm.time ? vm.time : emptyTime
                vm.time.Minutes++;
            }

            function increaseSeconds() {
                vm.time = vm.time ? vm.time : emptyTime
                vm.time.Seconds = vm.time.Seconds + 5;
            }

            function decreaseHours() {
                vm.time.Hours--;
            }

            function decreaseMinutes() {
                vm.time.Minutes--;
            }

            function decreaseSeconds() {
                vm.time.Seconds = vm.time.Seconds - 5;
            }
        }
    }
}());
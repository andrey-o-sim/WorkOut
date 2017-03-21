(function () {

    angular
        .module('woApp')
        .controller('TrainingEditController', TrainingEditController);

    TrainingEditController.$inject = ['trainingService'];

    function TrainingEditController($location) {
        var vm = this;

        init();

        function init() { }
    }
})();

(function () {

    angular
        .module('woApp')
        .controller('TrainingHomeController', TrainingHomeController);

    TrainingHomeController.$inject = ['trainingService'];

    function TrainingHomeController(trainingService) {
        var vm = this;

        init();

        function init() { }
    }
})();

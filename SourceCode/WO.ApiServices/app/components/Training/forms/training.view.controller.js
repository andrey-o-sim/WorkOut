(function () {

    angular
        .module('woApp')
        .controller('TrainingViewController', TrainingViewController);

    TrainingViewController.$inject = ['trainingService'];

    function TrainingViewController(trainingService) {
        var vm = this;

        init();

        function init() { }
    }
})();

(function () {

    angular
        .module('woApp')
        .controller('TrainingNewController', TrainingNewController);

    TrainingNewController.$inject = ['trainingService'];

    function TrainingNewController(trainingService) {
        var vm = this;

        init();

        function init() { }
    }
})();

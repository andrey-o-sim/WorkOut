(function () {
    angular
        .module('woApp')
        .controller('TrainingNewController', TrainingNewController);

    TrainingNewController.$inject = [
        'trainingService',
        'trainingTypeService'];

    function TrainingNewController(trainingService) {
        var vm = this;

        init();

        function init() { }
    }
})();

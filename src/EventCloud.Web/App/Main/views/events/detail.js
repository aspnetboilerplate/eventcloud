(function () {
    var controllerId = 'app.views.events.detail';
    angular.module('app').controller(controllerId, [
        '$scope','$stateParams', 'abp.services.app.event',
        function ($scope, $stateParams, eventService) {
            var vm = this;

            eventService.getDetail({
                id: $stateParams.id
            }).success(function(result) {
                vm.event = result;
            });
        }
    ]);
})();
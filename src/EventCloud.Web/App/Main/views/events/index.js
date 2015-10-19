(function() {
    var controllerId = 'app.views.events.index';
    angular.module('app').controller(controllerId, [
        '$scope', 'abp.services.app.event',
        function ($scope, eventService) {
            var vm = this;

            vm.events = [];

            eventService.getList({}).success(function(result) {
                vm.events = result.items;
            });
        }
    ]);
})();
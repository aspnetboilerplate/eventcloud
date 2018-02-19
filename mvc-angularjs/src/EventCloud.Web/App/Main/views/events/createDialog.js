(function () {
    angular.module('app').controller('app.views.events.createDialog', [
        'abp.services.app.event', '$modalInstance',
        function (eventService, $modalInstance) {
            var vm = this;

            vm.event = {
                title: '',
                description: '',
                date: moment().add('day', 1).format('YYYY-MM-DD') + ' 09:00',
                maxRegistrationCount: 0
            };

            vm.save = function() {
                eventService
                    .create(vm.event)
                    .success(function () {
                        abp.notify.success("Successfully saved.");
                        $modalInstance.close();
                    });
            };

            vm.cancel = function () {
                $modalInstance.dismiss('cancel');
            };
        }
    ]);
})();
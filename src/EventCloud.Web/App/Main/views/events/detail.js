(function () {
    var controllerId = 'app.views.events.detail';
    angular.module('app').controller(controllerId, [
        '$scope', '$state','$stateParams', 'abp.services.app.event',
        function ($scope, $state, $stateParams, eventService) {
            var vm = this;

            function loadEvent() {
                eventService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.event = result;
                });
            }

            vm.isRegistered = function () {
                if (!vm.event) {
                    return false;
                }

                return _.find(vm.event.registrations, function(registration) {
                    return registration.userId == abp.session.userId;
                });
            };

            vm.isEventCreator = function() {
                return vm.event && vm.event.creatorUserId == abp.session.userId;
            };

            vm.getUserThumbnail = function(registration) {
                return registration.userName.substr(0, 1).toLocaleUpperCase();
            };

            vm.register = function() {
                eventService.register({
                    id: vm.event.id
                }).success(function (result) {
                    abp.notify.success('Successfully registered to event. Your registration id: ' + result.registrationId + ".");
                    loadEvent();
                });
            };

            vm.cancelRegistertration = function() {
                eventService.cancelRegistration({
                    id: vm.event.id
                }).success(function () {
                    abp.notify.info('Canceled your registration.');
                    loadEvent();
                });
            };

            vm.cancelEvent = function() {
                eventService.cancel({
                    id: vm.event.id
                }).success(function () {
                    abp.notify.info('Canceled the event.');
                    vm.backToEventsPage();
                });
            };

            vm.backToEventsPage = function() {
                $state.go('events');
            };

            loadEvent();
        }
    ]);
})();
(function () {
    'use strict';

    var app = angular.module('app', [
        'ngAnimate',
        'ngSanitize',

        'ui.router',
        'ui.bootstrap',
        'ui.jq',

        'abp'
    ]);

    //Configuration for Angular UI routing.
    app.config([
        '$stateProvider', '$urlRouterProvider',
        function($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise('/events');
            $stateProvider
                .state('events', {
                    url: '/events',
                    templateUrl: '/App/Main/views/events/index.cshtml',
                    menu: 'Events' //Matches to name of 'Events' menu in EventCloudNavigationProvider
                })
                .state('eventDetail', {
                    url: '/events/:id',
                    templateUrl: '/App/Main/views/events/detail.cshtml',
                    menu: 'Events' //Matches to name of 'Events' menu in EventCloudNavigationProvider
                })
                .state('about', {
                    url: '/about',
                    templateUrl: '/App/Main/views/about/about.cshtml',
                    menu: 'About' //Matches to name of 'About' menu in EventCloudNavigationProvider
                });
        }
    ]);
})();
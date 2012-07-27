'use strict';


// Declare app level module which depends on filters, and services
angular.module('BinahApp', ['ngResource', 'ngSanitize', 'BinahApp.filters', 'BinahApp.services', 'BinahApp.directives'])
    .config(['$routeProvider', '$locationProvider', function($routeProvider, $locationProvider) {
        $routeProvider.when('/siddur/paragraphs', { templateUrl: '/partials/siddurParagraphs.html', controller: SiddurParagraphsCtrl });
        $routeProvider.when('/siddur', { templateUrl: '/partials/siddur.html', controller: SiddurCtrl });
        $routeProvider.otherwise({ redirectTo: '/' });

        $locationProvider.html5Mode(true);
    }])
   // .controller('AppCtrl', AppCtrl)
    .provider({
        // log.error service instead
        $exceptionHandler: function() {
            var handler = function(exception, cause) {
                // document.write(exception);
                alert(exception);
            };

            this.$get = function() {
                return handler;
            };
        }
    });


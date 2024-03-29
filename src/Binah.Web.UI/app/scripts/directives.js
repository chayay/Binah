'use strict';

/* Directives */


angular.module('BinahApp.directives', [])
    .directive('contenteditable', ['$sanitize', function($sanitize) {
        return {
            restrict: 'A',
            require: 'ngModel',
            link: function(scope, element, attrs, ngModel) {
                // Specify how UI should be updated
                ngModel.$render = function() {
                    element.html(ngModel.$viewValue || '');
                };

                // Listen for change events to enable binding
                element.bind('blur keyup change', function() {
                    scope.$apply(function() {
                        // Write data to the model
                        scope.$apply(ngModel.$setViewValue($sanitize(element.html())));
                    });
                });
            }
        };
    }])
    .directive('whenScrolled', function() {
        return function (scope, elm, attr) {
            var raw = elm[0];
            // TODO: Make sure to clean up the event when unloading the element.
            angular.element(window).bind('scroll', function () {
                var buffer = 100;
                if ($(document).height() < buffer + $(window).height() + $(window).scrollTop()) {
                    scope.$apply(attr.whenScrolled);
                }
            });
        };
    });
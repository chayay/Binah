'use strict';

/* Directives */


angular.module('BinahApp.directives', []).
    directive('contenteditable', ['$sanitize', function($sanitize) {
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
    }]);

/*

 directive('contenteditable', ['$sanitize', function($sanitize) {
        return function(scope, elm, attrs) {
            elm.text(version);
        };
    }]);

    */
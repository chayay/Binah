﻿'use strict';

angular.module('BinahApp', ['ngResource', 'ngSanitize']).controller('AppCtrl', function AppCtrl($scope, $route, $routeParams, $location) {
    $scope.$route = $route;
    $scope.$location = $location;
    $scope.$routeParams = $routeParams;
}).directive('contenteditable', ['$sanitize', function ($sanitize) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function (scope, element, attrs, ngModel) {
            // Specify how UI should be updated
            ngModel.$render = function () {
                element.html(ngModel.$viewValue || '');
            };
            
            // Listen for change events to enable binding
            element.bind('blur keyup change', function () {
                scope.$apply(function () {
                    // Write data to the model
                    scope.$apply(ngModel.$setViewValue($sanitize(element.html())));
                });
            });
        }
    };
}]).config(function ($routeProvider, $locationProvider) {
    $routeProvider.when('/siddur/paragraphs', {
        templateUrl: '/templates/siddurParagraphs.html',
        controller: SiddurParagraphsCtrl
    }).when('/siddur', {
        templateUrl: '/templates/newItems.html',
        controller: NewItemsCtrl
    }).otherwise({

    });

    $locationProvider.html5Mode(true);
}).provider({
    // log.error service instead
    $exceptionHandler: function () {
        var handler = function (exception, cause) {
            document.write(exception);
            alert(exception);
        };

        this.$get = function () {
            return handler;
        };
    }
});

function SiddurParagraphsCtrl($scope, $routeParams, $resource) {
    $scope.name = "SiddurCtrl";
    $scope.params = $routeParams;
    
    var newItems = $resource('newItems');
}
SiddurParagraphsCtrl.$inject = ['$scope', '$routeParams', '$resource'];


function NewItemsCtrl($scope, $routeParams, $resource, $http) {
    $scope.name = "SiddurCtrl";
    $scope.params = $routeParams;
    $scope.skip = 0;
    $scope.items = [];
    
    $scope.load = function () {
        var newItems = $resource('/api/siddur', { size: $scope.size }, {
            approve: { method: 'POST' }
        });
        newItems.query({ skip: $scope.skip }, function() {
            alert("d");
        });
        $scope.skip += 24;
    };
    $scope.load();
    
    $scope.save = function (item) {
        $scope.doingWork = true;
        item.$save({}, function (parameters, aa, ff) {
            $scope.doingWork = false;
            debugger;
        }, function(parameters, aa,ff) {
            $scope.doingWork = false;
            debugger;
        });
    };
}
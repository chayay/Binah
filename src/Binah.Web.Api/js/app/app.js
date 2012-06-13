'use strict';

angular.module('BinahApp', ['ngResource', 'ngSanitize']).config(function ($routeProvider, $locationProvider) {
    $routeProvider.when('/siddur/paragraphs', {
        templateUrl: '/templates/siddurParagraphs.html',
        controller: SiddurParagraphsCtrl
    }).when('/new/items', {
        templateUrl: '/templates/newItems.html',
        controller: NewItemsCtrl
    }).otherwise({
        
    });
    
    $locationProvider.html5Mode(true);
}).controller('AppCtrl', function AppCtrl($scope, $route, $routeParams, $location) {
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
}]);

function SiddurParagraphsCtrl($scope, $routeParams, $resource) {
    $scope.name = "SiddurCtrl";
    $scope.params = $routeParams;
    
    var newItems = $resource('newItems');
}
SiddurParagraphsCtrl.$inject = ['$scope', '$routeParams', '$resource'];


function NewItemsCtrl($scope, $routeParams, $resource) {
    $scope.name = "SiddurCtrl";
    $scope.params = $routeParams;

    var newItems = $resource('/api/new/items', {}, {
        approve: {method:'POST'}
    });
    $scope.items = newItems.query();
}
'use strict';

angular.module('BinahApp', ['ngResource'], function ($routeProvider, $locationProvider) {
    $routeProvider.when('/siddur/paragraphs', {
        template: '/templates/siddurParagraphs.html',
        controller: SiddurParagraphsCtrl
    }).when('/new/items', {
        template: '/templates/newItems.html',
        controller: NewItemsCtrl
    }).otherwise({
        
    });
    
    $locationProvider.html5Mode(true);
});

function AppCtrl($scope, $route, $routeParams, $location) {
    $scope.$route = $route;
    $scope.$location = $location;
    $scope.$routeParams = $routeParams;
}

function SiddurParagraphsCtrl($scope, $routeParams, $resource) {
    $scope.name = "SiddurCtrl";
    $scope.params = $routeParams;
    
    var newItems = $resource('newItems');
}
SiddurParagraphsCtrl.$inject = ['$scope', '$routeParams', '$resource'];


function NewItemsCtrl($scope, $routeParams, $resource) {
    $scope.name = "SiddurCtrl";
    $scope.params = $routeParams;

    var newItems = $resource('/api/new/items');
    $scope.items = newItems.query();
}
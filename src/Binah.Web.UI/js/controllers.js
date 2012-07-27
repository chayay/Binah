'use strict';

/* Controllers */


function AppCtrl($scope, $route, $routeParams, $location) {
    $scope.$route = $route;
    $scope.$location = $location;
    $scope.$routeParams = $routeParams;
}
AppCtrl.$inject = ['$scope', '$route', '$routeParams', '$location'];

function SiddurParagraphsCtrl($scope, $routeParams, $resource, $http) {
    $scope.skip = 0;
    $scope.items = [];

    $http.get('http://localhost:30001/api/siddur').
        success(function(data, status, headers, config) {
            alert('success;');
        }).error(function(data, status, headers, config) {
            alert('error;');
        });
    
   /* $scope.load = function () {
        var snippets = $resource('http://localhost:port/api/siddur', { port: ':30001' });
        snippets.query({ skip: $scope.skip }, function () {
            alert("d");
        });
        $scope.skip += 24;
    };
    $scope.load();*/

    $scope.save = function (item) {
        $scope.doingWork = true;
        item.$save({}, function (parameters, aa, ff) {
            $scope.doingWork = false;
            debugger;
        }, function (parameters, aa, ff) {
            $scope.doingWork = false;
            debugger;
        });
    };
}
SiddurParagraphsCtrl.$inject = ['$scope', '$routeParams', '$resource', '$http'];

function SiddurCtrl($scope, $routeParams, $resource, $http) {
    $scope.name = "SiddurCtrl";
}
SiddurCtrl.$inject = ['$scope', '$routeParams', '$resource'];
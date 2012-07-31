'use strict';

/* Controllers */


function AppCtrl($scope, $route, $routeParams, $location) {
    $scope.$route = $route;
    $scope.$location = $location;
    $scope.$routeParams = $routeParams;
}
AppCtrl.$inject = ['$scope', '$route', '$routeParams', '$location'];

function SiddurParagraphsCtrl($scope, $routeParams, $resource, $http, strings) {
    $scope.skip = 0;
    $scope.items = [];
    $scope.load = function() {
        $http.get(strings.apiUrl + '/api/siddur?skip=' + $scope.skip).
            success(function(data, status, headers, config) {
                // TODO: should I optimize this with $scope.items.push()?
                $scope.items = $scope.items.concat(data);
                $scope.skip += 24;
            }).
            error(function(data, status, headers, config) {
                document.getElementById('debug').innerText = 'error';
            });
    };
    $scope.load();

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
SiddurParagraphsCtrl.$inject = ['$scope', '$routeParams', '$resource', '$http', 'strings'];

function SiddurCtrl($scope, $routeParams, $resource, $http) {
    $scope.name = "SiddurCtrl";
}
SiddurCtrl.$inject = ['$scope', '$routeParams', '$resource'];
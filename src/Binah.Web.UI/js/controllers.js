'use strict';

/* Controllers */


function AppCtrl($scope, $route, $routeParams, $location, $http, strings) {
    $scope.$route = $route;
    $scope.$location = $location;
    $scope.$routeParams = $routeParams;
    
    $http.get(strings.apiUrl + '/api/user').
        success(function (data, status, headers, config) {
            $scope.user = data;
        });
}
AppCtrl.$inject = ['$scope', '$route', '$routeParams', '$location', '$http', 'strings'];

function SiddurParagraphsCtrl($scope, $routeParams, $resource, $http, strings) {
    $scope.skip = 0;
    $scope.items = [];
    $scope.loadMore = function () {
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
    $scope.loadMore();

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

function SiddurPrayerCtrl($scope, $routeParams, $http, strings) {
    $http.get(strings.apiUrl + '/api/siddur/' + $routeParams.slug).
        success(function(data) {
            $scope.prayer = data;
        });
}
'use strict';

/* Controllers */


function AppController($scope, $route, $routeParams, $location, $http, strings) {
    $scope.$route = $route;
    $scope.$location = $location;
    $scope.$routeParams = $routeParams;
    
    $http.get(strings.apiUrl + '/api/user').
        success(function (data, status, headers, config) {
            $scope.user = data;
        });
}
AppController.$inject = ['$scope', '$route', '$routeParams', '$location', '$http', 'strings'];

function SiddurParagraphsController($scope, $routeParams, $resource, $http, strings) {
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
SiddurParagraphsController.$inject = ['$scope', '$routeParams', '$resource', '$http', 'strings'];

function SiddurController($scope, $routeParams, $resource, $http, strings) {
    $http.get(strings.apiUrl + '/api/siddur').
        success(function(data, status, headers, config) {
            $scope.prayers = data;
        });
}
SiddurController.$inject = ['$scope', '$routeParams', '$resource', '$http', 'strings'];

function SiddurPrayerController($scope, $routeParams, $http, strings) {
    $http.get(strings.apiUrl + '/api/siddur/' + $routeParams.slug).
        success(function(data) {
            $scope.prayer = data;
        });
}
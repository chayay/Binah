'use strict';

/* Filters */

angular.module('BinahApp.filters', []).
    filter('spanWords', function () {
        return function (text) {
            var result = text.split(' ')
                .map(function(value, index, array) {
                    return '<span index="' + index + '">' + value + '</span>';
                })
                .join(' ');
            return result;
        };
    });
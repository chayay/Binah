'use strict';

/* Services */


// Demonstrate how to register services
// In this case it is a simple value service.
angular.module('BinahApp.services', []).
    value('strings', {
        apiUrl: '//localhost:30001'
    });

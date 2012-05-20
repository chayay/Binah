define(function (require) {
    'use strict';
    
    var $ = require('jquery');
    var _ = require('use!underscore');
    var backbone = require('use!backbone');

    $(function () {
        require('./uiNetwork')();
        require('./uiAppCache')();
    });
});
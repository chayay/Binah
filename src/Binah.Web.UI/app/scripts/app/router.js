define(function(require) {
    'use strict';

    var $ = require('jquery');
    var backbone = require('use!backbone');

    return function() {
        var appRouter = backbone.Router.extend({
            routes: {
                '': 'index',
                'siddur': 'siddur',
                '*path': 'CatchAll',
            },

            index: function() {
                
            },
            siddur: function() {
                alert("siddur");
            },
            'CatchAll': function (path) {
                alert('CatchAll: ' + path);
            },
        });

        var app = new appRouter();
        $('a').click(function() {
            app.navigate($(this).attr('href'), { trigger: true });
            return false;
        });

        backbone.history.start({ pushState: true });
    };
});
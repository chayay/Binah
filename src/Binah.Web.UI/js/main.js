// Set the RequireJS configuration
require.config({
    
    // Require.js allows us to configure shortcut alias
    paths: {
        // Major libraries
        jquery: 'libs/jquery/jquery',
        underscore: 'libs/underscore/underscore',
        backbone: 'libs/backbone/backbone',
        dust: 'libs/dust/dust-core',

        // Require.js plugins
        text: 'libs/require/text',
        order: 'libs/require/order',
        use: 'libs/require/use',

        // Just a short cut so we can put our html outside the js dir
        // When you have HTML/CSS designers this aids in keeping them out of the js directory
        templates: '../templates'
    },
    
    use: {
        underscore: {
            attach: '_'
        },

        backbone: {
            deps: ['use!underscore', 'jquery'],
            attach: function (_, $) {
                return window.Backbone;
            }
        },
    },
    
    waitSeconds: 2,
    urlArgs: 'bust=' + (new Date()).getTime(),
    catchError: true
});

_.templateSettings = { interpolate: /\{\{(.+?)\}\}/g };

// Start loading the main app file.
require(['app/main']);
define(function (require) {
    'use strict';

    var $ = require('jquery');
    var backbone = require('use!backbone');

    return function () {
        backbone.View.extend({
            id: 'main-container',

            render: function () {
                this.$el.html(this.template(this.model.toJSON()));
                return this;
            }
        });
    };
});
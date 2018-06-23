(function (undefined) {
    'use strict';

    window.websocket = {
        'socket': null,
        'connect': function (url) {
            this.socket = new WebSocket(url);
        },
        'onMessage': function (callback) {
            this.socket.onmessage = callback;
        },
        'send': function (data) {
            this.socket.send(data);
        }
    }
}).call(this);

(function (undefined) {
    'use strict';

    var token = Cookies.get('auth.token');

    if (!token) {
        location.href = 'signin';
    }

    websocket.connect('ws://localhost:4545/chat');

    var $messages = new Vue({
        'el': '#messages',
        'data': {
            'messages': []
        },
        'methods': {
            'pullMessages': function () {
                this.$http.get('http://localhost:51397/api/v1/chats', { 'headers': { 'Authorization': token }}).then(function (response) {
                    response.json().then(function (data) {
                        this.messages = data;
                    }.bind(this));
                }, function (response) {
                    console.log(response);
                });
            },
            'onReceived': function (event) {
                this.pullMessages();
            }
        },
        'mounted': function () {
            this.pullMessages();
            websocket.onMessage(this.onReceived);
        }
    });

    var $inputForm = new Vue({
        'el': '#input_form',
        'data': {
            'message': '',
        },
        'methods': {
            'send': function (event) {
                if (!this.message) {
                    return;
                }

                this.$http.post('http://localhost:51397/api/v1/chats', { 'message': this.message }, { 'headers': { 'Authorization': token } }).then(function (response) {
                    websocket.send('registed');
                }, function (response) {
                    console.log(response);
                });
            }
        }
    });
}).call(this);
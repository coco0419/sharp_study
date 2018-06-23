(function (undefined, $http) {
    'use strict';

    new Vue({
        'el': '#signin',
        'data': {
            'identity': {
                'login_id': null,
                'password': null
            },
            'errors': [],
            'labels': {
                'login_id': 'ログインID',
                'password': 'パスワード',
                'sign_in': 'サインイン'
            },
            'messages': {
                'error.required': 'を入力してください',
                'error.invalidLoginIdOrPassword': 'ログインID、またはパスワードが不正です'
            }
        },
        'methods': {
            'send': function () {
                this.errors = [];

                this.$http.post('http://localhost:51397/api/v1/auth', this.identity).then(function (response) {
                    response.json().then(function (data) {
                        Cookies.set('auth.token', data.token.value);

                        location.href = '/';
                    });
                }, function (data) {
                    this.errors = data.body;
                });
            }
        }
    })
}).call(this);

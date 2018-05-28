angular.module('MyTestSafeweb')
    .service('UserService', ['$http', function ($http) {

        var urlBase = 'http://localhost:49854/api/Users';

        this.getUsers = function () {
            return $http.get(urlBase);
        };

        this.getUserById = function (id) {
            return $http.get(urlBase + '/' + id);
        };

        this.getUser = function (username, password) {
            return $http.get(urlBase + '/' + username + '/' + password);
        };

        this.insertUser = function (user) {
            return $http.post(urlBase + '/Post', user);
        };

        this.updateUser = function (user) {
            return $http.put(urlBase + '/Put', user);
        };

        this.deleteUser = function (id) {
            return $http.delete(urlBase + '/Delete/' + id);
        };
    }]);
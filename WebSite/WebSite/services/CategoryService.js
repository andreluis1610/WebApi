angular.module('MyTestSafeweb')
    .service('CategoryService', ['$http', function ($http) {

        var urlBase = 'http://localhost:49854/api/Categories';

        this.getCategories = function () {
            return $http.get(urlBase);
        };

        this.getCategory = function (id) {
            return $http.get(urlBase + '/' + id);
        };

        this.insertCategory = function (category) {
            return $http.post(urlBase + '/Post', category);
        };

        this.updateCategory = function (category) {
            return $http.put(urlBase + '/Put', category);
        };

        this.deleteCategory = function (id) {
            return $http.delete(urlBase + '/Delete/' + id);
        };
    }]);
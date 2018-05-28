angular.module('MyTestSafeweb')
    .service('SupplierService', ['$http', function ($http) {

        var urlBase = 'http://localhost:49854/api/Suppliers';

        this.getSuppliers = function () {
            return $http.get(urlBase);
        };

        this.getSupplier = function (id) {
            return $http.get(urlBase + '/' + id);
        };

        this.insertSupplier = function (supplier) {
            return $http.post(urlBase + '/Post', supplier);
        };

        this.updateSupplier = function (supplier) {
            return $http.put(urlBase + '/Put', supplier);
        };

        this.deleteSupplier = function (id) {
            return $http.delete(urlBase + '/Delete/' + id);
        };


    }]);
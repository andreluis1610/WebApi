angular.module('MyTestSafeweb')
    .service('ConfigurationService', ['$http', function ($http) {

        var urlBase = 'http://localhost:49854/api/Configurations';

        this.getConfiguration = function () {
            return $http.get(urlBase);
        };

        this.updateConfiguration = function (configuration) {
            return $http.put(urlBase + '/Put', configuration);
        };
    }]);
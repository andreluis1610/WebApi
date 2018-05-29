angular.module('MyTestSafeweb')
    .service('HistoricService', ['$http', function ($http) {

        var urlBase = 'http://localhost:49854/api/HistoryProposals';

        this.getHistoric = function (id) {
            return $http.get(urlBase + '/' + id);
        };
    }]);
﻿angular.module('MyTestSafeweb')
    .service('ProposalService', ['$http', function ($http) {

        var urlBase = 'http://localhost:49854/api/Proposals';

        this.getProposals = function () {
            return $http.get(urlBase);
        };

        this.getProposal = function (id) {
            return $http.get(urlBase + '/' + id);
        };

        this.insertProposal = function (proposal) {
            return $http.post(urlBase + '/Post', proposal);
        };

        this.updateProposal = function (proposal) {
            return $http.put(urlBase + '/Put', proposal);
        };

        this.deleteProposal = function (id) {
            return $http.delete(urlBase + '/Delete/' + id);
        };
    }]);
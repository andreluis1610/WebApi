app.controller('ProposalController', ['$scope', '$routeParams', '$location', 'ProposalService', 'CategoryService', 'SupplierService',
    function ($scope, $routeParams, $location, ProposalService, CategoryService, SupplierService) {

    $scope.Proposals;
    $scope.Categories;
    $scope.Suppliers;
    $scope.date = new Date();

    $scope.load = function () {
        ProposalService.getProposals()
            .then(function (response) {
                if (response.data.IsOk) {
                    $scope.Proposals = response.data.Result;
                } else {
                    alert(response.data.Message);
                }
            },
                function (err) {
                    alert("Erro");
                });
    };

    $scope.getProposal = function () {
        if ($routeParams.id != null) {
            ProposalService.getProposal($routeParams.id)
                .then(function (response) {
                    if (response.data.IsOk) {
                        $scope.date = response.data.Result.Date;
                        $scope.categories = response.data.Result.IdCategory;
                        $scope.suppliers = response.data.Result.IdSupplier;
                        $scope.value = response.data.Result.Value;
                        $scope.name = response.data.Result.Name;
                        $scope.description = response.data.Result.Description;
                    } else {
                        alert(response.data.Message);
                    }
                },
                    function (err) {
                        alert("Erro");
                    });
        }
    };

    $scope.insertProposal = function () {

        var proposal = {
            "Id": null,
            "Name": $scope.name,
            "Description": $scope.description,
            "Date": $scope.date,
            "Value": $scope.value,
            "Status": null,
            "StatusDescription": "",
            "StatusNow": null,
            "StatusNowDescription": "",
            "NameFile": "",
            "IdCategory": $scope.categories,
            "CategoryName": "",
            "IdSupplier": $scope.suppliers,
            "SupplierName": ""
        };

        ProposalService.insertProposal(proposal)
            .then(function (response) {
                if (response.data.IsOk) {
                    alert(response.data.Message);
                    $scope.go('/proposal/list');
                } else {
                    alert(response.data.Message);
                }
            },
                function (err) {
                    alert("Erro");
                });
    };

    $scope.deleteProposal = function (id) {
        if (confirm("Deseja realmente excluir a proposta?")) {
            ProposalService.deleteProposal(id)
                .then(function (response) {
                    if (response.data.IsOk) {
                        alert("Proposta excluída com sucesso.");
                        $scope.load();
                    } else {
                        alert(response.data.Message);
                    }
                },
                    function (err) {
                        alert("Erro");
                    });
        }
    };

    $scope.edit = function (id) {
        $scope.go('/proposal/edit/' + id);
    };

    $scope.editProposal = function () {

        var proposal = {
            "Id": $routeParams.id,
            "Name": $scope.name,
            "Description": $scope.description,
            "Date": $scope.date,
            "Value": $scope.value,
            "Status": null,
            "StatusDescription": "",
            "StatusNow": null,
            "StatusNowDescription": "",
            "NameFile": "",
            "IdCategory": $scope.categories,
            "CategoryName": "",
            "IdSupplier": $scope.suppliers,
            "SupplierName": ""
        };

        ProposalService.updateProposal(proposal)
            .then(function (response) {
                if (response.data.IsOk) {
                    alert("Proposta atualizada com sucesso.");
                    $location.path('/proposals/list');
                } else {
                    alert(response.data.Message);
                }
            },
                function (err) {
                    alert("Erro");
                });
    };

    $scope.getCategories = function () {
        CategoryService.getCategories()
            .then(function (response) {
                if (response.data.IsOk) {
                    $scope.Categories = response.data.Result;
                } else {
                    alert(response.data.Message);
                }
            },
                function (err) {
                    alert("Erro");
                });
    };

    $scope.getSuppliers = function () {
        SupplierService.getSuppliers()
            .then(function (response) {
                if (response.data.IsOk) {
                    $scope.Suppliers = response.data.Result;
                } else {
                    alert(response.data.Message);
                }
            },
                function (err) {
                    alert("Erro");
                });
    };

    $scope.go = function (path) {
        $location.path(path);
    };
}]);